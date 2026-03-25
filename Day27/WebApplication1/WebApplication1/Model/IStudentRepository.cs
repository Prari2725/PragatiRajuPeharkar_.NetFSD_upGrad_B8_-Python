namespace WebApplication1.Model
{
    public interface IStudentRepository
    {
        Student GetStudentById(int studentId);
    }
}