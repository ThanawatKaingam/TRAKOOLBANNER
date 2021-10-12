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
using Path = System.IO.Path;
using System.Drawing.Printing;
using System.Windows.Xps.Packaging;
using System.Windows.Xps;
using System.Windows.Documents.Serialization;

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
        private void wn_banner_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = $"SELECT * FROM member ";
            MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=;database=testdatabase;");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandTimeout = 0;
            con.Open();
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
      /*  public static void Print_WPF_Preview(FrameworkElement wpf_Element)
        {
            string sPrintFilename = "print_preview.xps";
            if (File.Exists(sPrintFilename) == true) File.Delete(sPrintFilename);

            //สร้าง doc
            XpsDocument doc = new XpsDocument(sPrintFilename, FileAccess.ReadWrite);
            XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(doc);

            SerializerWriterCollator output_Document = writer.CreateVisualsCollator();
            output_Document.BeginBatchWrite();
            output_Document.Write(wpf_Element);
            output_Document.EndBatchWrite();

            //เปิด
            FixedDocumentSequence preview = doc.GetFixedDocumentSequence();

            //เปิดหน้าตัวอย่าง
            TRAKOOLBANNER.Print_Window print_Window = new TRAKOOLBANNER.Print_Window(preview);
            print_Window.Show();

            //ปิด
            doc.Close();
            writer = null;
            output_Document = null;
            doc = null;
        }
*/
        //กดหน้า printer
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            //clsPrinter.Print_one_Page(Show_Image);
            Printer wn_printer = new Printer();
            wn_printer.Show();
        }
        //กดหน้า management
        private void Rectangle_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Management wn_management = new Management();
            wn_management.Show();
        }
        //ปุ่ม save รูป
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Bitmap b = new Bitmap(txt_main_data14.Text);

                b.Save("path of the folder to save");


                b = new Bitmap(@"C:\Documents and Settings\Desktop\" + txt_main_data14.Text + ".jpg");

                b.Save(@"C:\Extract\" + txt_main_data14.Text + ".jpg");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //ปุ่มที่อยู่รูป
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            txt_main_data13.Text = Directory.GetCurrentDirectory() + "\\Resources\\" + txt_main_data14.Text + ".jpg";

        }

    }

}
