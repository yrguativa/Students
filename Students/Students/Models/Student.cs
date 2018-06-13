namespace Students.Models
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        public string Names { get; set; }
      
        public string Surnames { get; set; }

        public string IdentificationType { get; set; }

        public string IdentificationNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public List<CourseResponse> Curses { get; set; }
    }
}
