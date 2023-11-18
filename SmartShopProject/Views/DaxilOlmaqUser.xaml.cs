using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace SmartShopProject.Views
{
    /// <summary>
    /// Interaction logic for DaxilOlmaqUser.xaml
    /// </summary>
    public partial class DaxilOlmaqUser : Page
    {
        public DaxilOlmaqUser()
        {
            InitializeComponent();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack(); 

        }

        public class User
        {
            public string UserName { get; set; }
            public string UserPassword { get; set; }
            public User(string username , string userpassword)
            {
                    
                UserName = username;
                UserPassword = userpassword;

            }

        }



        private void Daxil_User(object sender, RoutedEventArgs e)
        {
            // YeniBirpencere acilacaq 
            string enteredUsername = UserNameTextBox.Text;

            string enteredPassword = UserPasswordTextBox.Password; 

            
            User validUser = new User("Turqay", "123");

            if (enteredUsername == validUser.UserName && enteredPassword == validUser.UserPassword)
            {
                SmartShopPageView smartShopPageView = new SmartShopPageView();

                NavigationService.Navigate(smartShopPageView);
            }
            else
            {
                MessageBox.Show("Ad ve yaxudda Kod yanlisdir yeniden tekrar yoxlayin .", "Ad Ve Kod Sehvi ", MessageBoxButton.OK, MessageBoxImage.Error);
                UserPasswordTextBox.Clear();
                UserNameTextBox.Clear();
                
            }
        }
    }
}
