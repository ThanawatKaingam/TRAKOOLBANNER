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

namespace TRAKOOLBANNER
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //โหลดฐานข้อมูล
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {           

            string sql = $"SELECT * FROM member ";
            MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=;database=testdatabase;");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandTimeout = 0;
            con.Open();
            if (Properties.Settings.Default.UserName != string.Empty) 
            { 
            txt_username.Text = Properties.Settings.Default.UserName;
            txt_password.Password = Properties.Settings.Default.Password;
            }
        }

        //ปุ่มเข้าสู่ระบบ
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (txt_username.Text != string.Empty || txt_password.Password != string.Empty)
            {

                string sql = $"SELECT * FROM member WHERE Username ='{txt_username.Text}' AND Password ='{txt_password.Password}'";
                MySqlConnection con = new MySqlConnection("host=localhost;user=root;password=;database=testdatabase;");
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.CommandTimeout = 0;
                con.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();

                    this.Hide();
                    BannerEditor wn_banner = new BannerEditor();
                    wn_banner.Show();
                }
                else
                {
                    reader.Close();
                    MessageBox.Show("ไม่มีชื่อผู้ใช้นี้ในระบบ");
                }
            }
            else
            {
                MessageBox.Show("โปรดใส่ชื่อและรหัสผ่าน.");
            }
            if (cb_remember.IsChecked == true)
            {
                Properties.Settings.Default.UserName = txt_username.Text;
                Properties.Settings.Default.Password = txt_password.Password;
                Properties.Settings.Default.Save();
            }
            if (cb_remember.IsChecked == false)
            {
                Properties.Settings.Default.UserName = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Save();
            }

        }

    }
}
