using Heartcore.Logic.Models;

namespace Heartcore.Logic.ApiProviders
{
	public interface IPublicApiProvider
	{
		// Gets all existing people from TvMaze Api
		public IEnumerable<Person> GetAllPeople();
	}
}

