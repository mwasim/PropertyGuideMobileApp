using System.Collections.Generic;
using PropertyGuide.DataAccessLayer.Contracts;
using Ninject;

namespace PropertyGuide.BusinessLayer.Managers
{
    public class PropertyManager
    {
        [Inject]
        public IPropertyRepository PropertyRepository { get; set; }

        public Property Get(int id)
        {
            return PropertyRepository.Get(id);
        }

        public List<Property> GetList()
        {
            return PropertyRepository.GetAll();
        }

        public int Save(Property item)
        {
            return PropertyRepository.Save(item);
        }

        //public int Delete(Property item)
        //{
        //    return PropertyRepository.Delete(item);
        //}

        public int Delete(int id)
        {
            return PropertyRepository.Delete(id);
        }       
    }
}