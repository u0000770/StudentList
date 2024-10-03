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

        public static IEnumerable<CourseViewModel> AverageMarkByCourse(List<Student> StudentList)
        {
            return StudentList
                            .GroupBy(s => s.Course)
                            .Select(g => new CourseViewModel
                            {
                                course = g.Key,
                                mark = g.Average(s => s.Mark)
                            });
        }

        //public static IOrderedEnumerable<Student> FilterbyCourseSortbyMark(List<Student> StudentList,string Course)
        //{
        //    return StudentList
        //                    .Where(s => s.Course == Course)
        //                    .OrderByDescending(s => s.Mark);
        //}

        public static List<StudentViewModel> FilterbyCourseSortbyMark(List<Student> StudentList, string Course)
        {
            return StudentList
                .Where(s => s.Course == Course)    // Filter by course
                .OrderByDescending(s => s.Mark)    // Sort by mark in descending order
                .Select(s => new StudentViewModel   // Project each student into CourseViewModel
                {
                    name = s.Surname,
                    mark = s.Mark
                })
                .ToList(); // Convert to a list
        }

        public static List<StudentViewModel> GetStudentsOlderThan(List<Student> StudentList, int ageThreshold)
        {
            return StudentList
                .Where(s => s.Age > ageThreshold)      // Filter by age
                .OrderByDescending(s => s.Mark)        // Sort by mark in descending order
                .Select(s => new StudentViewModel      // Project to StudentViewModel
                {       
                    name = $"{s.Forenames} {s.Surname}", // Combine forenames and surname for name
                    mark = s.Mark,
                })
                .ToList(); // Convert to list
        }

        public static List<StudentViewModel> GetTopStudentsByMark(List<Student> StudentList, int topN)
        {
            return StudentList
                .OrderByDescending(s => s.Mark)        // Sort by mark in descending order
                .Take(topN)                            // Take the top N students
                .Select(s => new StudentViewModel      // Project to StudentViewModel
                {
                    name = $"{s.Forenames} {s.Surname}", // Combine forenames and surname for name
                    mark = s.Mark,
                })
                .ToList(); // Convert to list
        }



        public static List<StudentViewModel> GetStudentsWithMarksInRange(List<Student> StudentList, double minMark, double maxMark)
        {
            return StudentList
                .Where(s => s.Mark >= minMark && s.Mark <= maxMark) // Filter by mark range
                .OrderBy(s => s.Mark)                              // Sort by mark in ascending order
                .Select(s => new StudentViewModel                  // Project to StudentViewModel
                {
                    course = s.Course,
                    name = $"{s.Forenames} {s.Surname}",           // Combine forenames and surname
                    age = s.Age,
                    mark = s.Mark,
                    IsAbove80 = s.Mark > 80                        // Determine if the mark is above 80
                })
                .ToList(); // Convert to list
        }

        public static List<StudentViewModel> StudentsEnrolledAfterYear(List<Student> StudentList, int year)
        {
            return StudentList
                .Where(s => s.EnrolmentYear > year)    // Filter by enrolment year
                .OrderBy(s => s.EnrolmentYear)         // Sort by enrolment year
                .Select(s => new StudentViewModel      // Project to StudentViewModel
                {
                    name = $"{s.Forenames} {s.Surname}", // Combine forenames and surname into name
                    year = year
                })
                .ToList(); // Convert to a list
        }

  
    }

   

}
