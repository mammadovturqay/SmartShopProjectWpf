using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
    /// Interaction logic for Qeydiyyat.xaml
    /// </summary>
    public partial class Qeydiyyat : Page
    {
        private Page previousPage;
        public Qeydiyyat()
        {
            InitializeComponent();
        }

        private void SetPreviousPage()
        {
            previousPage = NavigationService.Content as Page;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

            SetPreviousPage();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.png, *.jpeg)|*.jpg;*.png;*.jpeg";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedImagePath = openFileDialog.FileName;

                // Seçilen resmi ProfileImage'in kaynağı olarak ayarlayalım
                ProfileImage.Source = new BitmapImage(new Uri(selectedImagePath));
            }
        }


        private void RegisterTextTelephone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (var c in e.Text)
            {
                if (!char.IsDigit(c)) 
                {
                    e.Handled = true;
                    erorName.Text = "Sadede nomre daxil edin ";
                    return;
                }
            }
        }

        private void RegisterTextTelephone_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = RegisterTextTelephone.Text;

            if (text.Length < 11 || text.Length > 12)
            {
                erorName.Text = "Nomreni  duzgun daxil edin !  (misal : 994123456789).";
            }
            else if (!text.StartsWith("994"))
            {
                erorName.Text = "Nomreni 994 ile basladin ! (misal : 994123456789).";
            }
            else
            {
                erorName.Text = "";
            }
        }

        private void PasswordMusteri_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PasswordMusteri.Text.Length >9)
            {
                passwordmusteriEroru.Foreground=Brushes.Green;
                passwordmusteriEroru.Background=Brushes.Black;
                passwordmusteriEroru.Text = "Guclu";

            }
            else if (PasswordMusteri.Text.Length < 3)
            {
                passwordmusteriEroru.Foreground=Brushes.Red;
                passwordmusteriEroru.Background=Brushes.Black;
                passwordmusteriEroru.Text = "Cox zeif";

            }
            else if (PasswordMusteri.Text.Length < 9)
            {
                passwordmusteriEroru.Foreground=Brushes.Yellow;
                passwordmusteriEroru.Background=Brushes.Black;
                passwordmusteriEroru.Text = "Zeif";

            }
        }
        public class User
        {
            public int UserId { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
        }

        private List<User> OkuMusteriler(string dosyaYolu)
        {
            List<User> musteriListesi = new List<User>();

            if (File.Exists(dosyaYolu))
            {
                string jsonVeri = File.ReadAllText(dosyaYolu);
                musteriListesi = JsonConvert.DeserializeObject<List<User>>(jsonVeri);
            }

            return musteriListesi;
        }


        private void YazMusteriler(string dosyaYolu, List<User> musteriler)
        {
            string jsonVeri = JsonConvert.SerializeObject(musteriler, Formatting.Indented);
            File.WriteAllText(dosyaYolu, jsonVeri);
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            int userId = 1;
            string username = RegisterTextName.Text;
            string email = RegisterTextEmail.Text;
            string password = PasswordMusteri.Text;
            string address = RegisterCity.Text;




            // Yeni kullanıcı oluştur
            User newUser = new User
            {
                UserId = userId,
                Username = username,
                Password = password,
                Email = email,
                Address = address
            };

            // ListBox'a ekle
            ListBox listBoxMusteriler = this.FindName("ListBoxMusteriler") as ListBox;
            if (listBoxMusteriler != null)
            {
                listBoxMusteriler.Items.Add($"{newUser.UserId}: {newUser.Username}");
            }

            //// JSON dosyasına yaz
            string dataYeri = "../Database/Musteriler.json";
            List<User> existingUsers = OkuMusteriler(dataYeri);
            existingUsers.Add(newUser);
            YazMusteriler(dataYeri, existingUsers);
        }
    }
}
