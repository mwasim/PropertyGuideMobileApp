using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyGuide.BusinessLayer;

namespace PropertyGuide.DataAccessLayer
{
    public interface IUserRepositoryAsync
    {        
        Task<User> GetAsync(int id);
        Task<User> GetAsync(string email, string password);
        Task<bool> HasAnyUser();
        Task<List<User>> GetListAsync();
        Task<int> SaveAsync(User user);
        Task<int> AddAsync(UserType userType);
        Task<int> DeleteAsync(User item);
        Task<int> DeleteAsync(int id);
    }
}