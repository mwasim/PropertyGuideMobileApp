using PropertyGuide.BusinessLayer;

namespace PropertyGuide.DataLayer
{
    public class UserDatabaseAsync : AppDatabaseAsyncAsync, IUserDatabaseAsync
    {
        public UserDatabaseAsync(string path) : base(path)
        {
            //create the tables
            CreateTableAsync<User>().Wait();
        }
    }
}
