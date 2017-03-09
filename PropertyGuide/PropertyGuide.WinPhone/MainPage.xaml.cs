using System;
using System.Windows.Input;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PropertyGuide.WinPhone.ApplicationLayer.Managers;
using PropertyGuide.WinPhone.Resources;
using PropertyGuide.WinPhone.Utils;
using System.Windows.Controls;

namespace PropertyGuide.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            DataContext = App.PropertyListViewModel;
            Loaded += MainPage_Loaded;

            //BuildLocalizedApplicationBar();
        }

        private void MainPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ((PropertyListViewModel)DataContext).BeginUpdateAsync(Dispatcher);
        }

        /*
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            var appBarButtonAdd = new ApplicationBarIconButton(new Uri("/Assets/AppBar/new.png", UriKind.Relative));
            appBarButtonAdd.Text = AppResources.AppBarButtonText;
            appBarButtonAdd.Click += HandleAddClick;
            ApplicationBar.Buttons.Add(appBarButtonAdd);

            var appBarButtonBack = new ApplicationBarIconButton(new Uri("/Assets/AppBar/logout3.png", UriKind.Relative));
            appBarButtonBack.Text = AppResources.AppBarLogoutText;
            appBarButtonBack.Click += HandleLogoutClick;
            ApplicationBar.Buttons.Add(appBarButtonBack);

            // Create a new menu item with the localized string from AppResources.
            //ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            //ApplicationBar.MenuItems.Add(appBarMenuItem);

            ApplicationBarMenuItem appBarAllUsersMenuItem = new ApplicationBarMenuItem(AppResources.AppBarUsersText);
            appBarAllUsersMenuItem.Click += (sender, args) =>
            {
                //NavigationService.Navigate(new Uri("/UserListPage.xaml", UriKind.Relative));
                NavigationUtils.NavigateToAllUsersPage(NavigationService);
            };

            ApplicationBar.MenuItems.Add(appBarAllUsersMenuItem);

        }*/

        protected void HandleLogoutClick(object sender, EventArgs args)
        {
            UserSessionManager.LogoutUser(NavigationService);
        }

        /*
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //if (!App.MaingMainPageViewModel.IsDataLoaded)
            //{
            //    App.MaingMainPageViewModel.LoadData();
            //}
        }*/

        private void HandlePropertyTap(object sender, GestureEventArgs e)
        {
            var item = ((Grid)sender).DataContext as PropertyViewModel;

            if (item != null)
            {
                NavigationUtils.NavigateToPropertyDetailsPage(NavigationService, item.ID);                
            }
        }

        private void HandleAddClick(object sender, EventArgs e)
        {
            NavigationUtils.NavigateToPropertyDetailsPage(NavigationService);
        }

        private void HandleAllPropertiesClick(object sender, EventArgs e)
        {
            NavigationUtils.NavigateToAllPropertiesPage(NavigationService);
        }

        private void HandleAllUsersClick(object sender, EventArgs e)
        {
            NavigationUtils.NavigateToAllUsersPage(NavigationService);
        }

        private void HandleFlickrClick(object sender, EventArgs e)
        {
            NavigationUtils.NavigateToFlickrPage(NavigationService);
        }

        //private void HandleLogoutClick(object sender, EventArgs e)
        //{
        //    UserSessionManager.LogoutUser(NavigationService);
        //}
    }
}