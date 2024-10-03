using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        public string Surname { get; set; }
        public string Forenames { get; set; }
        public int Age { get; set; }
        public string Course { get; set; }
        public double Mark { get; set; }
        public int EnrolmentYear { get; set; }


        public static IEnumerable<EnrolmentYearViewModel> CountByEnrolmentYear(List<Student> StudentList)
        {
            return StudentList
            .GroupBy(s => s.EnrolmentYear)
            .Select(g => new EnrolmentYearViewModel
            {
                year = g.Key,
                count = g.Count()
            });
        }

        public static List<StudentViewModel> YoungestStudentPerCourse(List<Student> StudentList)
        {
            return StudentList
                        .GroupBy(s => s.Course)
                        .Select(g => g.OrderBy(s => s.Age).First())
                        .Select(s => new StudentViewModel
                        {
                            course = s.Course,
                            name = s.Surname,
                            age = s.Age
                        }).ToList();
        }

        public static IEnumerable<CourseViewModel> AverageMarkbyCourse(List<Student> StudentList)
        {
            return StudentList
                            .GroupBy(s => s.Course)
                            .Select(g => new CourseViewModel
                            {
                                course = g.Key,
                                averageMark = g.Average(s => s.Mark)
                            });
        }

        public static IOrderedEnumerable<Student> FilterbyCourseSortbyMark(List<Student> StudentList)
        {
            return StudentList
                            .Where(s => s.Course == "Computer Science")
                            .OrderByDescending(s => s.Mark);
        }

        public static IOrderedEnumerable<Student> StudentsEnrolledAfterYear(List<Student> StudentList, int year)
        {
            return StudentList
                            .Where(s => s.EnrolmentYear > year)
                            .OrderBy(s => s.EnrolmentYear);
        }
    }

   

}
