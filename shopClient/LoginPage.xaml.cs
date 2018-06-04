using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ShopClient.ShopService;
using ShopLibrary;

namespace ShopClient
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        ShopServiceClient service = new ShopServiceClient();

        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text == "" || password.Text == "")
            {
                MessageBox.Show("Please enter a password/username!");
            }
            else
            {
                if (service.login(username.Text, password.Text) != null)
                {
                    MessageBox.Show("succes!");
                    this.NavigationService.Navigate(new Uri("ProductPage.xaml", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("Invalid username/password combination!");
                }
            }

        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("RegisterPage.xaml", UriKind.Relative));
        }

        private void buy_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
