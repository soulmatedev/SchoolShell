using Database;
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

namespace AdminPanel.AppPages
{
    public partial class UserCreator : Page
    {
        private readonly Database.SchoolShellEntities database;
        public Database.Account Account { get; set; }
        public UserCreator(Database.SchoolShellEntities entities)
        {
            InitializeComponent();
            database = entities;

            MainWindow.connection = new Database.SchoolShellEntities();
            Account = new Database.Account();
            Binding binding = new Binding();
            binding.Source = MainWindow.Role.ToList();
            cbRole.SetBinding(ListView.ItemsSourceProperty, binding);
        }


        public void addAdminClick(object sender, RoutedEventArgs e)
        {

            if (tbFirstName.Text == "" || tbLastName.Text == "" || tbPatronymic.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show("Поля пустые",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            MainWindow.pageContainer.Navigate(PageController.schoolShell);

            Account.firstName = tbFirstName.Text.Trim();
            Account.lastName = tbLastName.Text.Trim();
            Account.patronymic = tbPatronymic.Text.Trim();
            Account.password = tbPassword.Text.Trim();
            Account.username = tbUsername.Text.Trim();
            Account.roleId = (cbRole.SelectedItem as Role).id;

            MainWindow.connection.Accounts.Add(Account);
            MainWindow.connection.SaveChanges();

            NavigationService.GoBack();
        }
        }
}
