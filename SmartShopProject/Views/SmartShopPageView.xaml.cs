using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace SmartShopProject.Views
{
    /// <summary>
    /// Interaction logic for SmartShopPageView.xaml
    /// </summary>
    public partial class SmartShopPageView : Page
    {
        ObservableCollection<Product> products;

        public SmartShopPageView()
        {
            InitializeComponent();
            products = new ObservableCollection<Product>
            {
                new Product { Name = "Koynek", Price = 50 },
                new Product { Name = "Salvar", Price = 80 },
                new Product { Name = "Corab", Price = 10 },
                new Product { Name = "Eynek", Price = 55  },
                new Product { Name = "Elcek", Price = 5.5  },
                new Product { Name = "Mayka", Price = 4.5  },
                new Product { Name = "Ayaqqabi", Price = 100  },
                new Product { Name = "Sport Ayaqqabi(Nike)", Price = 375  },
                // Digər məhsullar...
            };
            productList.ItemsSource = products;
        }

        public class Product
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }
         public double userBalanceAmount
        {
            get { return (double)GetValue(UserBalanceAmountProperty); }
            set { SetValue(UserBalanceAmountProperty, value); }
        }

        public static readonly DependencyProperty UserBalanceAmountProperty =
            DependencyProperty.Register("userBalanceAmount", typeof(double), typeof(SmartShopPageView), new PropertyMetadata(1000.0));
        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            double price = double.Parse(btn.Tag.ToString());

            // Səbətə əlavə etmə prosesi
            shoppingCart.Items.Add($"Qiymət : {price}  ");

            // Ümumi qiymətin yenilənməsi
            //double total = shoppingCart.Items.Cast<string>().Sum(item => double.Parse(item.Split(' ')[2]));
            //totalPrice.Text = $"Qiymət: {total.ToString()}  ";

            if (userBalanceAmount >= price) // Bakiye yeterliyse
            {
                // Bakiyeden ürün fiyatını çıkart
                userBalanceAmount -= price;

                // Səbətə əlavə etmə prosesi
                shoppingCart.Items.Add($"Qiymət : {price}  ");

                // Kullanıcının güncel bakiyesini göster
                BalanceUser.Text = $"Balance: {userBalanceAmount} Azn";

                // Ümumi qiymətin yenilənməsi
                double total = shoppingCart.Items.Cast<string>().Sum(item => double.Parse(item.Split(' ')[2]));
                totalPrice.Text = $"Qiymət: {total.ToString()}  ";
            }
            else
            {
                MessageBox.Show("Pulun qutardi kasib ) ");
            }

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = searchBox.Text.ToLower(); // Axtarış mətnini götür və kiçik hərflərə çevir

            ObservableCollection<Product> filteredProducts = new ObservableCollection<Product>();
            foreach (var product in products)
            {
                if (product.Name.ToLower().Contains(searchText))
                {
                    filteredProducts.Add(product);
                }
            }

            productList.ItemsSource = filteredProducts; // Yalnız tapılan məhsulu göstər
            if (filteredProducts.Count > 0)
            {
                productList.SelectedItem = filteredProducts[0]; // Əgər tapıldısa, ilk tapılanı seç
                productList.ScrollIntoView(productList.SelectedItem); // Məhsulu görünən hissəyə sürüşdür
            }
            else
            {
                productList.ItemsSource = null; // Məhsul siyahısını təmizlə
            }
        }

        private void BackToUserLogin(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
