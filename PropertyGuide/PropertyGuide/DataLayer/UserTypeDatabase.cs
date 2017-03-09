using System;
using PropertyGuide.BusinessLayer;
using PropertyGuide.DataLayer.Contracts;

namespace PropertyGuide.DataLayer
{
    public class UserTypeDatabase : AppDatabase, IUserTypeDatabase
    {
        public UserTypeDatabase(string path) : base(path)
        {
            //create the tables
            CreateTable<UserType>();
        }        
    }
}