using AdminPanel.Account;
using AdminPanel.AppPages;
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

namespace AdminPanel.AppWindow
{
    public partial class AdminCreator : Page
    {
        private readonly Database.SchoolShellEntities database;

        public Database.Account Account { get; set; }
        public AdminCreator(Database.SchoolShellEntities entities)
        {
            InitializeComponent();
            database = entities;
        }

        private void CheckRoles()
        {
            var roles = new Roles();
            var properties = typeof(Roles).GetProperties();
            foreach (var property in properties)
            {
                string roleName = property.GetValue(roles).ToString();
                if (database.Roles.Count(r => r.name == roleName) == 0)
                {
                    Console.WriteLine("Роль {0} отсутствует", roleName);

                    database.Roles.Add(new Database.Role() { name = roleName });
                }
            }

            database.SaveChanges();
        }

        private void addAdminClick(object sender, RoutedEventArgs e)
        {

            if (tbFirstName.Text == "" || tbLastName.Text == "" || tbPatronymic.Text == "" || tbPassword.Text == "" || tbUsername.Text == "")
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
            Account.roleId = 1;

            MainWindow.connection.Accounts.Add(Account);
            MainWindow.connection.SaveChanges();
        }
    }

}
