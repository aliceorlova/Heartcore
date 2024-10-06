using Heartcore.Logic.ApiProviders;

namespace Heartcore.Logic.Managers;

public class DataManager : IDataManager
{
    private readonly IContentManagementApiProvider _managementApiProvider;
    private readonly IPublicApiProvider _publicApiProvider;
    private readonly IGraphQLApiProvider _graphQLApiProvider;

    // TODO: Move constants to a separate file
    private const string HomePageId = "c9012a95-afe4-4f5e-89d4-2468a144d57d";
    private const string ShowAlias = "show";
    private const string PersonAlias = "person";

    public DataManager(IContentManagementApiProvider managementApiProvider,
        IPublicApiProvider publicApiProvider, IGraphQLApiProvider graphQLApiProvider)
    {
        _managementApiProvider = managementApiProvider;
        _publicApiProvider = publicApiProvider;
        _graphQLApiProvider = graphQLApiProvider;
    }

    // Should be split up for readability
    public async Task ImportDataToUmbraco()
    {
        // Get all people from public api and load first 10
        var people = _publicApiProvider.GetAllPeople().Take(10);

        // Get the unique shows that need to be created in preparation of creating people starring in them
        var showsToCreate = people.SelectMany(p => p.Embedded.CastCredits.Select(c => c.Links.Show.Name)).
            Distinct().ToList();

        var createdShows = await CreateShows(showsToCreate);
        var peopleModels = ConvertToContentManagementModel(people, createdShows);

        // Create people in Umbraco
        foreach (var model in peopleModels)
        {
            var response = await _managementApiProvider.CreateContentAsync(model);
            if (response is null) throw new Exception($"Creating a person {model.Name} was not successful.");
        }
    }

    public async Task<IEnumerable<PersonClientModel>> GetExistingData()
    {
        return await _graphQLApiProvider.GetAllPeople();
    }

    private async Task<Dictionary<string, string>> CreateShows(List<string> showsToCreate)
    {
        var createdShows = new Dictionary<string, string>(); // { Name - Id } pairs

        // Create all the shows provided
        foreach (var show in showsToCreate)
        {
            // TODO: move to mapper
            var model = new ContentManagementModels.Show
            {
                Name = new ContentManagementModels.Invariant
                {
                    Value = show
                },
                ShowName = new ContentManagementModels.Invariant
                {
                    Value = show
                },
                ParentId = HomePageId,
                ContentTypeAlias = ShowAlias
            };

            var id = await _managementApiProvider.CreateContentAsync(model);

            // TODO: Should be custom ex type. Also checking for null is not it
            if (id is null) throw new Exception($"Creating a show {model.Name} was not successful.");

            // Add a created show id to the dictionary
            createdShows.Add(show.ToString(), $"umb://document/{id}");
        }

        return createdShows;
    }

    private List<ContentManagementModels.Person> ConvertToContentManagementModel(IEnumerable<Models.Person> people,
        Dictionary<string, string> shows)
    {
        var peopleModels = new List<ContentManagementModels.Person>();
        foreach (var person in people)
        {
            var model = new ContentManagementModels.Person
            {
                Name = new ContentManagementModels.Invariant
                {
                    Value = person.Name
                },
                PersonName = new ContentManagementModels.Invariant
                {
                    Value = person.Name
                },
                Birthday = new ContentManagementModels.Invariant
                {
                    Value = person.Birthday
                },
                Country = new ContentManagementModels.Invariant
                {
                    Value = person.Country.Name
                },
                Image = new ContentManagementModels.Invariant
                {
                    Value = person.Image.Medium
                },
                ParentId = HomePageId,
                ContentTypeAlias = PersonAlias,
                Shows = new ContentManagementModels.Shows()
            };

            // Get id of the show by its name and add to the request
            foreach (var name in person.Embedded.CastCredits.Select(c => c.Links.Show.Name))
            {
                model.Shows.Invariant.Add(shows[name]);
            }

            peopleModels.Add(model);
        }

        return peopleModels;
    }
}