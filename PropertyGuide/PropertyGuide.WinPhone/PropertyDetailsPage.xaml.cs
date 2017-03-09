using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PropertyGuide.BusinessLayer;
using PropertyGuide.DataAccessLayer;
using PropertyGuide.Infrastructure;
using System.Threading.Tasks;
using PropertyGuide.WinPhone.ApplicationLayer.Managers;
using PropertyGuide.WinPhone.Utils;
using PropertyGuide.BusinessLayer.Managers;

namespace PropertyGuide.WinPhone
{
    public partial class PropertyDetailsPage : PhoneApplicationPage
    {
        private PropertyManagerAsync propertyManager;
        public PropertyDetailsPage()
        {
            InitializeComponent();

            propertyManager = IoCContainer.Get<PropertyManagerAsync>();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.NavigationMode == NavigationMode.New)
            {
                var vm = new PropertyViewModel();
                Property property = default(Property);

                if (NavigationContext.QueryString.ContainsKey("id"))
                {
                    var id = int.Parse(NavigationContext.QueryString["id"]);
                    if (id > 0)
                        property = await propertyManager.GetAsync(id);
                }

                if (property != null)
                {
                    vm.Update(property);
                }

                DataContext = vm;
            }
        }

        private async void HandleSaveClick(object sender, EventArgs e)
        {
            var propertyvm = (PropertyViewModel)DataContext;
            var property = propertyvm.GetProperty();

            await propertyManager.SaveAsync(property);

            NavigationService.GoBack();
        }

        private async void HandleDeleteClick(object sender, EventArgs e)
        {
            var propertyvm = (PropertyViewModel)DataContext;
            if (propertyvm.ID > 0)
                await propertyManager.DeleteAsync(propertyvm.ID);

            NavigationService.GoBack();
        }

        private void HandleAllPropertiesClick(object sender, EventArgs e)
        {
            NavigationUtils.NavigateToAllPropertiesPage(NavigationService);
        }

        private void HandleAllUsersClick(object sender, EventArgs e)
        {
            NavigationUtils.NavigateToAllUsersPage(NavigationService);
        }

        private void HandleLogoutClick(object sender, EventArgs e)
        {
            UserSessionManager.LogoutUser(NavigationService);
        }

        private void HandleFlickrClick(object sender, EventArgs e)
        {
            NavigationUtils.NavigateToFlickrPage(NavigationService);
        }
    }
}