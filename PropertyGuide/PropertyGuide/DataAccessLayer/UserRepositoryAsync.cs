using PropertyGuide.BusinessLayer;
using PropertyGuide.DataLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyGuide.DataAccessLayer
{
    public class UserRepositoryAsync : IUserRepositoryAsync
    {
        private IUserDatabaseAsync _db;

        public UserRepositoryAsync(IUserDatabaseAsync db) 
        {
            _db = db;            
        }

        public async Task<User> GetAsync(int id)
        {
            //return await me.Db.GetAsync<User>(id);            

            List<User> userList = await _db.QueryAsync<User>("SELECT * from User where Id =" + id);
            return userList.FirstOrDefault();
        }

        public async Task<User> GetAsync(string email, string password)            
        {
            List<User> userList = await _db.QueryAsync<User>($"SELECT * FROM User where Email = ? AND Password = ?", email, password);
            //await me.Db.QueryAsync<User>($"SELECT * FROM User where Email = '{email}' AND Password = '{password}'");

            return userList.FirstOrDefault();
        }

        public async Task<bool> HasAnyUser()
        {
            int count = await _db.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM User");

            return count > 0;
        }

        public async Task<List<User>> GetListAsync()
        {
            return await _db.GetAllAsync<User>();
        }

        public async Task<int> SaveAsync(User user)
        {
            return await _db.SaveAsync(user);
        }

        public async Task<int> AddAsync(UserType userType)
        {
            return await _db.AddAsync(userType);
        }

        public async Task<int> DeleteAsync(User item)
        {
            return await _db.DeleteAsync(item);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _db.Delete<User>(id);
        }
    }
}
