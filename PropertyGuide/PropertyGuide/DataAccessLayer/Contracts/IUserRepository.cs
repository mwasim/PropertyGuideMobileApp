using System.Collections.Generic;
using PropertyGuide.BusinessLayer;

namespace PropertyGuide.DataAccessLayer.Contracts
{
    public interface IUserRepository
    {
        User Get(int id);
        User Get(string email, string password);
        bool HasAnyUser();
        List<User> GetList();
        int Save(User user);
        int Add(UserType userType);
        //int Delete(User item);
        int Delete(int id);
    }
}