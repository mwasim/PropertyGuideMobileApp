using System;
using PropertyGuide.BusinessLayer;
using PropertyGuide.DataLayer.Contracts;

namespace PropertyGuide.DataLayer
{
    class UserDatabase : AppDatabase, IUserDatabase
    {
        public UserDatabase(string path) : base(path)
        {
            //create the tables
            CreateTable<User>();
        }        
    }
}