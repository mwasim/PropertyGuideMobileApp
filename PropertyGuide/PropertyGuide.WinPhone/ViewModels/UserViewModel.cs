using System;
using PropertyGuide.CommonUtils;

namespace PropertyGuide.WinPhone
{
    public class UserViewModel : ViewModelBase
    {
        private int _userId;

        public int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                if (value != _userId)
                {
                    _userId = value;
                    OnPropertyChanged();
                }
            }
        }


        private string _fullName;

        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                if (value != _fullName)
                {
                    _fullName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _password;

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }


        private bool _isSeller;

        public bool IsSeller
        {
            get
            {
                return _isSeller;
            }
            set
            {
                if (value != _isSeller)
                {
                    _isSeller = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _userTypeId;

        public int UserTypeId
        {
            get
            {
                return _userTypeId;
            }
            set
            {
                if (_userTypeId != value)
                {
                    _userTypeId = value;
                    OnPropertyChanged();
                }
            }
        }

        public string UserTypeName
        {
            get
            {
                if (_userTypeId <= 0) return string.Empty;

                switch ((UserTypeEnum)_userTypeId)
                {
                    case UserTypeEnum.Seller:
                        return $"{UserTypeEnum.Seller}";
                    case UserTypeEnum.Buyer:
                        return $"{UserTypeEnum.Buyer}";
                    default:
                        return string.Empty;
                }
            }
        }
        //private string _userType;

        //public string UserType
        //{
        //    get { return _userType; }
        //    set
        //    {
        //        if (value != _userType)
        //        {
        //            _userType = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

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

        public DateTime DateCreated { get; set; }
    }

    /*
    public class UserViewModel : ViewModelBase
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsSeller { get; set; } //TRUE = YES, False = NO (is buyer)

        public DateTime DateCreated { get; set; }
    }*/
}
