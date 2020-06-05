using RestaurantApp.Data_Layer.Data_Context;
using RestaurantApp.Logic_Layer.Commands;
using RestaurantApp.Presentation_Layer.Views;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace RestaurantApp.Logic_Layer.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        #region Properties
        private string email;
        private string password;
        private ICommand loginCommand;
        private ICommand continueNoLoginCommand;
        private ICommand registerCommand;

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }

        public ICommand LoginCommand
        {
            get { return loginCommand ?? (loginCommand = new CommandHandler(() => Login(), () => true)); }
            set { loginCommand = value; }
        }

        public ICommand RegisterCommand
        {
            get { return registerCommand ?? (registerCommand = new CommandHandler(() => Register(), () => true)); }

        }

        public ICommand ContinueNoLoginCommand
        {
            get { return continueNoLoginCommand ?? (continueNoLoginCommand = new CommandHandler(() => ContinueNoLogin(), () => true)); }

        }
        #endregion

        #region Ctors
        #endregion

        #region Methods
        private void Login()
        {
            Person loggedUser;
            if (Email == "" || Email == null)
            {
                MessageBox.Show("Please enter an email");
                return;
            }
            if (password == "" || password == null)
            {
                MessageBox.Show("Please enter a password");
                return;
            }
            using (var tables = new RestaurantEntities())
            {               
                var users = tables.SpFindUserByEmailPassword(Email, Password).ToList();

                if (users.Count == 0)
                {
                    MessageBox.Show("Nonexistent user");
                    return;
                }
                loggedUser = users[0];
            }
            Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
            ProductsView view = new ProductsView();
            view.DataContext = new ProductsViewModel(loggedUser);
            view.Show();
        }

        private void Register()
        {
            Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
            RegisterView view = new RegisterView();
            view.DataContext = new RegisterViewModel();
            view.Show();
        }

        private void ContinueNoLogin()
        {
            Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
            Application.Current.MainWindow.Show();
        }
        #endregion
    }
}
