using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace AdminPanel.AppPages
{
    public partial class SchoolShell : Page
    {
        private readonly Database.SchoolShellEntities database;
        public SchoolShell(Database.SchoolShellEntities entities)
        {
            InitializeComponent();
            database = entities;

            Binding binding = new Binding();
            binding.Source = MainWindow.Accounts.Where(x => x.Role.name != "Студент");
            lvAccounts.SetBinding(ListView.ItemsSourceProperty, binding);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.pageContainer.Navigate(PageController.userCreator);
        }

    }
}
