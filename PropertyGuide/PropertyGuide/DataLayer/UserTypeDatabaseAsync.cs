using PropertyGuide.BusinessLayer;

namespace PropertyGuide.DataLayer
{
    public class UserTypeDatabaseAsync : AppDatabaseAsyncAsync, IUserTypeDatabaseAsync
    {
        public UserTypeDatabaseAsync(string path) : base(path)
        {
            //create the tables
            CreateTableAsync<UserType>().Wait();
        }
    }
}
