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
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        ShopServiceClient service = new ShopServiceClient();

        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("LoginPage.xaml", UriKind.Relative));
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text != "" && service.isUsernameUnique(username.Text))
            {
                if (service.register(username.Text))
                {
                    MessageBox.Show("Registered!");
                }
                else
                {
                    MessageBox.Show("Something went wrong!");
                }
            }
            else
            {
                MessageBox.Show("Please enter a unique username!");
            }
        }
    }
}
