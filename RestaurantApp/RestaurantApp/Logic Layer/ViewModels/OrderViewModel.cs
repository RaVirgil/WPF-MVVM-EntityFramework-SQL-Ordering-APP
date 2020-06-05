using RestaurantApp.Data_Layer.Data_Context;
using RestaurantApp.Logic_Layer.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace RestaurantApp.Logic_Layer.ViewModels
{
    class OrderViewModel : BaseViewModel
    {
        #region Properties
        private Person user;
        private Order selectedOrder;
        private ObservableCollection<Order> orders;
        private string totalPrice;
        private ICommand checkoutCommand;
        private ICommand removeOrderCommand;
        private ICommand toHomeCommand;

        public Person User
        {
            get { return user; }
            set { user = value; }
        }

        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set { selectedOrder = value; OnPropertyChanged("SelectedOrder"); }
        }

        public ObservableCollection<Order> Orders
        {
            get { return orders; }
            set { orders = value; OnPropertyChanged("Orders"); }
        }

        public string TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; OnPropertyChanged("TotalPrice"); }
        }

        public ICommand CheckoutCommand
        {
            get { return checkoutCommand ?? (checkoutCommand = new CommandHandler(() => Checkout(), () => true)); }
        }

        public ICommand RemoveOrderCommand
        {
            get { return removeOrderCommand ?? (removeOrderCommand = new CommandHandler(() => RemoveOrder(), () => true)); }
        }

        public ICommand ToHomeCommand
        {
            get { return toHomeCommand ?? (toHomeCommand = new CommandHandler(() => ToHome(), () => true)); }
        }
        #endregion

        #region Ctors
        public OrderViewModel(Person loggedUser)
        {
            this.User = loggedUser;
            using (var tables = new RestaurantEntities())
            {
                Orders = new ObservableCollection<Order>(tables.SpFindOrderByUserId(User.id_Person));
                CalculatePrice();
            }
        }

        public OrderViewModel() { }
        #endregion

        #region Methods
        private void Checkout()
        {
            using (var tables = new RestaurantEntities())
            {
                tables.SpUpdateOrderStatusByUserId(User.id_Person, 2);
                Orders = new ObservableCollection<Order>(tables.SpFindOrderByUserId(User.id_Person));
                if(Orders.Count != 0)
                {
                    MessageBox.Show("Thank you for ordering at our restaurant. We received your order and we will be at your place in a moment :)");
                    return;
                }
                MessageBox.Show("You have to add something to your cart first");
               
            }
           
        }

        private void RemoveOrder()
        {
            if (SelectedOrder == null)
            {
                MessageBox.Show("No order selected");
                return;
            }

            if (SelectedOrder.id_OrderType != 1)
            {
                MessageBox.Show("You cannot cancel this order anymore. Please call the restaurant for help");
                return;
            }

            using (var tables = new RestaurantEntities())
            {
                tables.SpDeleteOrderByProductId(SelectedOrder.id_Product);               
                Orders = new ObservableCollection<Order>(tables.SpFindOrderByUserId(User.id_Person));
                CalculatePrice();
            }
        }

        private void ToHome()
        {
            Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
            Application.Current.MainWindow.DataContext = new ProductsViewModel(User);            
        }

        private void CalculatePrice()
        {
            decimal sum = 0;
            foreach (var i in Orders)
            {
                sum = sum + i.Product.Price;
            }
            TotalPrice = sum.ToString() + "LEI";
        }
        #endregion

    }
}
