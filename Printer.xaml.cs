using MySql.Data.MySqlClient;
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
using trakoolbanner;
using System.Drawing.Printing;
using System.IO;
using System.Drawing;
using System.Windows.Interop;
using Microsoft.Win32;
using System.Drawing.Imaging;
using Path = System.IO.Path;
using System.Windows.Xps.Packaging;
using System.Windows.Xps;
using System.Windows.Documents.Serialization;

namespace trakoolbanner
{
    /// <summary>
    /// Interaction logic for Printer.xaml
    /// </summary>
    public partial class Printer : Window
    {
        public Printer()
        {
            InitializeComponent();
        }

        private void wn_printer_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = $"SELECT * FROM member ";
            MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=;database=testdatabase;");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandTimeout = 0;
            con.Open();
        }
    }
}
