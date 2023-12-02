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
            var accounts = database.Accounts.Where(x => x.Role.name != "Студент").ToList();
            foreach(var account in accounts)
            {
                MainWindow.Accounts.Add(account);
            }
            binding.Source = MainWindow.Accounts;
            lvAccounts.SetBinding(ListView.ItemsSourceProperty, binding);

        }

        public Database.Account GetSelected()
        {
            return lvAccounts.SelectedItem as Database.Account;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.pageContainer.Navigate(PageController.UserCreator);
        }

        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            var selectedAccount = GetSelected();
            if (selectedAccount == null) return;
            MainWindow.Accounts.Remove(selectedAccount);

            database.Accounts.Remove(selectedAccount);
            database.SaveChanges();
        }

        public void Change(Database.Account account)
        {
            PageController.UserEditor.SetAccount(account);
            NavigationService.Navigate(PageController.UserEditor);
        }

        private void OnClickEdit(object sender, RoutedEventArgs e)
        {
            var selectedAccount = GetSelected();
            if (selectedAccount == null) return;

            Change(selectedAccount);
        }
        private void Button_GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}   
