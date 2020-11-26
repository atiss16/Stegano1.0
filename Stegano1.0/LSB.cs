using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows;

namespace Stegano1._0
{
    public class LSB
    {
        public static bool EncryptLSB(WriteableBitmap wbmImage,  string TextForEncode, int stride, int FROM,int TO)
        {
            byte[] textBytes = Encoding.Unicode.GetBytes(TextForEncode);
            BitArray textBits = new BitArray(textBytes);//получаем массив битов из текста
            if (wbmImage.Format.BitsPerPixel < 32)
            {
                MessageBox.Show("Будут заметны искажения в изображении, переведите в 24-разрядный формат", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            //MessageBox.Show("txtBytes:" + textBytes.Count() + "\ncolorBytes:" + colors.Count()+"\nlinc"+linesCount);

            int msgBitCount = FROM + TO + textBits.Count;//сколько бит будет занимать сообщение

            //int howMuchBitsContainLine = (wbmImage.PixelWidth * wbmImage.Format.BitsPerPixel*8);//no delete
            int howMuchFreeBitsContainLine = (wbmImage.PixelWidth * wbmImage.Format.BitsPerPixel / 8);
            int linesCount = msgBitCount / howMuchFreeBitsContainLine;
            if (msgBitCount % howMuchFreeBitsContainLine > 0 && linesCount >= wbmImage.PixelHeight)
            {
                MessageBox.Show("Размера изображения недостаточно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (linesCount < wbmImage.PixelHeight && (msgBitCount % howMuchFreeBitsContainLine > 0 || linesCount == 0))//если строк не хватит из-за целочисленного деления
                linesCount++;
            //lbltest1.Content += "linCount=" + linesCount;
            byte[] colors = new byte[linesCount * wbmImage.PixelWidth * wbmImage.Format.BitsPerPixel];

            if (textBytes.Count() * 8 + FROM + TO > colors.Count())
            {
                MessageBox.Show("Размера изображения недостаточно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            
            Int32Rect rect = new Int32Rect(0, 0, wbmImage.PixelWidth, linesCount);
            wbmImage.CopyPixels(rect, colors, stride, 0);//получаем массив байт начиная с 0го
            BitArray imgBits = new BitArray(colors);
            //int countImg = FROM;
            int countImg = FROM*8;
            for (int i = 0; i < FROM * 8; i += 8)
            {
                //imgBits[i++] = true;
                imgBits[i] = true;
            }
            for (int i = 0; i < textBits.Count; i++, countImg += 8)
            {
                //imgBits[countImg++] = textBits[i++];
                imgBits[countImg] = textBits[i];
            }
            for (int i = countImg; i < countImg + TO * 8 + 1; i += 8)//заполняем еще 50 бит 1
            {
                imgBits[i] = true;
            }

            
            imgBits.CopyTo(colors, 0);
            
            wbmImage.WritePixels(rect, colors, stride, 0);//начиная с 5го
            //imgBits.CopyTo(colors, 0);
            //for (int i = 0; i < colors.Count(); i++)
            //{
            //    if (i % (wbmImage.PixelWidth*4) == 0)
            //        test += "\n";
            //    test += colors[i];
            //    test += " ";
            //}
            //MessageBox.Show(test);
            return true;
        }

        private static void BitsToBytes(List<bool> src, byte[] textBytes)
        {

            for (int j = 0; j < textBytes.Count(); j++)
            {
                byte num = 0;
                {
                    for (byte index = 0, m = 1; index < 8; index++, m *= 2)
                        num += src[index + j * 8] ? m : (byte)0;
                    textBytes[j] = num;
                }
            }


        }

        public static string DecryptLSB(WriteableBitmap wbmImage, int FROM, int TO)
        {
            string Msg="";
            int stride = wbmImage.PixelWidth * (wbmImage.Format.BitsPerPixel) / 8;
            //int stride = wbmImage.PixelWidth * (wbmImage.Format.BitsPerPixel + 7) / 8;
            byte[] colors = new byte[wbmImage.PixelHeight * stride];
            wbmImage.CopyPixels(colors, stride, 0);//получаем массив байт начиная с 5го
            BitArray imgBits = new BitArray(colors);
            bool haveMsg = true;
            //for (int i = 0; i < FROM * 8; i += 8)
            for (int i = 0; i < FROM * 8; i += 8)
            {
                if (imgBits[i])
                    continue;
                else haveMsg = false;
            }
            
            if (!haveMsg)
            {
                MessageBox.Show("В этом изображении нет сообщения");
                return "";
            }
            List<bool> msgBits = new List<bool>();
            int countEnd = 0;
            //for (int i = FROM; i < imgBits.Count; i += 8)
            for (int i = FROM*8; i < imgBits.Count; i += 8)
            {
                bool b1 = imgBits[i];
                //bool b2 = imgBits[i];
                if (b1)
                    countEnd++;
                else countEnd = 0;
                if (countEnd == TO)
                    break;
                msgBits.Add(b1);
            }
            byte[] msgBytes = new byte[(msgBits.Count - (TO - 1)) / 8];//без последних единиц
            BitsToBytes(msgBits, msgBytes);
            //string test = "";
            //for (int i = 0; i < msgBytes.Count(); i++)
            //{
            //    //if (i % (wbmImage.PixelWidth * 4) == 0)
            //    //    test += "\n";
            //    test += msgBytes[i];
            //    test += " ";
            //}
            //MessageBox.Show(test);


            Msg = Encoding.Unicode.GetString(msgBytes);
            if (Msg == "")
                Msg = "Нет сообщения";
            return Msg;
        }
    }
}
