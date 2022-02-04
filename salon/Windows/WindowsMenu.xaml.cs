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
using salon.Windows;
namespace salon.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowsMenu.xaml
    /// </summary>
    public partial class WindowsMenu : Window
    {
        public WindowsMenu()
        {
            InitializeComponent();
        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            var NewClient = new WindowsClient();
            NewClient.ShowDialog();
        }

        private void BtnService_Click(object sender, RoutedEventArgs e)
        {
            var NewService = new WindowsService();
            NewService.ShowDialog();
        }

        private void BtnClientService_Click(object sender, RoutedEventArgs e)
        {
            var NewClientService = new WindowsClientService();
            NewClientService.ShowDialog();
        }
    }
}
