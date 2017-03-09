using System;
using Ninject;
using PropertyGuide.CommonUtils;
using PropertyGuide.DataAccessLayer;

namespace PropertyGuide.BusinessLayer.Managers
{
    public class AppManagerAsync
    {
        public bool IsDataLoaded = false;
        [Inject]
        public IUserRepositoryAsync UserRepository { get; set; }

        [Inject]
        public IUserTypeRepositoryAsync UserTypeRepository { get; set; }

        [Inject]
        public IPropertyRepositoryAsync PropertyRepository { get; set; }

        static AppManagerAsync()
        {

        }

        //load default data into the database
        public async void LoadAppData()
        {
            bool usersExist = await UserRepository.HasAnyUser();
            if (usersExist) return; //data already exists, no need to add duplicate data

            //Step-1: Load User Types
            LoadUserTypes();

            //Step-2: Load Users
            LoadUsersData();

            //Step-3: Load Properties
            LoadUserProperties();

            IsDataLoaded = true;
        }

        private async void LoadUsersData()
        {
            //Password & DateCreated will be allocated on saving
            var users = Utils.GetDefaultUserList();

            //save users to the database
            foreach (var user in users)
            {
                user.DateCreated = DateTime.Now;
                user.Password = "test";

                await UserRepository.SaveAsync(user);
            }
        }

        private async void LoadUserProperties()
        {
            var properties = Utils.GetDefaultPropertyList();

            //save properties to the database
            foreach (var property in properties)
            {
                await PropertyRepository.SaveAsync(property);
            }
        }
       
        private async void LoadUserTypes()
        {
            var types = Utils.GetDefaultUserTypeList();

            foreach (var type in types)
            {
                var x = await UserTypeRepository.AddAsync(type);
            }
        }
    }
}
