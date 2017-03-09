using PropertyGuide.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Threading;
using System.Windows;
using Windows.System.Threading;
using PropertyGuide.DataAccessLayer;
using Ninject;
using PropertyGuide.WinPhone.ApplicationLayer.Managers;

namespace PropertyGuide.WinPhone
{
    public class PropertyListViewModel : ViewModelBase
    {
        [Inject]
        public IPropertyRepositoryAsync PropertyRepository { get; set; }

        public ObservableCollection<PropertyViewModel> Items { get; private set; }

        public bool IsUpdating { get; set; }
        public Visibility ListVisibility { get; set; }
        public Visibility NoDataVisibility { get; set; }

        public Visibility UpdatingVisibility
        {
            get
            {
                return (IsUpdating || Items == null || Items.Count == 0) ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        
        private Dispatcher dispatcher;

        public async void BeginUpdateAsync(Dispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
            IsUpdating = true;
            Items = null;                     
            
            await ThreadPool.RunAsync(async delegate
            {
                var entries = await PropertyRepository.GetAllAsync();
                PopulateData(entries);
            });
        }

        void PopulateData(List<Property> entries)
        {
            Action action = () =>
            {
                //Set all the new items
                Items = new ObservableCollection<PropertyViewModel>(
                     from e in entries
                     select new PropertyViewModel(e));

                //
                // Update the properties
                //
                OnPropertyChanged("Items");

                ListVisibility = Items.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
                NoDataVisibility = Items.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
                IsUpdating = false;

                OnPropertyChanged("ListVisibility");
                OnPropertyChanged("NoDataVisibility");
                OnPropertyChanged("IsUpdating");
                OnPropertyChanged("UpdatingVisibility");
            };

            dispatcher.BeginInvoke(action);
            //dispatcher.BeginInvoke(DispatcherPriority.Normal, action);

            //OR
            //dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
            //{
            //    //code here    
            //}));
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
