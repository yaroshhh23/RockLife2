using RockLife.Models;
using RockLife.Repositories;
using RockLife.Repository;
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
using System.Windows.Shapes;

namespace RockLife.Windows
{
    /// <summary>
    /// Interaction logic for CartItemWindow.xaml
    /// </summary>
    public partial class CartItemWindow : Window
    {
        private CartItemRepository _repository;
        public CartItemWindow()
        {
            _repository = new CartItemRepository(new MyAppContext());
            InitializeComponent();
            var userIdNullable = Application.Current.Properties["UserId"] as int?;
            int userId = userIdNullable.Value;

            LoadCartItemsAsync(userId);
        }

        private async void LoadCartItemsAsync(int userId)
        {
            try
            {
                var cartItems = await _repository.GetCartProductDetailsByUserIdAsync(userId);

                // Устанавливаем полученный список как источник данных для ListView
                CartItem.ItemsSource = cartItems;
            }
            catch (Exception e)
            {
                // Обработка возможных исключений
                MessageBox.Show($"Не удалось загрузить данные: {e.Message}");
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SecondMainWindow secondMainWindow = new SecondMainWindow();
            secondMainWindow.Show();
            this.Hide();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            AccountWindow accountWindow = new AccountWindow();
            accountWindow.Show();
            this.Hide();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            CatalogWindow catalogWindow = new CatalogWindow();
            catalogWindow.Show();
            this.Hide();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Hide();
        }
    }
}
