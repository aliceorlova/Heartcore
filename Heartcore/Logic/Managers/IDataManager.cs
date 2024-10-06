namespace Heartcore.Logic.Managers
{
	public interface IDataManager
	{
        public Task ImportDataToUmbraco();

        Task<IEnumerable<PersonClientModel>> GetExistingData();
    }
}

