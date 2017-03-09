using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyGuide.WinPhone.ApplicationLayer.Managers;

namespace PropertyGuide.WinPhone
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel()
        {
            
        }

        public override void LoadData()
        {
            base.LoadData();

            Username = LoggedInUserName;
            IsDataLoaded = true;
        }

        private string _username;

        public string Username
        {
            get { return _username;}
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }


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
    }
}
