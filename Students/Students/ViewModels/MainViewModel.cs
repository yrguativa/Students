using System;
using System.Collections.Generic;
using System.Text;

namespace Students.ViewModels
{
    public class MainViewModel
    {
        public RegisterStudentsViewModel RegisterStudents { get; set; }

        public MainViewModel()
        {
            RegisterStudents = new RegisterStudentsViewModel();
        }

        #region Singleton
        public static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }

            return instance;
        }
        #endregion
    }
}
