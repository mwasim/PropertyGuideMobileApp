using System.Collections.Generic;
using PropertyGuide.BusinessLayer;

namespace PropertyGuide.DataAccessLayer.Contracts
{
    public interface IPropertyRepository
    {
        Property Get(int id);
        List<Property> GetAll();
        int Save(Property item);
        //int Delete(Property item);
        int Delete(int id);
        //List<Property> GetListBySellerId(int sellerId);
        //List<Property> GetListByBuyerId(int buyerId);
    }
}