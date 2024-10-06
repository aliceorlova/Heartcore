namespace Heartcore.Logic.ApiProviders
{
	public interface IGraphQLApiProvider
	{
        Task<IEnumerable<PersonClientModel>> GetAllPeople();
    }
}

