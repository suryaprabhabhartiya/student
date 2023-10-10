
namespace student.Service
{
    public interface IStudentServices
    {
        List<Student> GetStudentList();
        List<Student> SaveStudentS(List<Student> studentList);
    }
}
