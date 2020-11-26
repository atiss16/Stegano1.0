using System;
using System.Collections.Generic;
using System.Collections;
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
using System.IO;
using static Stegano1._0.LSB;

namespace Stegano1._0
{
    /// <summary>
    /// Логика взаимодействия для DecryptWindow.xaml
    /// </summary>
    public partial class DecryptWindow : Window
    {
        public DecryptWindow()
        {
            InitializeComponent();
           
        }
        private void MouseLeftButtonDown_DecryptWindowMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void IsButtonDeryptWindowEnable(bool IsEnable)
        {
            if(IsEnable)
            {
                btnSaveText.IsEnabled = true;
                btnDecrypt.IsEnabled = true;
            }
            else
            {
                btnDecrypt.IsEnabled = false;
                btnSaveText.IsEnabled = false;
            }
        }

        private void BtnBrowseImg_Click(object sender, RoutedEventArgs e)
        {
            lblExample.Content = "";
            Stream checkStream = null;
            IsButtonDeryptWindowEnable(false);
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Filter = "(*.bmp|*.bmp";
            dlg.DefaultExt = ".bmp";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                try
                {
                    checkStream = dlg.OpenFile();
                    if (checkStream != null)
                    {
                        string filename = dlg.FileName;
                        string ext = filename.Remove(0, filename.Length - 4);//расширение
                        if (ext == ".bmp")//проверка расширения
                        {
                            BitmapImage bitmapImage = new BitmapImage();
                            bitmapImage.BeginInit();
                            bitmapImage.UriSource = new Uri(filename);
                            bitmapImage.EndInit();

                            imgDecode.Source = bitmapImage;

                        }
                        else
                        {
                            MessageBox.Show("This file have no extension \".bmp\"", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            IsButtonDeryptWindowEnable(true);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    IsButtonDeryptWindowEnable(true);
                }
            }
            IsButtonDeryptWindowEnable(true);
        }
        

        private void BtnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            lblExample.Content = "Пожалуйста, подождите, идет извлечение";
            IsButtonDeryptWindowEnable(false);
            const int FROM = 20;
            const int TO = 20;
            if(imgDecode.Source==null)
            {
                MessageBox.Show("Загрузите изображение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                IsButtonDeryptWindowEnable(true);
                lblExample.Content = "";
                return;
            }

            BitmapImage bmImage = imgDecode.Source as BitmapImage;
            WriteableBitmap wbmImage = new WriteableBitmap(imgDecode.Source as BitmapSource);
            if (wbmImage.PixelHeight*wbmImage.PixelWidth < 14)
            {
                MessageBox.Show("В этом изображении не может быть сообщения, оно слишком мало", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                IsButtonDeryptWindowEnable(true);
                lblExample.Content = "";
                return;
            }
            string Msg=LSB.DecryptLSB(wbmImage, FROM, TO);
            if (Msg == "")
                lblExample.Content = "";
            else
            lblExample.Content = "Извлечение завершено";
            tbDecryptText.Text = Msg;
            IsButtonDeryptWindowEnable(true);
        }

        private void BtnReturnFromDecrypt_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Owner.Show();
        }

        private void BtnSaveText_Click(object sender, RoutedEventArgs e)
        {
            lblExample.Content = "Пожалуйста, подождите, идет сохранение";
            IsButtonDeryptWindowEnable(false);
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.Filter = "(*.txt|*.txt";
            dlg.FileName = "DecryptedMessage";
            dlg.DefaultExt = ".txt";
            dlg.AddExtension = true;//добавление расширения автоматически
            Nullable<bool> result = dlg.ShowDialog();
            try
            {
                if (result == true)
                {
                    string fileName = dlg.FileName;
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName, false))
                    {
                        file.WriteLine(tbDecryptText.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not write file to disk. Original error: " + ex.Message);
                lblExample.Content = "";
                IsButtonDeryptWindowEnable(true);
            }
            lblExample.Content = "";
            IsButtonDeryptWindowEnable(true);
        }

        private void BtnCloseDecrypt_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Owner.Close();
        }
    }
}