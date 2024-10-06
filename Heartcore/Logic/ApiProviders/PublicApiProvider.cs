using Heartcore.Logic.Models;

namespace Heartcore.Logic.ApiProviders
{
	public class PublicApiProvider: IPublicApiProvider
	{
        public IEnumerable<Person> GetAllPeople()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://api.tvmaze.com");

            var people = new List<Person>();
            for (int i = 1; i < 11; i++)
            {
                var person = httpClient.GetFromJsonAsync<Person>($"/people/{i}?embed=castcredits").Result;
                people.Add(person!);

            }

            return people;
        }
    }
}

