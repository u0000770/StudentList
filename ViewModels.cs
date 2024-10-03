using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentList
{
    public class CourseViewModel
    {
        public string course { get; set; }
        public double mark { get; set; }
    }

    public class StudentViewModel
    {
        public string course { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public double mark { get; set; }
        public int year { get; set; }
        public bool? IsAbove80 { get; set; }
    }

    public class EnrolmentYearViewModel
    {
        public int year { get; set; }
        public int count { get; set; }
    }
}
