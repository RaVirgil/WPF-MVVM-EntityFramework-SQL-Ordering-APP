using RestaurantApp.Logic_Layer.ViewModels;
using System.Windows;

namespace RestaurantApp.Presentation_Layer.Views
{
    /// <summary>
    /// Interaction logic for ProductsView.xaml
    /// </summary>
    public partial class ProductsView : Window
    {
        public ProductsView()
        {
            InitializeComponent();
            DataContext = new ProductsViewModel();
            
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
