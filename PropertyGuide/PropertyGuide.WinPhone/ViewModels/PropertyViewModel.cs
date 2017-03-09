using Ninject;
using PropertyGuide.BusinessLayer;
using PropertyGuide.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyGuide.WinPhone.ApplicationLayer.Managers;

namespace PropertyGuide.WinPhone
{
    public class PropertyViewModel : ViewModelBase
    {
        public int ID { get; set; }

        private string _name;

        public string PropertyName
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _description;

        public string PropertyDescription
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _photUrl;

        public string PhotoURL
        {
            get { return _photUrl; }
            set
            {
                if (value != _photUrl)
                {
                    _photUrl = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool Sold { get; set; }

        public DateTime DateAdded { get; set; }
        public DateTime? DateModified { get; set; }

        public int SellerId { get; set; }
        public int? BuyerId { get; set; }

        public PropertyViewModel()
        {

        }

        public PropertyViewModel(Property item)
        {
            Update(item);
        }

        public void Update(Property item)
        {
            ID = item.ID;
            PropertyName = item.Name;
            _description = item.Description;
            Sold = item.Sold;
            DateAdded = item.DateAdded;
            DateModified = item.DateModified;
            SellerId = item.SellerId;
            BuyerId = item.BuyerId;
            PhotoURL = GetPropertyPhotoUrl();
        }

        private static List<int> numberUsedList = new List<int>();
        private string GetPropertyPhotoUrl()
        {
            var number = CommonUtils.Utils.GetUniqueRandomNumber(1, 10);
            return $"/Assets/property/property{number}.jpg";            
        }

        public Property GetProperty()
        {
            return new Property
            {
                ID = ID,
                Name = PropertyName,
                Description = _description,
                Sold = Sold,
                DateAdded = DateAdded,
                DateModified = DateModified,
                SellerId = SellerId <= 0 ? UserSessionManager.LoggedInUser.ID : SellerId,
                BuyerId = BuyerId,
            };
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
