using System;
using System.Collections.Generic;
using System.IO;
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
        public MainWindow()
        {
            InitializeComponent();
        }
        public string Login = null;
        string Password = null;
        string source = null;
        string region = null;
        private async void SignInClickButton(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(() => Login = boxUsername.Text);
            Dispatcher.Invoke(() => Password = boxPassword.Password);
            Dispatcher.Invoke(() => region = RegionBox.Text);
            //await Task.Run(() => GetShop());
            try
            {
                if (Login == "")
                {
                    loginBorder.BorderThickness = new Thickness(1);
                }
                else
                {
                    loginBorder.BorderThickness = new Thickness(0);
                }
                if (Password == "")
                {
                    PasswordBorder.BorderThickness = new Thickness(1);
                }
                else
                {
                    PasswordBorder.BorderThickness = new Thickness(0);
                }
                if (region == "")
                {
                    MessageBox.Show("Вы забыли выбрать Region");
                }

                if (Login != "" && Password != "" && region != "")
                {

                    Auth au = Auth.Login(Login, Password, RegionBox.Text);
                    if (au.EntitlementToken != null)
                    {
                        Storefront SkinImage = Storefront.GetOffers(au);
                        string skin1 = SkinImage.SkinsPanelLayout.SingleItemOffers[0];
                        string skin2 = SkinImage.SkinsPanelLayout.SingleItemOffers[1];
                        string skin3 = SkinImage.SkinsPanelLayout.SingleItemOffers[2];
                        string skin4 = SkinImage.SkinsPanelLayout.SingleItemOffers[3];
                        GetImage img = GetImage.GetOffers(skin1);
                        GetImage img2 = GetImage.GetOffers(skin2);
                        GetImage img3 = GetImage.GetOffers(skin3);
                        GetImage img4 = GetImage.GetOffers(skin4);
                        Shop f2 = new Shop();
                        Properties.Settings.Default.version++;
                        f2.imgTest1.Source = new BitmapImage(new Uri(img.skinPNG));
                        f2.imgTest2.Source = new BitmapImage(new Uri(img2.skinPNG));
                        f2.imgTest3.Source = new BitmapImage(new Uri(img3.skinPNG));
                        f2.imgTest4.Source = new BitmapImage(new Uri(img4.skinPNG));
                        StoreOffers SkinCosts = StoreOffers.GetOffers(au);
                        int count = SkinCosts.Offers.Count;
                        for (int i = 0; i < count; i++)
                        {
                            if (SkinCosts.Offers[i].OfferID == skin1)
                            {
                                f2.textTest1.Content = SkinCosts.Offers[i].Cost.ValorantPoints;
                            }
                            if (SkinCosts.Offers[i].OfferID == skin2)
                            {
                                f2.textTest2.Content = SkinCosts.Offers[i].Cost.ValorantPoints;
                            }
                            if (SkinCosts.Offers[i].OfferID == skin3)
                            {
                                f2.textTest3.Content = SkinCosts.Offers[i].Cost.ValorantPoints;
                            }
                            if (SkinCosts.Offers[i].OfferID == skin4)
                            {
                                f2.textTest4.Content = SkinCosts.Offers[i].Cost.ValorantPoints;
                            }
                        }
                        if (Properties.Settings.Default.version == 1)
                        {
                            Close();
                            f2.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong username or password"); 
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
