using CAN.Task3SQL.Core;
using CAN.Task3SQL.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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

namespace CAN.Task3SQL.View.Pages
{
    public partial class RegistrationPage : Page
    {


        public RegistrationPage()
        {
            InitializeComponent();
            CbRole.ItemsSource = CoreConnection.db.Roles.ToList();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            CoreConnection.CoreFrame.Navigate(new MainLoginPage());
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLogin.Text) ||
                string.IsNullOrEmpty(PbPassword.Password))
            {
                MessageBox.Show("Ошибка ввода данных",
                                "Системное сообщение",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    CoreConnection.db.Users.Add(new User()
                    {
                        Login = TbLogin.Text,
                        Password = PbPassword.Password,
                        RoleID = Convert.ToInt32(CbRole.Text)
                    });
                    CoreConnection.db.SaveChanges();
                    MessageBox.Show("Учетная запись создана",
                                    "Системное сообщение",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                    CoreConnection.CoreFrame.Navigate(new MainLoginPage());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(),
                                    "Системное сообщение",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                }
            }
        }
    }
}