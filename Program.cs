
namespace StudentList
{
   

    class Program
    {
        static void Main()
        {
            // Sample data
        List<Student> StudentList = new List<Student>
        {
            new Student { Surname = "Smith", Forenames = "John", Age = 20, Course = "Computer Science", Mark = 85, EnrolmentYear = 2021 },
            new Student { Surname = "Doe", Forenames = "Jane", Age = 22, Course = "Mathematics", Mark = 78, EnrolmentYear = 2020 },
            new Student { Surname = "Brown", Forenames = "Alice", Age = 19, Course = "Computer Science", Mark = 90, EnrolmentYear = 2019 },
            new Student { Surname = "Jones", Forenames = "Bob", Age = 21, Course = "Engineering", Mark = 70, EnrolmentYear = 2021 },
            new Student { Surname = "Taylor", Forenames = "Chris", Age = 23, Course = "Mathematics", Mark = 82, EnrolmentYear = 2022 },
            new Student { Surname = "Wilson", Forenames = "Emma", Age = 20, Course = "Engineering", Mark = 88, EnrolmentYear = 2022 }
        };

            // 1. Filter by Course and Sort by Mark
            var message = "1. Computer Science Students sorted by Mark:";
            List<StudentViewModel> compSciStudents = Student.FilterbyCourseSortbyMark(StudentList,"Computer Science");
            DisplayStudentMarks(compSciStudents,message);

            // 2. Find Students Enrolled After a Certain Year
            List<StudentViewModel> studentsEnrolledAfter2020 = Student.StudentsEnrolledAfterYear(StudentList, 2020);
            Console.WriteLine("\n2. Students enrolled after 2020:");
            foreach (var student in studentsEnrolledAfter2020)
                Console.WriteLine($"{student.name}, {student.year}");

            // 3. Calculate Average Mark by Course
            IEnumerable<CourseViewModel> avgMarkByCourse = Student.AverageMarkByCourse(StudentList);

            Console.WriteLine("\n3. Average Mark by Course:");
            foreach (var course in avgMarkByCourse)
                Console.WriteLine($"{course.course}: {course.mark}");

            // 4. Find the Youngest Student in Each Course
            IEnumerable<StudentViewModel> vm = Student.YoungestStudentPerCourse(StudentList);
            Console.WriteLine("\n4. Youngest Student in Each Course:");
            foreach (var student in vm)
                Console.WriteLine($"{student.course}: {student.name}, {student.age}");

            // 5. Count Students by Enrolment Year
            IEnumerable<EnrolmentYearViewModel> enrolmentYearViewModels = Student.CountByEnrolmentYear(StudentList);
            Console.WriteLine("\n5. Count of Students by Enrolment Year:");
            foreach (var year in enrolmentYearViewModels)
                Console.WriteLine($"{year.year}: {year.count}");

            // 6. Find Students with Marks in a Specific Range
            var studentsWithMarksInRange = Student.GetStudentsWithMarksInRange(StudentList, 70, 85);
            DisplayStudentMarks(studentsWithMarksInRange, "\n6. Students with Marks between 70 and 85:");


            // 7. Filter by Age and Sort by Mark
            var studentsOlderThan21 = Student.GetStudentsOlderThan(StudentList, 21);
            DisplayStudentMarks(studentsOlderThan21, "\n7. Students older than 21 sorted by Mark:");
      

            // 8. Find Top N Students by Mark
            var top3StudentsByMark = Student.GetTopStudentsByMark(StudentList, 3);
            DisplayStudentMarks(top3StudentsByMark, "\n8. Top 3 Students by Mark:");

            // 9. Select and Transform Data
            var transformedData = StudentList
                .Select(s => new StudentViewModel
                {
                    name = $"{s.Forenames} {s.Surname}",
                    course = s.Course,
                    IsAbove80 = s.Mark > 80
                });
            Console.WriteLine("\n9. Transformed Data (with boolean for mark > 80):");
            foreach (var student in transformedData)
                Console.WriteLine($"{student.name}, {student.course}, Above 80: {student.IsAbove80}");

            // 10. Aggregate Data
            var totalStudents = StudentList.Count();
            var averageAge = StudentList.Average(s => s.Age);
            var highestMark = StudentList.Max(s => s.Mark);

            // Calculate years and months from averageAge
            int years = (int)averageAge; // Extract full years
            int months = (int)((averageAge - years) * 12); // Calculate months from the fractional part

            Console.WriteLine("\n10. Aggregated Data:");
            Console.WriteLine($"Total Students: {totalStudents}, Average Age: {years} years and {months} months, Highest Mark: {highestMark}");
        }

        private static void DisplayStudentMarks(List<StudentViewModel> compSciStudents,string message)
        {
            Console.WriteLine(message);
            foreach (var student in compSciStudents)
                Console.WriteLine($"{student.name}, {student.mark}");
        }





    }
}
