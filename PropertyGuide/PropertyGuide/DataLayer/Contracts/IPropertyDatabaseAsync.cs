using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyGuide.BusinessLayer;
using PropertyGuide.DataLayer.Contracts;

namespace PropertyGuide.DataLayer
{
    public interface IPropertyDatabaseAsync : IAppDatabaseAsync
    {
        Task<List<Property>> GetListBySellerIdAsync(int sellerId);
        Task<List<Property>> GetListByBuyerIdAsync(int buyerId);
        Task<List<Property>> GetUnsoldListAsync();
    }
}
