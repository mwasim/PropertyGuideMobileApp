using System;
using System.Collections.ObjectModel;
using Ninject;
using PropertyGuide.DataAccessLayer;
using System.Collections.Generic;
using PropertyGuide.WinPhone.ApplicationLayer.Managers;

namespace PropertyGuide.WinPhone
{
    public class UserListViewModel : ViewModelBase
    {
        /// <summary>
        /// A collection of UserViewModel objects
        /// </summary>
        public ObservableCollection<UserViewModel> Users { get; private set; }

        [Inject]
        public IUserRepositoryAsync UserRepositoryAsync { get; set; }

        public UserListViewModel()
        {
            Users = new ObservableCollection<UserViewModel>();
        }

        public async override void LoadData()
        {
            //Clear existing list of users before loading new data
            Users.Clear();
            numberList.Clear();

            var list = await UserRepositoryAsync.GetListAsync();
            if (list == null || list.Count <= 0) return;

            foreach (var user in list)
            {
                Users.Add(new UserViewModel
                {
                    UserId = user.ID,
                    FullName = user.Name,
                    Email = user.Email,
                    Password = user.Password,
                    UserTypeId = user.UserTypeId,
                    PhotoURL = GetUserPhotoUrl(user.ID),
                    DateCreated = user.DateCreated
                });
            }

            IsDataLoaded = true;
        }

        List<int> numberList = new List<int>();
        private string GetUserPhotoUrl(int userId)
        {
            //var rnd = new Random((int)DateTime.Now.Ticks);
            var isMale = userId <= 5; //temporarily we have males with Id below 5

            //var number = 1;
            //while (numberList.Contains(number))
            //{
            //    number++;
            //}

            ////add to list
            //numberList.Add(number);

            //const int maxPhotoCount = 10;
            //if (number > maxPhotoCount) number = 1;

            var number = CommonUtils.Utils.GetUniqueRandomNumber(1, 5);

            return isMale ? $"/Assets/people/male{number}.jpg" : $"/Assets/people/female{number}.png";
        }


        #region "Loggedin User info"
        public string LoggedInUserName
        {
            get
            {
                var user = UserSessionManager.LoggedInUser;
                if (user == null) return string.Empty;

                return user.Name;
            }
        }

        public string WelcomeMessage
        {
            get { return $"Welcome {LoggedInUserName}!"; }
        }
        #endregion
    }
}
