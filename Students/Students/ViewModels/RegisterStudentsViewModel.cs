using GalaSoft.MvvmLight.Command;
using Students.Models;
using Students.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Students.ViewModels
{
    public class RegisterStudentsViewModel : Student, INotifyPropertyChanged
    {
        #region Services
        private ApiService apiService;
        #endregion


        #region Attributes
        private bool isRunning;
        private bool isEnabled;
        private int sizeActivity;
        private List<CourseResponse> cursesResponse;
        private CourseResponse courseSelect;
        #endregion
        #region Properties        
        public bool IsRunning
        {
            get { return this.isRunning; }
            set
            {
                if (isRunning != value)
                {
                    isRunning = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsRunning"));
                }
            }
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set
            {
                if (isEnabled != value)
                {
                    isEnabled = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsEnabled"));
                }
            }
        }
        public int SizeActivity
        {
            get { return this.sizeActivity; }
            set
            {
                if (sizeActivity != value)
                {
                    sizeActivity = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SizeActivity"));
                }

            }
        }
        public List<CourseResponse> CoursesResponse
        {
            get
            {
                return this.cursesResponse;
            }
            set
            {
                if (cursesResponse != value)
                {
                    cursesResponse = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CoursesResponse"));
                }

            }
        }

        public CourseResponse CourseSelect
        {
            get { return this.courseSelect; }
            set
            {
                if (courseSelect != value)
                {
                    courseSelect = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CourseSelect"));
                }

            }
        }
        #endregion
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public RegisterStudentsViewModel()
        {
            IsEnabled = true;
            IsRunning = false;
            SizeActivity = 0;
            apiService = new ApiService();
            LoadCurses();
        }
        #endregion

        #region Methods
        private async void LoadCurses()
        {
            try
            {
                var response = await apiService.GetList<CourseResponse>(
                 "http://18.216.244.210/Students/",
                 "api/",
                 "Curses");

                if (response == null || !response.IsSuccess || response.Result == null)
                {
                    IsRunning = false;
                    IsEnabled = true;
                    SizeActivity = 0;
                    await Application.Current.MainPage.DisplayAlert(
                            "Error",
                            "Los datos de acceso proporcionados no son válidos",
                            "Aceptar");
                    return;
                }
                CoursesResponse = (List<CourseResponse>)response.Result;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(
                             "Error",
                             ex.ToString(),
                             "Aceptar");
            }

        }
        #endregion

        #region Commands
        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(Register);
            }
        }

        private async void Register()
        {
            IsEnabled = false;
            IsRunning = true;
            SizeActivity = 30;

            if (string.IsNullOrEmpty(Names))
            {
                IsEnabled = true;
                IsRunning = false;
                SizeActivity = 0;
                await Application.Current.MainPage.DisplayAlert(
                             "Error",
                             "Los nombres son requeridos",
                             "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(Surnames))
            {
                IsEnabled = true;
                IsRunning = false;
                SizeActivity = 0;
                await Application.Current.MainPage.DisplayAlert(
                             "Error",
                             "Los apellidos son requeridos",
                             "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(IdentificationNumber))
            {
                IsEnabled = true;
                IsRunning = false;
                SizeActivity = 0;
                await Application.Current.MainPage.DisplayAlert(
                             "Error",
                             "El número de identificación es requerido",
                             "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(IdentificationType))
            {
                IsEnabled = true;
                IsRunning = false;
                SizeActivity = 0;
                await Application.Current.MainPage.DisplayAlert(
                             "Error",
                             "El tipo de identificación es requerido",
                             "Aceptar");
                return;
            }
            if (CourseSelect == null)
            {
                IsEnabled = true;
                IsRunning = false;
                SizeActivity = 0;
                await Application.Current.MainPage.DisplayAlert(
                             "Error",
                             "El curso es requerido",
                             "Aceptar");
                return;
            }
            var curso = CoursesResponse.Where(c => c.Course == CourseSelect.Course).ToList();
            var studentRequest = new Student()
            {
                Names = this.Names,
                Surnames = this.Surnames,
                IdentificationType = this.IdentificationType,
                IdentificationNumber = this.IdentificationNumber,
                BirthDate = this.BirthDate,
                Curses = curso
            };

            var response = await apiService.Post<Student>(
                "http://18.216.244.210/Students/",
                "api/",
                "Students",
                studentRequest
                );       

            if (response == null || !response.IsSuccess || response.Result == null)
            {
                IsRunning = false;
                IsEnabled = true;
                SizeActivity = 0;
                await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "Los datos de acceso proporcionados no son válidos",
                        "Aceptar");
                return;
            }
            Names = string.Empty;
            Surnames = string.Empty;
            IdentificationType = string.Empty;
            IdentificationNumber = string.Empty;
            CourseSelect = null;
            await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        "El estudiante se guardo satisfactoriament",
                        "Aceptar");
            IsEnabled = true;
            IsRunning = false;
            SizeActivity = 0;
        }
        #endregion
    }
}
