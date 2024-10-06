namespace Heartcore.Logic.ApiProviders
{
    public class GraphQLApiProvider : IGraphQLApiProvider
    {
        public async Task<IEnumerable<PersonClientModel>> GetAllPeople()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://graphql.umbraco.io/");
            httpClient.DefaultRequestHeaders.Add("Api-Key", "ji35X6iQezNiTqBonX5X");
            httpClient.DefaultRequestHeaders.Add("Umb-Project-Alias", "alisas-amiable-otter");

            var request = new
            {
                query = "{allPerson(preview:true){edges{node{id,name,birthday,country,shows{name}}}}}"
            };

            var response = await httpClient.PostAsJsonAsync("/", request);

            var responseContent = await response.Content.ReadFromJsonAsync<GraphQLModels.Person>();

            var clientModels = new List<PersonClientModel>();

            foreach(var person in responseContent!.Data.AllPerson.Edges)
            {
                var model = new PersonClientModel
                {
                    Id = person.Node.Id,
                    Name = person.Node.Name,
                    Birthday = person.Node.Birthday,
                    Country = person.Node.Country,
                    Image = "", // Media content needs to be created separately to be used properly
                    Shows = person.Node.Shows?.Select(s => s.Name).ToList() ?? new List<string>()
                };
                clientModels.Add(model);
            }

            return clientModels;
        }
    }
}

