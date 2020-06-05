using System.Windows;

namespace RestaurantApp.Presentation_Layer.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();           
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[Application.Current.Windows.Count - 1].Close();
            Application.Current.Windows[Application.Current.Windows.Count - 2].Show();
        }
    }
}
