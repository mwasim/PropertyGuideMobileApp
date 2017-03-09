using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PropertyGuide.WinPhone
{
    public partial class RegisterPage : PhoneApplicationPage
    {
        public RegisterPage()
        {
            InitializeComponent();

            DataContext = App.RegisterUserViewModel;
        }

        private void OnAlreadyAMemberClick(object sender, RoutedEventArgs e)
        {
            //go back to the login page
            NavigationService.GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //base.OnNavigatedTo(e);
            if (!App.RegisterUserViewModel.IsDataLoaded)
            {
                App.RegisterUserViewModel.LoadData(NavigationService);
            }
        }
    }
}