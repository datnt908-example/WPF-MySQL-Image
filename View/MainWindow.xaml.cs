using Microsoft.Win32;
using Model;
using Repository.MySQL;
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

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Config database
            DBConnection.Instance().DatabaseName = "mysql_image";
            DBConnection.Instance().Password = "root";

            InitializeComponent();
        }

        private void btnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select a picture";
            openFileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (openFileDialog.ShowDialog() == true)
                imgProductImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
        }

        private void dtgProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product selectedProduct = dtgProducts.SelectedItem as Product;
            if (selectedProduct != null)
                imgProductImage.Source = selectedProduct.BitmapImage;
            else
                imgProductImage.Source = null;
        }
    }
}
