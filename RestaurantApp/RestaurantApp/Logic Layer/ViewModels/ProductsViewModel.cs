using RestaurantApp.Data_Layer.Data_Context;
using RestaurantApp.Logic_Layer.Commands;
using RestaurantApp.Presentation_Layer.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace RestaurantApp.Logic_Layer.ViewModels
{
    class ProductsViewModel : BaseViewModel
    {
        #region Properties
        private Person user;
        private Product selectedProduct;
        private ObservableCollection<Product> products;
        private string searchText;
        private ICommand categoryCommand;
        private ICommand toLoginCommand;
        private ICommand toMenusCommand;
        private ICommand toOrdersCommand;
        private ICommand addToCartCommand;
        private ICommand enterCommand;

        public Person User
        {
            get { return user; }
            set { user = value; }
        }

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged("SelectedProduct"); }
        }

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set { products = value; OnPropertyChanged("Products"); }
        }

        public string SearchText
        {
            get { return searchText; }
            set { searchText = value; }
        }

        public ICommand CategoryCommand
        {
            get { return categoryCommand ?? (categoryCommand = new CommandHandler(parameter => CategoryChanged(parameter), () => true)); }
        }

        public ICommand ToLoginCommand
        {
            get { return toLoginCommand ?? (toLoginCommand = new CommandHandler(() => ToLogin(), () => true)); }

        }

        public ICommand ToMenusCommand
        {
            get { return toMenusCommand ?? (toMenusCommand = new CommandHandler(() => ToMenus(), () => true)); }
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
        public ProductsViewModel()
        {
            User = new Person { FirstName = "Not logged in" };
            using (var tables = new RestaurantEntities())
            {
                Products = new ObservableCollection<Product>(tables.SpSelectAllProducts());
            }
        }

        public ProductsViewModel(Person loggedUser)
        {
            this.User = loggedUser;
            using (var tables = new RestaurantEntities())
            {
                Products = new ObservableCollection<Product>(tables.SpSelectAllProducts());
            }
        }
        #endregion

        #region Methods
        private void CategoryChanged(object parameter)
        {
            string category = (string)parameter;
            using (var tables = new RestaurantEntities())
            {
                if (category == "All Products")
                {
                    Products = new ObservableCollection<Product>(tables.SpSelectAllProducts());
                    return;
                }
                Products = new ObservableCollection<Product>(tables.SpFindProductByCategory(category));
            }
        }

        private void ToLogin()
        {
            LoginView view = new LoginView();
            view.DataContext = new LoginViewModel();
            view.Show();
        }

        private void ToMenus()
        {
            Application.Current.MainWindow.Hide();
            MenusView view = new MenusView();
            view.DataContext = new MenusViewModel(User);
            view.Show();
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
            if (SelectedProduct == null)
            {
                MessageBox.Show("Select a product first!");
                return;
            }
            if (User.Email == null)
            {
                MessageBox.Show("You need to Login first!");
                return;
            }
            using (var tables = new RestaurantEntities())
            {
                var order = new Order { id_Product = SelectedProduct.id_Product, id_Person = User.id_Person, id_OrderType = 1 };
                tables.SpInsertProductOrder(SelectedProduct.id_Product, User.id_Person);
                MessageBox.Show(SelectedProduct.Name + " added to cart!");
            }
        }

        private void Search()
        {
            using (var tables = new RestaurantEntities())
            {
                if (SearchText == null || SearchText == "")
                {
                    Products = new ObservableCollection<Product>(tables.SpSelectAllProducts());
                    return;
                }
                Products = new ObservableCollection<Product>(tables.SpFindProductByName(SearchText));
            }
        }
        #endregion
    }
}
