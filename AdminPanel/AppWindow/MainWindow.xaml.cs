using AdminPanel.AppPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace AdminPanel
{
    public partial class MainWindow : Window
    {
        public static Database.SchoolShellEntities connection;
        public static ObservableCollection<Database.Account> Accounts { get; set; }
        public static ObservableCollection<Database.Role> Role { get; set; }

        public static Frame pageContainer;
        public MainWindow()
        {
            InitializeComponent();
            connection= new Database.SchoolShellEntities();
            pageContainer = AppFrame;
            Accounts= new ObservableCollection<Database.Account>();
            Role= new ObservableCollection<Database.Role>();
            if (connection.Accounts.FirstOrDefault(x => x.roleId == 1) == null)
            {
                AppFrame.Navigate(AppPages.PageController.AdminCreator);
            }
            else
            {
                AppFrame.Navigate(AppPages.PageController.Authorization);
            }

        }

    }
}
