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
    /// Interaction logic for ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        ShopServiceClient service = new ShopServiceClient();

        public ProductPage()
        {
            InitializeComponent();
            balancevalue.Text = service.getBalance(1).ToString("#0.00");
            allproducts.ItemsSource = service.getAllProducts();
            ownedproducts.ItemsSource = service.getUserOwnedProducts(1);
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            allproducts.ItemsSource = service.getAllProducts();
            balancevalue.Text = service.getBalance(1).ToString("#0.00");
            ownedproducts.ItemsSource = service.getUserOwnedProducts(1);
        }
    }
}
