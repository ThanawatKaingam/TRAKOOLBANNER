using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;
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
using trakoolbanner;
using System.Windows.Interop;
using Microsoft.Win32;
using System.Drawing.Imaging;

namespace trakoolbanner
{
    /// <summary>
    /// Interaction logic for BannerEditor.xaml
    /// </summary>
    public partial class BannerEditor : Window
    {
        public BannerEditor()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            
        }

        private void Button_GotMouseCapture(object sender, MouseEventArgs e)
        {
            
        }


        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Printer wn_printer = new Printer();
            wn_printer.Show();
        }

        private void Rectangle_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Management wn_management = new Management();
            wn_management.Show();
        }

        

    }

}
