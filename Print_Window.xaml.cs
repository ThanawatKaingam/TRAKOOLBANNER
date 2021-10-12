using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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
using System.Windows.Xps;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Navigation;
using trakoolbanner;
using System.Windows.Interop;
using Microsoft.Win32;
using System.Drawing.Imaging;
using Path = System.IO.Path;
using System.Drawing.Printing;
using System.Windows.Xps.Packaging;
using System.Windows.Documents.Serialization;

namespace TRAKOOLBANNER
{
    /// <summary>
    /// Interaction logic for Print_Window.xaml
    /// </summary>
    public partial class Print_Window : Window
    {
        private FixedDocumentSequence _document;
        public Print_Window(FixedDocumentSequence document)
        {
            _document = document;
            InitializeComponent();
            PreviewD.Document = document;
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            Print_Document();
        }

        public void Print_Document()

        {
            PrintDialog printDialog = new PrintDialog();

            printDialog.PrintQueue = LocalPrintServer.GetDefaultPrintQueue();

            printDialog.PrintTicket = printDialog.PrintQueue.DefaultPrintTicket;

            printDialog.PrintTicket.PageOrientation = PageOrientation.Landscape;

            printDialog.PrintTicket.PageScalingFactor = 90;

            printDialog.PrintTicket.PageMediaSize = new PageMediaSize(PageMediaSizeName.ISOA4);

            printDialog.PrintTicket.PageBorderless = PageBorderless.None;



            if (printDialog.ShowDialog() == true)

            {

                _document.PrintTicket = printDialog.PrintTicket;

                XpsDocumentWriter writer = PrintQueue.CreateXpsDocumentWriter(printDialog.PrintQueue);

                writer.WriteAsync(_document, printDialog.PrintTicket);

            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = $"SELECT * FROM member ";
            MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=;database=testdatabase;");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandTimeout = 0;
            con.Open();
        }
    }
}
