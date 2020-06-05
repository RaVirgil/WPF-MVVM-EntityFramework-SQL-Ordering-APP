using RestaurantApp.Data_Layer.Data_Context;
using RestaurantApp.Logic_Layer.Commands;
using RestaurantApp.Presentation_Layer.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;


namespace RestaurantApp.Logic_Layer.ViewModels
{
    class MenusViewModel : BaseViewModel
    {

        #region Properties
        private Person user;
        private Menu selectedMenu;
        private ObservableCollection<Menu> menus;
        private ObservableCollection<MenuType> menuTypes;
        private string searchText;
        private ICommand categoryCommand;
        private ICommand toLoginCommand;
        private ICommand toProductsCommand;
        private ICommand toOrdersCommand;
        private ICommand addToCartCommand;
        private ICommand enterCommand;

        public Person User
        {
            get { return user; }
            set { user = value; }
        }

        public Menu SelectedMenu
        {
            get { return selectedMenu; }
            set { selectedMenu = value; OnPropertyChanged("SelectedMenu"); }
        }

        public ObservableCollection<Menu> Menus
        {
            get { return menus; }
            set { menus = value; OnPropertyChanged("Menus"); }
        }

        public ObservableCollection<MenuType> MenuTypes
        {
            get { return menuTypes; }
            set { menuTypes = value; OnPropertyChanged("MenuTypes"); }
        }

        public string SearchText
        {
            get { return searchText; }
            set { searchText = value; OnPropertyChanged("SearchText"); }
        }

        public ICommand CategoryCommand
        {
            get { return categoryCommand ?? (categoryCommand = new CommandHandler(parameter => CategoryChanged(parameter), () => true)); }
        }

        public ICommand ToLoginCommand
        {
            get { return toLoginCommand ?? (toLoginCommand = new CommandHandler(() => ToLogin(), () => true)); }

        }

        public ICommand ToProductsCommand
        {
            get { return toProductsCommand ?? (toProductsCommand = new CommandHandler(() => ToProducts(), () => true)); }
        }

        public ICommand ToOrdersCommand
        {
            get { return toOrdersCommand ?? (toOrdersCommand = new CommandHandler(() => ToOrders(), () => true)); }

        }

        public ICommand AddToCartCommand
        {
            get { return addToCartCommand ?? (addToCartCommand = new CommandHandler(() => AddToCart(), () => true)); }
        }

        public ICommand EnterCommand
        {
            get { return enterCommand ?? (enterCommand = new CommandHandler(() => Search(), () => true)); }
        }
        #endregion

        #region Ctors
        public MenusViewModel()
        {
            using (var tables = new RestaurantEntities())
            {
                Menus = new ObservableCollection<Menu>(tables.SpSelectAllMenus());
            }
        }

        public MenusViewModel(Person loggedUser)
        {
            this.User = loggedUser;
            SelectedMenu = null;
            using (var tables = new RestaurantEntities())
            {
                Menus = new ObservableCollection<Menu>(tables.SpSelectAllMenus());
            }
        }
        #endregion

        #region Methods
        private void CategoryChanged(object parameter)
        {
            string category = (string)parameter;
            using (var tables = new RestaurantEntities())
            {
                if (category == "All Menus")
                {
                    Menus = new ObservableCollection<Menu>(tables.SpSelectAllMenus());
                    return;
                }

                Menus = new ObservableCollection<Menu>(tables.SpFindMenuByCategory(category));
            }
        }

        private void ToLogin()
        {
            Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
            LoginView view = new LoginView();
            view.DataContext = new LoginViewModel();
            view.Show();
        }

        private void ToProducts()
        {
            Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
            Application.Current.MainWindow.DataContext = new ProductsViewModel(User);
            Application.Current.MainWindow.Show();
        }

        private void ToOrders()
        {
            if (User.Email == null)
            {
                MessageBox.Show("You need to Login first");
                return;
            }
            OrderView view = new OrderView();
            view.DataContext = new OrderViewModel(User);
            view.Show();
        }

        private void AddToCart()
        {
            if (User.Email == null)
            {
                MessageBox.Show("You need to Login first");
                return;
            }
            if (SelectedMenu == null)
            {
                MessageBox.Show("Select a product first");
                return;
            }
            using (var tables = new RestaurantEntities())
            {
                var query = tables.SpFindAllProductsInMenu(SelectedMenu.id_Menu).ToList();
                foreach (var i in query)
                {
                    tables.SpInsertProductOrder(i.id_Product, User.id_Person);
                }
                MessageBox.Show(SelectedMenu.Name + " added to cart");
            }
        }

        private void Search()
        {
            using (var tables = new RestaurantEntities())
            {
                if (SearchText == null || SearchText == "")
                {
                    Menus = new ObservableCollection<Menu>(tables.SpSelectAllMenus());
                    return;
                }
                Menus = new ObservableCollection<Menu>(tables.SpFindMenuByName(SearchText));
            }
        }
        #endregion
    }
}
