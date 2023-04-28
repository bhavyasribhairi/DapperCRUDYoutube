namespace DapperDemoData.Data
{
    public interface IDataAccess
    {

        public Task<IEnumerable<T>> GetData<T, P>(string query, P parameters);

        public Task SaveData<P>(string query, P parameters);
    }
}