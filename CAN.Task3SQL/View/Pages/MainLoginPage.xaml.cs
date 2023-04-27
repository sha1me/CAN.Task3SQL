using CAN.Task3SQL.Core;
using CAN.Task3SQL.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CAN.Task3SQL.View.Pages
{
    public partial class MainLoginPage : Page
    {
        private Task3SQLEntities db = new Task3SQLEntities();

        public MainLoginPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TbLogin.Text) ||
                string.IsNullOrEmpty(PbPassword.Password))
            {
                MessageBox.Show("Ошибка ввода данных", "Системное сообщение",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    User userModel = db.Users.FirstOrDefault(d => d.Login == TbLogin.Text && d.Password == PbPassword.Password);
                    if (userModel != null)
                    {
                        MessageBox.Show($"{userModel.Login} - выполнен успешный вход!", "Системное сообщение",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка ввода данных", "Системное сообщение",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Системное сообщение",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                }
            }
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            CoreConnection.CoreFrame.Navigate(new RegistrationPage());
        }
    }
}
