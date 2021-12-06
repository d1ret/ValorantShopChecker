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
using ValAPINet;

namespace CheckShopApp
{
    public partial class MainWindow : Window
    {
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
        private async void SignInMouseEnter(object sender, MouseEventArgs e)
        {
            await Task.Delay(1);

            SignInButton.Background = new SolidColorBrush(Color.FromRgb(31, 41, 128));
        }
        private async void SignInMouseLeave(object sender, MouseEventArgs e)
        {
            await Task.Delay(1);

            SignInButton.Background = new SolidColorBrush(Color.FromRgb(61, 80, 250));
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
