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
    /// Логика взаимодействия для WindowsClient.xaml
    /// </summary>
    public partial class WindowsClient : Window
    {
        salonEntities context;
        string currentLetter = "";
        public WindowsClient()
        {
            InitializeComponent();
            context = new salonEntities();
            CmbGender.ItemsSource = context.Gender.ToList();
            ShowTable();
        }
        private void ShowTable()
        {
            DataGridClient.ItemsSource = context.Client.ToList();
            if (CmbGender.SelectedItem == null)
                return;
            Gender currentGender = (Gender)CmbGender.SelectedItem;
            //var currentTeam = CmbTeam.SelectedItem as Team;
            string searchText = TxtFirstName.Text;
            List<Client> listClientt = context.Client.ToList();
            listClientt = listClientt.Where(x => x.Gender == currentGender).ToList();
            List<ClientService> listClient = context.ClientService.ToList();
            listClient = listClient.Where(x => x.Client.FirstName.ToLower().Contains(searchText.ToLower())).ToList();
            if (currentLetter.Count() == 1)
                listClient = listClient.Where(x => x.Client.FirstName.Contains(currentLetter)).ToList();
            //DataGridClient.ItemsSource = listClient.OrderBy(x => x.Client ).ToList();
        }


        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var currentRegistr = DataGridClient.SelectedItem as Client;
            if (currentRegistr == null)
            {
                MessageBox.Show("Выберите строку");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удалить эту строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Client.Remove(currentRegistr);
                context.SaveChanges();
                ShowTable();
        }
    }

        private void BtnAddClient_Click_1(object sender, RoutedEventArgs e)
        {
            var NewClient = new Client();
            context.Client.Add(NewClient);
            var cl = new WindowAddClient(context, NewClient);
            cl.ShowDialog();
            ShowTable();
        }

        private void CmbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowTable();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button cl = sender as Button;
            var currentRegistr = cl.DataContext as Client;
            var Edit = new WindowAddClient(context, currentRegistr);
            Edit.ShowDialog();
        }

        private void TxtFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ShowTable();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
