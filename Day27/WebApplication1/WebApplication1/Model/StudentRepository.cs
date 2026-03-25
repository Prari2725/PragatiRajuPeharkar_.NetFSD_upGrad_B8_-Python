using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Model
{
    public class StudentRepository : IStudentRepository
    {
        public List<Student> Students()
        {
            return new List<Student>()
            {
                new Student() { StudentId = 101, Name = "Pragati", Age = 30 },
                new Student() { StudentId = 102, Name = "Amit", Age = 20 },
                new Student() { StudentId = 103, Name = "Ankit", Age = 22 }
            };
        }

        public Student GetStudentById(int studentId)
        {
            return Students().FirstOrDefault(a => a.StudentId == studentId) ?? new Student();
        }
    }
}