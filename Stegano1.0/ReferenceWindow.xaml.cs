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

namespace Stegano1._0
{
    /// <summary>
    /// Логика взаимодействия для ReferenceWindow.xaml
    /// </summary>
    public partial class ReferenceWindow : Window
    {
        public ReferenceWindow()
        {
            InitializeComponent();
        }

        public void showDialog()
        {
            FileStream fs;
            try
            {
                TextRange doc = new TextRange(rtbReference.Document.ContentStart, rtbReference.Document.ContentEnd);
                using (fs = new FileStream("Справка.rtf", FileMode.Open, FileAccess.Read))
                {
                    doc.Load(fs, DataFormats.Rtf);
                    fs.Close();
                }
                
                ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }
    }
}
