using EFCore.BulkExtensions;
using student.Context;

namespace student.Service
{
    public class StudentServices : IStudentServices
    {
        DataBaseContext _dbContext = null;

        public StudentServices(DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Student> GetStudentList()
        {
            return _dbContext.Students.ToList();
        }

        public List<Student> SaveStudentS(List<Student> studentList)
        {
            _dbContext.BulkInsert(studentList);
            return studentList;
        }
    }
}
