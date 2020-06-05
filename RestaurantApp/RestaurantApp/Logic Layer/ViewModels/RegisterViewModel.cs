using RestaurantApp.Data_Layer.Data_Context;
using RestaurantApp.Logic_Layer.Commands;
using RestaurantApp.Presentation_Layer.Views;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace RestaurantApp.Logic_Layer.ViewModels
{
    class RegisterViewModel :BaseViewModel
    {
        #region Properties
        private string firstName;
		private string lastName;
		private string email;
		private string phone;
		private string password;
		private ICommand registerCommand;
		private ICommand cancelCommand;

		public string FirstName
		{
			get { return firstName; }
			set { firstName = value; OnPropertyChanged("First Name"); }
		}

		public string LastName
		{
			get { return lastName; }
			set { lastName = value; OnPropertyChanged("Last Name"); }
		}

		public string Email
		{
			get { return email; }
			set { email = value; OnPropertyChanged("Email"); }
		}

		public string Phone
		{
			get { return phone; }
			set { phone = value; OnPropertyChanged("Phone"); }
		}

		public string Password
		{
			get { return password; }
			set { password = value; OnPropertyChanged("Password"); }
		}

		public ICommand RegisterCommand
		{
			get { return registerCommand ?? (registerCommand = new CommandHandler(() => Register(), () => true)); }			
		}

		public ICommand CancelCommand
		{
			get { return cancelCommand ?? (cancelCommand = new CommandHandler(() => Cancel(), () => true)); }
			
		}
        #endregion

        #region Ctors
        #endregion

        #region Methods
        private void Register()
		{
			if((firstName=="" || firstName == null) ||
				(lastName == "" || lastName == null) ||
				(email == "" || email == null) ||
				(phone == "" || phone == null) ||
				(password == "" || password == null))
			{
				MessageBox.Show("All fields need to be filled!");
				return;
			}
			using (var tables = new RestaurantEntities()) 
			{
				//TODO CHANGE WITH STORED PROCEDURE
				var query =tables.SpFindUserByEmailPassword(Email,Password);
				if (query.Count() != 0)
				{
					MessageBox.Show("There is an user with this email already!");
					return;
				}				
				Person user = new Person { FirstName = firstName, LastName = lastName, Email = email, Password = password, Phone = phone };
				tables.SpInsertUser(firstName,lastName,email,password,phone);
			}
			MessageBox.Show("You are now registered!");
			Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
			LoginView view = new LoginView();
			view.Show();
		}

		private void Cancel()
		{
			Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
			LoginView view = new LoginView();
			view.Show();			
		}
        #endregion
    }
}
