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

namespace salon.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowsClientService.xaml
    /// </summary>
    public partial class WindowsClientService : Window
    {
        salonEntities context;
        public WindowsClientService()
        {
            InitializeComponent();
            context = new salonEntities();
            ShowTable();
        }
        private void ShowTable()
        {
            DataGridClientService.ItemsSource = context.ClientService.ToList();
        }
    }
}
