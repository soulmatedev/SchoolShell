using AdminPanel.AppWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminPanel.AppPages
{
    internal class PageController
    {
        private static Database.SchoolShellEntities database;

        private static AdminCreator adminCreator;
        public static SchoolShell schoolShell;
        private static Authorization authorization;
        private static TeacherPage teacherPage;
        private static HeadTeacherPage headTeacherPage;
        public static UserCreator userCreator;
        private static UserEdit userEditor;

        public static AdminCreator AdminCreator

        {
            get
            {
                if (adminCreator == null)
                {
                    adminCreator = new AdminCreator(Database);
                }
                return adminCreator;
            }
        }

        public static SchoolShell SchoolShell

        {
            get
            {
                if (schoolShell == null)
                {
                    schoolShell = new SchoolShell(Database);
                }
                return schoolShell;
            }
        }
     
        public static Authorization Authorization

        {
            get
            {
                if (authorization == null)
                {
                    authorization = new Authorization(Database);
                }
                return authorization;
            }
        }     

        public static TeacherPage TeacherPage

        {
            get
            {
                if (teacherPage == null)
                {
                    teacherPage = new TeacherPage();
                }
                return teacherPage;
            }
        }
        public static UserCreator UserCreator
        {
            get
            {
                if (userCreator == null)
                {
                    userCreator = new UserCreator(Database);
                }
                return userCreator;
            }
        }

        public static UserEdit UserEditor
        {
            get
            {
                if (userEditor == null)
                {
                    userEditor = new UserEdit(Database);
                }
                return userEditor;
            }
        }

        public static HeadTeacherPage HeadTeacherPage
        {
            get
            {
                if(headTeacherPage == null)
                {
                    headTeacherPage = new HeadTeacherPage();
                }
                return headTeacherPage;
            }
        }

        public static void Reset()
        {
            database = null;
            authorization = null;
            schoolShell = null;
            teacherPage = null;
            userCreator = null;
            userEditor = null;
            headTeacherPage = null;
        }

        private static Database.SchoolShellEntities Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database.SchoolShellEntities();
                    if (database.Database.Exists() == false)
                    {
                        MessageBox.Show("Подключение к базе данных не было выполнено. Приложение будет завершено.",
                            "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                        Application.Current.Shutdown();
                    }
                }
                return database;
            }
        }

    }
}
