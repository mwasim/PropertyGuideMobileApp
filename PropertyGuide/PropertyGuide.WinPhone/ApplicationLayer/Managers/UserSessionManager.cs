using System;
using System.IO.IsolatedStorage;
using System.Windows.Navigation;
using PropertyGuide.BusinessLayer;

namespace PropertyGuide.WinPhone.ApplicationLayer.Managers
{
    public static class UserSessionManager
    {
        static string UserKey = "UserKey";
        static IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;        

        //public async static Task LoginUser(int userId, NavigationService navService, IUserRepositoryAsync userRepository)
        //{
        //    var user = await userRepository.GetAsync(userId);
        //    if (user == null) return;

        //    LoginUser(user, navService);
        //}

        public static void LoginUser(User user, NavigationService navService)
        {
            LoggedInUser = user;
            navService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        public static void LogoutUser(NavigationService navService)
        {
            LoggedInUser = null;
            navService.Navigate(new Uri("/LoginPage.xaml", UriKind.Relative));
        }

        public static User LoggedInUser
        {
            get
            {
                User user = null;
                if (settings.Contains(UserKey))
                    user = settings[UserKey] as User;

                return user;
            }
            set
            {
                if (settings.Contains(UserKey))
                    settings[UserKey] = value;
                else
                    settings.Add(UserKey, value);
            }
        }

        public static bool IsUserLoggedIn => LoggedInUser != null && LoggedInUser.ID > 0;

    }
}
