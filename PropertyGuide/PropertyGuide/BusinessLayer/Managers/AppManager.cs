using System;
using System.Collections.Generic;
using Ninject;
using PropertyGuide.BusinessLayer;
using PropertyGuide.CommonUtils;
using PropertyGuide.DataAccessLayer.Contracts;

namespace PropertyGuide.BusinessLayer.Managers
{
    public class AppManager
    {
        public bool IsDataLoaded = false;
        [Inject]
        public IUserRepository UserRepository { get; set; }

        [Inject]
        public IUserTypeRepository UserTypeRepository { get; set; }

        [Inject]
        public IPropertyRepository PropertyRepository { get; set; }

        static AppManager()
        {

        }

        //load default data into the database
        public void LoadAppData()
        {
            bool usersExist = UserRepository.HasAnyUser();
            if (usersExist) return; //data already exists, no need to add duplicate data

            //Step-1: Load User Types
            LoadUserTypes();

            //Step-2: Load Users
            LoadUsersData();

            //Step-3: Load Properties
            LoadUserProperties();

            IsDataLoaded = true;
        }

        private void LoadUsersData()
        {
            //Password & DateCreated will be allocated on saving
            var users = Utils.GetDefaultUserList();

            //save users to the database
            foreach (var user in users)
            {
                user.DateCreated = DateTime.Now;
                user.Password = "test";

                UserRepository.Save(user);
            }
        }

        private void LoadUserProperties()
        {
            var properties = Utils.GetDefaultPropertyList();

            //save properties to the database
            foreach (var property in properties)
            {
                PropertyRepository.Save(property);
            }
        }

        private void LoadUserTypes()
        {
            var types = Utils.GetDefaultUserTypeList();

            foreach (var type in types)
            {
                var x = UserTypeRepository.Add(type);
            }
        }
    }
}