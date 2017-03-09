using System;
using System.Windows.Navigation;

namespace PropertyGuide.WinPhone.Utils
{
    public static class NavigationUtils
    {
        public static void NavigateToRegisterPage(NavigationService navigationService)
        {
            navigationService.Navigate(new Uri("/RegisterPage.xaml", UriKind.Relative));
        }

        public static void NavigateToAllUsersPage(NavigationService navigationService)
        {
            navigationService.Navigate(new Uri("/UserListPage.xaml", UriKind.Relative));
        }

        public static void NavigateToAllPropertiesPage(NavigationService navigationService)
        {
            navigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        public static void NavigateToPropertyDetailsPage(NavigationService navigationService, int id = -1)
        {
            navigationService.Navigate(new Uri($"/PropertyDetailsPage.xaml?id={id}", UriKind.Relative));
        }

        public static void NavigateToFlickrPage(NavigationService navigationService)
        {
            navigationService.Navigate(new Uri("/FlickrPage.xaml", UriKind.Relative));
        }
    }
}
