using System.Windows;
using System.Windows.Navigation;
using Ninject;
using PropertyGuide.BusinessLayer;
using PropertyGuide.DataAccessLayer;
using PropertyGuide.WinPhone.ApplicationLayer.Managers;
using PropertyGuide.WinPhone.ViewModels;

namespace PropertyGuide.WinPhone
{
    public class LoginViewModel : ViewModelBase
    {
        [Inject]
        public IUserRepositoryAsync UserRepositoryAsync { get; set; }

        private static NavigationService _navigationService;
        public void LoadData(NavigationService navService)
        {
            _navigationService = navService;

            IsDataLoaded = true;
        }

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
                LoginCommand.OnCanExecuteChanged();
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
                LoginCommand.OnCanExecuteChanged();
                OnPropertyChanged(nameof(IsInvalidPassword));
            }
        }

        public Visibility IsInvalidPassword =>
            string.IsNullOrEmpty(_password) ? Visibility.Visible : Visibility.Collapsed;

        private bool _isValidLogin = true;
        public Visibility IsValidLogin => _isValidLogin ? Visibility.Collapsed : Visibility.Visible;

        private ActionCommand _loginCommand;

        public ActionCommand LoginCommand
        {
            get { return _loginCommand ?? (_loginCommand = new ActionCommand(ExecuteLoginCommand, CanExecuteLoginCommand)); }
        }

        private bool CanExecuteLoginCommand()
        {
            if (string.IsNullOrEmpty(_email) || string.IsNullOrEmpty(_password)) return false;

            if (!_isValidEmail) return false;

            return true;
        }

        private async void ExecuteLoginCommand()
        {
            User user = await UserRepositoryAsync.GetAsync(_email, _password);

            if (user == null)
            {
                _isValidLogin = false;
                OnPropertyChanged(nameof(IsValidLogin));
                return;
                //invalid credentials make error message visible
            }

            //Login user
            UserSessionManager.LoginUser(user, _navigationService);
        }

    }
}