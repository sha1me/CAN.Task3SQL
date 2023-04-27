using CAN.Task3SQL.Core;
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
using CAN.Task3SQL.View.Pages;
using CAN.Task3SQL.Model;

namespace CAN.Task3SQL
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CoreConnection.CoreFrame = MainFrame;
            CoreConnection.db = new Task3SQLEntities();
            MainFrame.Navigate(new MainLoginPage());
        }
    }
}
