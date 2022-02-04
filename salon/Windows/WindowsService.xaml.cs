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
    /// Логика взаимодействия для WindowsService.xaml
    /// </summary>
    public partial class WindowsService : Window
    {
        salonEntities context;
        public WindowsService()
        {
            InitializeComponent();
            context = new salonEntities();
            ShowDialog();
        }

        private void ShowDialog()
        {
            DataGridService.ItemsSource = context.Service.ToList();
        }
    }
}
