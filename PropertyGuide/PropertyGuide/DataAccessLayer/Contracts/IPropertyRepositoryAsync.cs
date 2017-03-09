using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyGuide.BusinessLayer;

namespace PropertyGuide.DataAccessLayer
{
    public interface IPropertyRepositoryAsync
    {
        Task<Property> GetAsync(int id);
        Task<List<Property>> GetAllAsync();
        Task<int> SaveAsync(Property item);
        Task<int> DeleteAsync(Property item);
        Task<int> DeleteAsync(int id);
        Task<List<Property>> GetListBySellerIdAsync(int sellerId);
        Task<List<Property>> GetListByBuyerIdAsync(int buyerId);
    }
}