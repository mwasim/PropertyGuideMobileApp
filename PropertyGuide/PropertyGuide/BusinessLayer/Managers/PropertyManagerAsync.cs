using Ninject;
using PropertyGuide.DataAccessLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropertyGuide.BusinessLayer.Managers
{
    public class PropertyManagerAsync
    {
        [Inject]
        public IPropertyRepositoryAsync PropertyRepository { get; set; }

        public async Task<Property> GetAsync(int id)
        {
            return await PropertyRepository.GetAsync(id);
        }

        public async Task<List<Property>> GetListAsync()
        {
            return await PropertyRepository.GetAllAsync();
        }

        public async Task<int> SaveAsync(Property item)
        {
            return await PropertyRepository.SaveAsync(item);
        }

        public async Task<int> DeleteAsync(Property item)
        {
            return await PropertyRepository.DeleteAsync(item);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await PropertyRepository.DeleteAsync(id);
        }

        public async Task<List<Property>> GetListBySellerIdAsync(int sellerId)
        {
            return await PropertyRepository.GetListBySellerIdAsync(sellerId);
        }

        public async Task<List<Property>> GetListByBuyerIdAsync(int buyerId)
        {
            return await PropertyRepository.GetListByBuyerIdAsync(buyerId);
        }
    }
}
