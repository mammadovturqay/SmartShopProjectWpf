using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace SmartShopProject.Views
{
    /// <summary>
    /// Interaction logic for MusterilerAdminPageView.xaml
    /// </summary>
    public partial class MusterilerAdminPageView : Page
    {
        public MusterilerAdminPageView()
        {
            InitializeComponent();
        }

        public class Musteriler
        {
            public int UserId { get; set; }
            public string? Username { get; set; }
            public string? Password { get; set; }
            public string? Email { get; set; }

            public string? Address { get; set; }

            public Musteriler(int v, string? username, string? password, string? email, string? address)
            {
                Username = username;
                Password = password;
                Email = email;
                Address = address;
            }
        }


        public void MusterilerListboxAdd()
        {
            string dataYeri = "../Database/Musteriler.json";

            // JSON dosyasından müşteri bilgilerini oku
            List<Musteriler> okunanMusteriler = OkuMusteriler(dataYeri);
            okunanMusteriler.Add(new Musteriler(1, "Tuncay", "123456", "Tuncay@gmail.com", "Naxcivan"));

            // JSON dosyasına yaz
            YazMusteriler(dataYeri, okunanMusteriler);

            ListBox musterilerListBox = this.FindName("musteriler") as ListBox; // 'musteriler' olarak değiştirildi.

            // Eğer ListBox bulunduysa ve müşteri bilgileri okunduysa
            if (musterilerListBox != null && okunanMusteriler != null)
            {
                // ListBox içindeki eski verileri temizle
                musterilerListBox.Items.Clear();

                // JSON dosyasından okunan müşteri bilgilerini ListBox içine ekle
                foreach (Musteriler musteri in okunanMusteriler)
                {
                    musterilerListBox.Items.Add($"{musteri.UserId}: {musteri.Username} : {musteri.Password} :  {musteri.Address} , ");
                }
            }

            // Daha fazla işlemler...
        }

        private List<Musteriler> OkuMusteriler(string dosyaYolu)
        {
            List<Musteriler> musteriListesi = new List<Musteriler>();

            if (File.Exists(dosyaYolu))
            {
                string jsonVeri = File.ReadAllText(dosyaYolu);
                musteriListesi = JsonConvert.DeserializeObject<List<Musteriler>>(jsonVeri);
            }

            return musteriListesi;
        }

        private void YazMusteriler(string dosyaYolu, List<Musteriler> musteriler)
        {
            string jsonVeri = JsonConvert.SerializeObject(musteriler, Formatting.Indented);
            File.WriteAllText(dosyaYolu, jsonVeri);
        }
    }
}

