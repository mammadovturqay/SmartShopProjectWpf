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

namespace SmartShopProject.Views
{
    /// <summary>
    /// Interaction logic for AdminPageView.xaml
    /// </summary>
    public partial class AdminPageView : Page
    {
        public AdminPageView()
        {
            InitializeComponent();
        }

        private void MusteriPageAdmin(object sender, RoutedEventArgs e)
        {
            frameMain.Navigate( new MusterilerAdminPageView());
        }

        private void MallarPageAdmin(object sender, RoutedEventArgs e)
        {
            frameMain.Navigate(new MallarAdminPage());
        }

        private void back_buttonAdmin(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

        }
    }
}
