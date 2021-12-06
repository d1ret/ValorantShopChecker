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

namespace CheckShopApp
{
    public partial class Shop : Window
    {
        public Shop()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private async void X_Enter(object sender, MouseEventArgs e)
        {
            await Task.Delay(1);

            xButton.Foreground = new SolidColorBrush(Colors.Gray);
        }
        private async void X_Leave(object sender, MouseEventArgs e)
        {
            await Task.Delay(1);

            xButton.Foreground = new SolidColorBrush(Colors.White);
        }
        private async void _Enter(object sender, MouseEventArgs e)
        {
            await Task.Delay(1);

            minusButton.Foreground = new SolidColorBrush(Colors.Gray);
        }
        private async void _Leave(object sender, MouseEventArgs e)
        {
            await Task.Delay(1);

            minusButton.Foreground = new SolidColorBrush(Colors.White);
        }

        private void xButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void minusButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
