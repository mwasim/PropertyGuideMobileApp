using PropertyGuide.BusinessLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyGuide.DataAccessLayer
{
    public interface IUserTypeRepositoryAsync
    {
        Task<int> DeleteAsync(UserType item);
        Task<int> DeleteAsync(int id);
        Task<UserType> GetAsync(int id);
        Task<List<UserType>> GetListAsync();
        Task<int> SaveAsync(UserType userType);
        Task<int> AddAsync(UserType userType);
    }
}