using System.Collections.Generic;
using PropertyGuide.BusinessLayer;
using PropertyGuide.DataLayer.Contracts;
using PropertyGuide.DataAccessLayer.Contracts;

namespace PropertyGuide.DataAccessLayer
{
    public class PropertyRepository : IPropertyRepository
    {
        IPropertyDatabase _db;

        public PropertyRepository(IPropertyDatabase db)
        {
            _db = db;
        }

        public Property Get(int id)
        {
            return _db.Get<Property>(id);            
        }

        public List<Property> GetAll()
        {
            return _db.GetAll<Property>();            
        }

        public int Save(Property item)
        {
            return _db.Save(item);           
        }

        //public int Delete(Property item)
        //{
        //    return _db.Delete(item);            
        //}

        public int Delete(int id)
        {
            return _db.Delete<Property>(id);            
        }

        /*
        public List<Property> GetListBySellerId(int sellerId)
        {
            return _db.GetListBySellerId(sellerId);            
        }

        public List<Property> GetListByBuyerId(int buyerId)
        {
            //return _db.GetListByBuyerId(buyerId);
            throw new NotImplementedException();
        }*/
    }
}