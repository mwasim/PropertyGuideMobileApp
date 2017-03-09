using System.Collections.Generic;
using PropertyGuide.BusinessLayer;
using PropertyGuide.DataLayer;
using System.Threading.Tasks;

namespace PropertyGuide.DataAccessLayer
{
    public class PropertyRepositoryAsync : IPropertyRepositoryAsync
    {
        IPropertyDatabaseAsync _db;

        public PropertyRepositoryAsync(IPropertyDatabaseAsync db)
        {
            _db = db;
        }

        public async Task<Property> GetAsync(int id)
        {
            return await _db.GetAsync<Property>(id);
        }

        public async Task<List<Property>> GetAllAsync()
        {
            return await _db.GetAllAsync<Property>();
        }

        public async Task<int> SaveAsync(Property item)
        {
            return await _db.SaveAsync(item);
        }

        public async Task<int> DeleteAsync(Property item)
        {
            return await _db.DeleteAsync(item);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _db.Delete<Property>(id);
        }

        public async Task<List<Property>> GetListBySellerIdAsync(int sellerId)
        {
            return await _db.GetListBySellerIdAsync(sellerId);
        }

        public async Task<List<Property>> GetListByBuyerIdAsync(int buyerId)
        {
            return await _db.GetListByBuyerIdAsync(buyerId);
        }
    }
}
