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
    public partial class HeadTeacherPage : Page
    {
        public HeadTeacherPage()
        {
            InitializeComponent();
        }

        private void onTeacherPage(object sender, RoutedEventArgs e)
        {
            MainWindow.pageContainer.Navigate(PageController.TeacherPage);
        }
    }
}
