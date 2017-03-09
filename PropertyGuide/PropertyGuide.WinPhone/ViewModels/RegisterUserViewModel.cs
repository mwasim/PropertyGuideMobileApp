using System;
using System.Windows;
using System.Windows.Navigation;
using Ninject;
using PropertyGuide.BusinessLayer;
using PropertyGuide.BusinessLayer.Managers;
using PropertyGuide.CommonUtils;
using PropertyGuide.DataAccessLayer;
using PropertyGuide.WinPhone.ApplicationLayer.Managers;
using PropertyGuide.WinPhone.ViewModels;

namespace PropertyGuide.WinPhone
{
    public class RegisterUserViewModel : ViewModelBase
    {
        [Inject]
        public IUserRepositoryAsync UserRepositoryAsync { get; set; }

        private static NavigationService _navigationService;
        public RegisterUserViewModel()
        {
            //_navigationService = navService;
        }

        public void LoadData(NavigationService navService)
        {
            _navigationService = navService;

            IsDataLoaded = true;
        }

        //public bool IsDataLoaded
        //{
        //    get;
        //    private set;
        //}

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
                RegisterUserCommand.OnCanExecuteChanged();
                OnPropertyChanged(nameof(IsInvalidValidName));
            }
        }

        public Visibility IsInvalidValidName
            => (string.IsNullOrEmpty(_name)) ? Visibility.Visible : Visibility.Collapsed;

        private bool _isValidEmail;
        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                _isValidEmail = !string.IsNullOrEmpty(_email) && CommonUtils.Utils.IsValidEmail(_email);

                OnPropertyChanged();
                RegisterUserCommand.OnCanExecuteChanged();
                OnPropertyChanged(nameof(IsInvalidEmail));
            }
        }

        public Visibility IsInvalidEmail
            => (string.IsNullOrEmpty(_email) || !_isValidEmail) ? Visibility.Visible : Visibility.Collapsed;

        private string _password;

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged();
                RegisterUserCommand.OnCanExecuteChanged();
                OnPropertyChanged(nameof(IsInvalidPassword));
            }
        }

        public Visibility IsInvalidPassword =>
            string.IsNullOrEmpty(_password) ? Visibility.Visible : Visibility.Collapsed;

        private bool _isSeller = true;

        public bool IsSeller
        {
            get { return _isSeller; }
            set
            {
                _isSeller = value;
                OnPropertyChanged();
            }
        }

        private ActionCommand _registerCommand;
        public ActionCommand RegisterUserCommand
        {
            get
            {
                //Action action = ExecuteRegisterUserCommand;
                //OR
                /*Action action = () =>
                {
                    //Assuming validation is already performed
                    //Register user 
                };*/

                //Func<bool> canExecuteRegCommand = CanExecuteRegisterCommand;
                //OR
                /*Func<bool> canExecute = () =>
                {
                    return true;
                };*/


                var command = _registerCommand ?? (_registerCommand = new ActionCommand(ExecuteRegisterUserCommand, CanExecuteRegisterCommand));

                return command;
            }
        }


        private async void ExecuteRegisterUserCommand()
        {
            //Register a new user (buyer or seller) in the database
            var user = new User
            {
                Name = Name,
                Email = Email,
                Password = Password,
                DateCreated = DateTime.Now,
                UserTypeId = _isSeller ? (int)UserTypeEnum.Seller : (int)UserTypeEnum.Buyer
            };

            int saved = await UserRepositoryAsync.SaveAsync(user);

            if (saved <= 0) return; //TODO: Show error message


            User dbUser = await UserRepositoryAsync.GetAsync(user.Email, user.Password);

            //Login user
            UserSessionManager.LoginUser(dbUser, _navigationService);
        }

        private bool CanExecuteRegisterCommand()
        {
            //Validate Registration Form 
            //Make sure all entered data is valid
            //All the required fields are filled in
            //TODO: Valid data is entered (valid name, email, and password fields)
            bool isValid = ValidateRegistrationForm();
            //if (!isValid) return false;

            return isValid;
        }

        private bool ValidateRegistrationForm()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email)
                || string.IsNullOrEmpty(Password))
            {
                return false;
            }

            //_isValidEmail = CommonUtils.Utils.IsValidEmail(Email);
            if (!_isValidEmail)
            {
                return false;
            }

            return true;
        }
    }
}