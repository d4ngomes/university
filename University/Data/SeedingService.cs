using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Models;

namespace University.Data
{
    public class SeedingService
    {
        private readonly AppDbContext _db;
        public SeedingService(AppDbContext db)
        {
            _db = db;
        }

        public void Seed()
        {
            if (_db.Students.Any() || _db.Courses.Any() || _db.Enrollments.Any()) return;

            var students = new List<Student>
            {
                new Student { FirstName = "Carson",   LastName = "Alexander",
                    EnrollmentDate = DateTime.Parse("2020-09-01") },
                new Student { FirstName = "Meredith", LastName = "Alonso",
                    EnrollmentDate = DateTime.Parse("2018-09-01") },
                new Student { FirstName = "Arturo",   LastName = "Anand",
                    EnrollmentDate = DateTime.Parse("2019-09-01") },
                new Student { FirstName = "Gytis",    LastName = "Barzdukas",
                    EnrollmentDate = DateTime.Parse("2020-09-01") },
                new Student { FirstName = "Yan",      LastName = "Li",
                    EnrollmentDate = DateTime.Parse("2017-09-01") },
                new Student { FirstName = "Peggy",    LastName = "Justice",
                    EnrollmentDate = DateTime.Parse("2019-09-01") },
                new Student { FirstName = "Laura",    LastName = "Norman",
                    EnrollmentDate = DateTime.Parse("2020-09-01") },
                new Student { FirstName = "Nino",     LastName = "Olivetto",
                    EnrollmentDate = DateTime.Parse("2018-08-11") }
            };

            students.ForEach(m => _db.Students.Add(m));
            _db.SaveChanges();

            var instructors = new List<Instructor>
            {
                new Instructor { FirstName = "Kim",     LastName = "Abercrombie",
                    HireDate = DateTime.Parse("1995-03-11") },
                new Instructor { FirstName = "Fadi",    LastName = "Fakhouri",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Instructor { FirstName = "Roger",   LastName = "Harui",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Instructor { FirstName = "Candace", LastName = "Kapoor",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Instructor { FirstName = "Roger",   LastName = "Zheng",
                    HireDate = DateTime.Parse("2004-02-12") }
            };

            instructors.ForEach(m => _db.Instructors.Add(m));
            _db.SaveChanges();

            var departments = new List<Department>
            {
                new Department { Name = "English",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = _db.Instructors.FirstOrDefault( i => i.LastName == "Abercrombie").InstructorID },
                new Department { Name = "Mathematics", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = _db.Instructors.FirstOrDefault( i => i.LastName == "Fakhouri").InstructorID },
                new Department { Name = "Engineering", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = _db.Instructors.FirstOrDefault( i => i.LastName == "Harui").InstructorID },
                new Department { Name = "Economics",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    InstructorID  = _db.Instructors.FirstOrDefault( i => i.LastName == "Kapoor").InstructorID }
            };

            departments.ForEach(m => _db.Departments.Add(m));
            _db.SaveChanges();

            var courses = new List<Course>
            {
                new Course {CourseID = 1050, Title = "Chemistry",      Credits = 3,
                  DepartmentID = _db.Departments.FirstOrDefault( s => s.Name == "Engineering").DepartmentID,
                  Instructors = new List<Instructor>()
                },
                new Course {CourseID = 4022, Title = "Microeconomics", Credits = 3,
                  DepartmentID = _db.Departments.FirstOrDefault( s => s.Name == "Economics").DepartmentID,
                  Instructors = new List<Instructor>()
                },
                new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3,
                  DepartmentID = _db.Departments.FirstOrDefault( s => s.Name == "Economics").DepartmentID,
                  Instructors = new List<Instructor>()
                },
                new Course {CourseID = 1045, Title = "Calculus",       Credits = 4,
                  DepartmentID = _db.Departments.FirstOrDefault( s => s.Name == "Mathematics").DepartmentID,
                  Instructors = new List<Instructor>()
                },
                new Course {CourseID = 3141, Title = "Trigonometry",   Credits = 4,
                  DepartmentID = _db.Departments.FirstOrDefault( s => s.Name == "Mathematics").DepartmentID,
                  Instructors = new List<Instructor>()
                },
                new Course {CourseID = 2021, Title = "Composition",    Credits = 3,
                  DepartmentID = _db.Departments.FirstOrDefault( s => s.Name == "English").DepartmentID,
                  Instructors = new List<Instructor>()
                },
                new Course {CourseID = 2042, Title = "Literature",     Credits = 4,
                  DepartmentID = _db.Departments.FirstOrDefault( s => s.Name == "English").DepartmentID,
                  Instructors = new List<Instructor>()
                },
            };

            courses.ForEach(m => _db.Courses.Add(m));
            _db.SaveChanges();

            var officeAssignments = new List<OfficeAssignment>
            {
                new OfficeAssignment {
                    InstructorID = _db.Instructors.FirstOrDefault( i => i.LastName == "Fakhouri").InstructorID,
                    Location = "Smith 17" },
                new OfficeAssignment {
                    InstructorID = _db.Instructors.FirstOrDefault( i => i.LastName == "Harui").InstructorID,
                    Location = "Gowan 27" },
                new OfficeAssignment {
                    InstructorID = _db.Instructors.FirstOrDefault( i => i.LastName == "Kapoor").InstructorID,
                    Location = "Thompson 304" },
            };

            officeAssignments.ForEach(m => _db.OfficeAssignments.Add(m));
            _db.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment {
                    StudentID = _db.Students.FirstOrDefault(s => s.LastName == "Alexander").StudentID,
                    CourseID = courses.FirstOrDefault(c => c.Title == "Chemistry" ).CourseID,
                    Grade = Grade.A
                },
                 new Enrollment {
                    StudentID = _db.Students.FirstOrDefault(s => s.LastName == "Alexander").StudentID,
                    CourseID = courses.FirstOrDefault(c => c.Title == "Microeconomics" ).CourseID,
                    Grade = Grade.C
                 },
                 new Enrollment {
                    StudentID = _db.Students.FirstOrDefault(s => s.LastName == "Alexander").StudentID,
                    CourseID = courses.FirstOrDefault(c => c.Title == "Macroeconomics" ).CourseID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                     StudentID = _db.Students.FirstOrDefault(s => s.LastName == "Alonso").StudentID,
                    CourseID = courses.FirstOrDefault(c => c.Title == "Calculus" ).CourseID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                     StudentID = _db.Students.FirstOrDefault(s => s.LastName == "Alonso").StudentID,
                    CourseID = courses.FirstOrDefault(c => c.Title == "Trigonometry" ).CourseID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                    StudentID = _db.Students.FirstOrDefault(s => s.LastName == "Alonso").StudentID,
                    CourseID = courses.FirstOrDefault(c => c.Title == "Composition" ).CourseID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                    StudentID = _db.Students.FirstOrDefault(s => s.LastName == "Anand").StudentID,
                    CourseID = courses.FirstOrDefault(c => c.Title == "Chemistry" ).CourseID
                 },
                 new Enrollment {
                    StudentID = _db.Students.FirstOrDefault(s => s.LastName == "Anand").StudentID,
                    CourseID = courses.FirstOrDefault(c => c.Title == "Microeconomics").CourseID,
                    Grade = Grade.B
                 },
                new Enrollment {
                    StudentID = _db.Students.FirstOrDefault(s => s.LastName == "Barzdukas").StudentID,
                    CourseID = courses.FirstOrDefault(c => c.Title == "Chemistry").CourseID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                    StudentID = _db.Students.FirstOrDefault(s => s.LastName == "Li").StudentID,
                    CourseID = courses.FirstOrDefault(c => c.Title == "Composition").CourseID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                    StudentID = _db.Students.FirstOrDefault(s => s.LastName == "Justice").StudentID,
                    CourseID = courses.FirstOrDefault(c => c.Title == "Literature").CourseID,
                    Grade = Grade.B
                 }
            };

            enrollments.ForEach(m => _db.Enrollments.Add(m));

            AddCourseInstructor(_db, "Chemistry", "Kapoor");
            AddCourseInstructor(_db, "Chemistry", "Harui");
            AddCourseInstructor(_db, "Microeconomics", "Zheng");
            AddCourseInstructor(_db, "Macroeconomics", "Zheng");
            AddCourseInstructor(_db, "Calculus", "Fakhouri");
            AddCourseInstructor(_db, "Trigonometry", "Harui");
            AddCourseInstructor(_db, "Composition", "Abercrombie");
            AddCourseInstructor(_db, "Literature", "Abercrombie");

            _db.SaveChanges();

            void AddCourseInstructor(AppDbContext _db, string courseTitle, string instructorName)
            {
                var course = _db.Courses.SingleOrDefault(c => c.Title == courseTitle);
                course.Instructors.Add(_db.Instructors.Single(i => i.LastName == instructorName));
            }

        }
    }
}
