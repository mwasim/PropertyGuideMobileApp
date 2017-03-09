using System.Collections.Generic;
using System.Linq;
using PropertyGuide.BusinessLayer;
using PropertyGuide.DataLayer.Contracts;
using PropertyGuide.DataAccessLayer.Contracts;

namespace PropertyGuide.DataAccessLayer
{
    public class UserRepository : IUserRepository
    {
        private IUserDatabase _db;

        public UserRepository(IUserDatabase db)
        {
            _db = db;
        }

        public User Get(int id)
        {
            List<User> userList = _db.Query<User>("SELECT * from User where Id =" + id);
            return userList.FirstOrDefault();
        }

        public User Get(string email, string password)
        {
            List<User> userList = _db.Query<User>($"SELECT * FROM User where Email = ? AND Password = ?", email, password);
            return userList.FirstOrDefault();
        }

        public bool HasAnyUser()
        {
            //List<User> userList = _db.Query<User>("SELECT * from User");
            int count = _db.ExecuteScalar<int>("SELECT COUNT(*) FROM User");

            return count > 0;
        }

        public List<User> GetList()
        {
            return _db.GetAll<User>();
        }

        public int Save(User user)
        {
            return _db.Save(user);
        }

        public int Add(UserType userType)
        {
            return _db.Add(userType);
        }

        //public int Delete(User item)
        //{
        //    return _db.Delete(item);
        //}

        public int Delete(int id)
        {
            return _db.Delete<User>(id);
        }
    }
}