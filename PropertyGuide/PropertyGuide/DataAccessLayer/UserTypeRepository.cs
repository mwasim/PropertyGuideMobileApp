using System.Collections.Generic;
using System.Linq;
using PropertyGuide.BusinessLayer;
using PropertyGuide.DataLayer.Contracts;
using PropertyGuide.DataAccessLayer.Contracts;
using System;

namespace PropertyGuide.DataAccessLayer
{
    public class UserTypeRepository : IUserTypeRepository
    {
        private IUserTypeDatabase _db;

        public UserTypeRepository(IUserTypeDatabase db)
        {
            _db = db;
        }

        public UserType Get(int id)
        {
            List<UserType> userList = _db.Query<UserType>("SELECT * from UserType where Id =" + id);
            return userList.FirstOrDefault();
        }

        public List<UserType> GetList()
        {
            return _db.GetAll<UserType>();            
        }

        public int Save(UserType userType)
        {
            return _db.Save(userType);            
        }

        public int Add(UserType userType)
        {
            return _db.Add(userType);            
        }

        //public int Delete(UserType item)
        //{
        //    return _db.Delete(item);            
        //}

        public int Delete(int id)
        {
            return _db.Delete<UserType>(id);
        }

        public int Delete(UserType item)
        {
            throw new NotImplementedException();
        }
    }
}