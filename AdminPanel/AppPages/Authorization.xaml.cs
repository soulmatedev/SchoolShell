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
        const int ROLE_ID_ADMIN = 1;
        const int ROLE_ID_STUDENT = 2;
        const int ROLE_ID_HEADTEACHER = 3;
        const int ROLE_ID_TEACHER = 4;
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

            if (database.Accounts.FirstOrDefault(x => x.username == Account.username && x.password == Account.password && x.roleId == ROLE_ID_ADMIN) != null)
            {
                MainWindow.pageContainer.Navigate(PageController.SchoolShell);
            }
            else if (database.Accounts.FirstOrDefault(x => x.username == Account.username && x.password == Account.password && x.roleId == ROLE_ID_TEACHER) != null)
            {
                MainWindow.pageContainer.Navigate(PageController.TeacherPage);
            }
            else if (database.Accounts.FirstOrDefault(x => x.username == Account.username && x.password == Account.password && x.roleId == ROLE_ID_HEADTEACHER) != null)
            {
                MainWindow.pageContainer.Navigate(PageController.HeadTeacherPage);
            }
            else
            {
                MessageBox.Show("не найдено",
                   "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
