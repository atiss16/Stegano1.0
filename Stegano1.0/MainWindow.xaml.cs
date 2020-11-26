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

namespace Stegano1._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            EncryptWindow encryptWindow = new EncryptWindow();
            encryptWindow.Owner = this;
            this.Hide();
            encryptWindow.ShowDialog();
            
        }

        private void BtnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            DecryptWindow decryptWindow = new DecryptWindow();
            decryptWindow.Owner = this;
            this.Hide();
            decryptWindow.ShowDialog();
        }

       

        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Owner = this;
            aboutWindow.ShowDialog();
        }

        private void BtnReference_Click(object sender, RoutedEventArgs e)
        {
            ReferenceWindow referenceWindow = new ReferenceWindow();
            referenceWindow.Owner = this;
            referenceWindow.showDialog();
        }
    }
}
