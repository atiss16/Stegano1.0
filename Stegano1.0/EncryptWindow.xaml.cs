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
using System.IO;
using System.Collections;
using System.Drawing;
using static Stegano1._0.LSB;
//using LSB;

namespace Stegano1._0
{
    /// <summary>
    /// Логика взаимодействия для EncryptWindow.xaml
    /// </summary>
    public partial class EncryptWindow : Window
    {
        public EncryptWindow()
        {
            InitializeComponent();
            //this.Owner.Close();
        }

        //private 
        private void TbTextForEncode_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblCountOfSymbols.Content = "Колличество символов: ";
            string text = tbTextForEncode.Text;
            int count = text.Length;
            lblCountOfSymbols.Content += count.ToString();
        }

        private void MouseLeftButtonDown_EncryptWindowMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void IsButtonCryptWindowEnable(bool IsEnable)
        {
            if (IsEnable)
            {
                btnBrowseImg.IsEnabled = true;
                btnBrowseText.IsEnabled = true;
                btnCrypt.IsEnabled = true;
                btnSaveImg.IsEnabled = true;
            }
            else
            {
                btnBrowseImg.IsEnabled = false;
                btnBrowseText.IsEnabled = false;
                btnCrypt.IsEnabled = false;
                btnSaveImg.IsEnabled = false;
            }
        }
        private void BtnCrypt_Click(object sender, RoutedEventArgs e)
        {
            const int FROM = 20;
            const int TO = 20;
            IsButtonCryptWindowEnable(false);

            lbltest1.Content = "Пожалуйста, подождите";
            if(imgEncode.Source==null)
            {
                MessageBox.Show("Загрузите изображение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                lbltest1.Content = "";
                IsButtonCryptWindowEnable(true);
                return;
            }

            if (tbTextForEncode.Text=="")
            {
                MessageBox.Show("Введите текст", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                lbltest1.Content = "";
                IsButtonCryptWindowEnable(true);
                return;
            }

            WriteableBitmap wbmImage = new WriteableBitmap(imgEncode.Source as BitmapSource);
            int stride = wbmImage.PixelWidth * (wbmImage.Format.BitsPerPixel ) / 8;
            //wbmImage.Format.BitsPerPixel=32
            if (wbmImage.PixelHeight*wbmImage.PixelWidth <14)
            {
                MessageBox.Show("Изображение слишком мало для сокрытия данным алгоритмом", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                lbltest1.Content = "";
                IsButtonCryptWindowEnable(true);
                return;
            }
            //lbltest1.Content = "bitperpix " + wbmImage.Format.BitsPerPixel;

            //int msgBitCount = FROM + TO + textBits.Count;//сколько бит будет занимать сообщение

            ////int howMuchBitsContainLine = (wbmImage.PixelWidth * wbmImage.Format.BitsPerPixel*8);//no delete
            //int howMuchFreeBitsContainLine = (wbmImage.PixelWidth * wbmImage.Format.BitsPerPixel/8);
            //int linesCount = msgBitCount / howMuchFreeBitsContainLine;
            //if (msgBitCount % howMuchFreeBitsContainLine > 0 && linesCount >= wbmImage.PixelHeight)
            //{
            //    MessageBox.Show("Размера изображения недостаточно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //    IsButtonCryptWindowEnable(true);
            //    lbltest1.Content = "";
            //    return;
            //}
            //if (linesCount<wbmImage.PixelHeight && (msgBitCount % howMuchFreeBitsContainLine > 0 || linesCount==0))//если строк не хватит из-за целочисленного деления
            //    linesCount++;
            ////lbltest1.Content += "linCount=" + linesCount;
            //byte[] colors = new byte[linesCount * wbmImage.PixelWidth*wbmImage.Format.BitsPerPixel];
            //lbltest1.Content += colors.Count().ToString()+"      "+linesCount;

            string textForEncode = tbTextForEncode.Text;

            bool allRight=LSB.EncryptLSB(wbmImage, textForEncode, stride, FROM, TO);
            if (!allRight)
            {
                lbltest1.Content = "";
                IsButtonCryptWindowEnable(true);
                return;
            }
            imgEncode.Source = wbmImage;
            lbltest1.Content = "Сообщение скрыто";
            
            IsButtonCryptWindowEnable(true);
        }
        
        private void BtnBrowseImg_Click(object sender, RoutedEventArgs e)
        {
            //lbltest1.Content = imgEncode.Source;
            lbltest1.Content = "";
            IsButtonCryptWindowEnable(false);
            Stream checkStream = null;
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Filter = "(*.bmp|*.bmp";
            dlg.DefaultExt = ".bmp";
            byte[] bytes;
            Nullable<bool> result = dlg.ShowDialog();
            const int FROM = 20;
            const int TO = 20;
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
                            if (bitmapImage.PixelHeight > 1500 || bitmapImage.Width > 1500)
                            {
                                MessageBox.Show("Изображение превышает допустимый размер 1500×1500 пикселей",
                                    "Ошибка", MessageBoxButton.OK);
                                IsButtonCryptWindowEnable(true);
                                return;
                            }
                            imgEncode.Source = bitmapImage;

                            bytes = File.ReadAllBytes(filename);
                            lblAllowableAmount.Content = "Допустимо символов: " +
                                ((bitmapImage.PixelHeight * bitmapImage.PixelWidth * bitmapImage.Format.BitsPerPixel / 8 - FROM - TO) / 16);
                            //32 бита в пикселе всего - доступны 4 бита в пикселе
                        }
                        else
                        {
                            MessageBox.Show("This file have no extension \".bmp\"", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            IsButtonCryptWindowEnable(true);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    IsButtonCryptWindowEnable(true);
                }
                
            }
            IsButtonCryptWindowEnable(true);
        }
        private void BtnSaveImg_Click(object sender, RoutedEventArgs e)
        {
            IsButtonCryptWindowEnable(false);
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            lbltest1.Content = "Подождите, идет процесс сохранения";
            dlg.Filter = "(*.bmp|*.bmp";
            dlg.FileName = "image";
            dlg.DefaultExt = ".bmp";
            dlg.AddExtension = true;//добавление расширения автоматически
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                try
                {
                    string fileName = dlg.FileName;
                    BmpBitmapEncoder bmpBitmapEncoder = new BmpBitmapEncoder();
                    bmpBitmapEncoder.Frames.Add(BitmapFrame.Create(imgEncode.Source as BitmapSource));
                    using (FileStream file = new FileStream(fileName, FileMode.Create))
                        bmpBitmapEncoder.Save(file);
                }
                //catch (System.IO.IOException)
                catch (Exception ex)
                {
                    MessageBox.Show("Choose another name Original error: " + ex.Message);
                    lbltest1.Content = "";
                    IsButtonCryptWindowEnable(true);
                }
                
            }
            lbltest1.Content = "";
            IsButtonCryptWindowEnable(true);
        }


        private void BtnBrowseText_Click(object sender, RoutedEventArgs e)
        {
            Stream checkStream = null;
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Filter = "(*.txt|*.txt";
            dlg.DefaultExt = ".txt";
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
                        if (ext == ".txt")//проверка расширения
                        {
                            using (StreamReader streamRead = new StreamReader(filename))
                            {
                                tbTextForEncode.Text = "";
                                while (!streamRead.EndOfStream)
                                {
                                    tbTextForEncode.Text += streamRead.ReadLine();
                                    tbTextForEncode.Text += "\n";
                                }
                            }
                        }
                        else
                            MessageBox.Show("This file have no extension \".txt\"", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

            }
        }

        private void BtnReturnFromEncrypt_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Owner.Show();
        }

        private void BtnCloseEncrypt_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Owner.Close();
        }
    }
}