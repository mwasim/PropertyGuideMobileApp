using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyGuide.BusinessLayer;
using PropertyGuide.DataLayer;
using System.Linq;

namespace PropertyGuide.DataAccessLayer
{
    public class UserTypeRepositoryAsync : IUserTypeRepositoryAsync
    {
        private IUserTypeDatabaseAsync _db;

        public UserTypeRepositoryAsync(IUserTypeDatabaseAsync db)
        {
            _db = db;
        }

        public async Task<UserType> GetAsync(int id)
        {
            List<UserType> userList = await _db.QueryAsync<UserType>("SELECT * from UserType where Id =" + id);
            return userList.FirstOrDefault();
        }

        public async Task<List<UserType>> GetListAsync()
        {
            return await _db.GetAllAsync<UserType>();
        }

        public async Task<int> SaveAsync(UserType userType)
        {
            return await _db.SaveAsync(userType);
        }

        public async Task<int> AddAsync(UserType userType)
        {
            return await _db.AddAsync(userType);
        }

        public async Task<int> DeleteAsync(UserType item)
        {
            return await _db.DeleteAsync(item);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _db.Delete<UserType>(id);
        }
    }
}
