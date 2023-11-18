using SmartShopProject.Admin;
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
    /// Interaction logic for AdminGiris.xaml
    /// </summary>
    public partial class AdminGiris : Page
    {
        private Page previousPage;
        public AdminGiris()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        private void SetPreviousPage()
        {
            previousPage = NavigationService.Content as Page;
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            SetPreviousPage();

        }

        private void ButtonADMINgiris(object sender, RoutedEventArgs e)
        {
            Adminn adminn = new Adminn();
            if (admintextbox.Text == adminn.AdminUsername &&  passwordadmin.Password == adminn.AdminPassword)
            {
                //Admin Penceresi acilmalidir 
                AdminPageView adminPageView = new AdminPageView();
                NavigationService.Navigate(adminPageView);
                
            }
            else
            {
                MessageBox.Show("Melumatlar sehvdir ", "Eror", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
