using System;
using System.Collections;
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
        private  void SignInClickButton(object sender, RoutedEventArgs e)
        {
            var Login = boxUsername.Text;
            var Password = boxPassword.Password;
            var region = RegionBox.Text;
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
                        Shop f2 = new Shop();
                        var png = new[] { f2.imgTest1, f2.imgTest2, f2.imgTest3, f2.imgTest4 };
                        var text = new[] { f2.textTest1, f2.textTest2, f2.textTest3, f2.textTest4 };
                        for (int i=0;i<4;i++)
                        {
                            Storefront SkinImage = Storefront.GetOffers(au);
                            string skin = SkinImage.SkinsPanelLayout.SingleItemOffers[i];
                            GetImage img = GetImage.GetOffers(skin);
                            var pngs = png[i];
                            pngs.Source = new BitmapImage(new Uri(img.skinPNG));
                            StoreOffers SkinCosts = StoreOffers.GetOffers(au);
                            int count = SkinCosts.Offers.Count;
                            for (int d = 0; d < count; d++)
                            {
                                if (SkinCosts.Offers[d].OfferID == skin)
                                {
                                    var texts = text[i];
                                    texts.Content = SkinCosts.Offers[d].Cost.ValorantPoints;
                                }
                            }
                        }
                        Properties.Settings.Default.version++;
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
