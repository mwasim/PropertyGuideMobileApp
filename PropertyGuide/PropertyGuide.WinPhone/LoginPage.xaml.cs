using System;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using PropertyGuide.WinPhone.Utils;

namespace PropertyGuide.WinPhone
{
    public partial class LoginPage : PhoneApplicationPage
    {
        public LoginPage()
        {
            InitializeComponent();

            DataContext = App.LoginViewModel;
        }

        private void OnCreateNewAccountClick(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Uri("/RegisterPage.xaml", UriKind.Relative));
            NavigationUtils.NavigateToRegisterPage(NavigationService);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //reset fields
            if (!App.LoginViewModel.IsDataLoaded)
            {
                App.LoginViewModel.LoadData(NavigationService);
            }
        }
    }
}