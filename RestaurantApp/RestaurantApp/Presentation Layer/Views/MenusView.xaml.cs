using System.Windows;

namespace RestaurantApp.Presentation_Layer.Views
{
    /// <summary>
    /// Interaction logic for MenusView.xaml
    /// </summary>
    public partial class MenusView : Window
    {
        public MenusView()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
