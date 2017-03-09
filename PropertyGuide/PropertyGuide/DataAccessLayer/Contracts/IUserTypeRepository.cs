using System.Collections.Generic;
using PropertyGuide.BusinessLayer;

namespace PropertyGuide.DataAccessLayer.Contracts
{
    public interface IUserTypeRepository
    {
        UserType Get(int id);
        List<UserType> GetList();
        int Save(UserType userType);
        int Add(UserType userType);
        //int Delete(UserType item);
        int Delete(int id);
    }
}