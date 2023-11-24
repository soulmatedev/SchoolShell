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
    public partial class Authorization : Page
    {
        private readonly Database.SchoolShellEntities database;
        public Database.Account Account { get; set; }
        public Authorization(Database.SchoolShellEntities entities)
        {
            InitializeComponent();
            Account = new Database.Account();
            database = entities;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tbUsername.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show("Поля пустые",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            Account.username = tbUsername.Text.Trim();
            Account.password = tbPassword.Text.Trim();
            Account.roleId = 1;

            if (MainWindow.connection.Accounts.Any(x => x.username == Account.username && x.password == Account.password))
            {
                MainWindow.pageContainer.Navigate(PageController.schoolShell);
            }
            else
            {
                MessageBox.Show("не найдено",
                   "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
