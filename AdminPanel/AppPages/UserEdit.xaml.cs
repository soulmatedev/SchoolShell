﻿using System;
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

namespace AdminPanel.AppPages
{
    public partial class UserEdit : Page
    {
        private readonly Database.SchoolShellEntities database;

        public UserEdit(Database.SchoolShellEntities entities)
        {
            InitializeComponent();
            database = entities;

            cbRoles.SetBinding(ItemsControl.ItemsSourceProperty, new Binding()
            {
                Source = new ObservableCollection<Database.Role>(database.Roles)
            });
        }

        public void SetAccount(Database.Account account)
        {
            DataContext = account;
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            database.SaveChanges();
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void Button_GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
