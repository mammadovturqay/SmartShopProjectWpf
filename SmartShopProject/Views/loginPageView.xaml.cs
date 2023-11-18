using SmartShopProject.Views;
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

namespace SmartShopProject
{
    /// <summary>
    /// Interaction logic for loginPageView.xaml
    /// </summary>
    public partial class loginPageView : Page
    {
        public loginPageView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Qeydiyyat qeydiyyat = new Qeydiyyat();
            NavigationService.Navigate(qeydiyyat);
           

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Admin(object sender, RoutedEventArgs e)
        {
            AdminGiris adminGiris = new AdminGiris();
            NavigationService.Navigate(adminGiris);
        }

        private void DaxilOlClick(object sender, RoutedEventArgs e)
        {
            //Yeni bir page acilmalidir 
            DaxilOlmaqUser daxilOlmaqUser = new DaxilOlmaqUser();
            NavigationService.Navigate(daxilOlmaqUser);

        }
    }


}
