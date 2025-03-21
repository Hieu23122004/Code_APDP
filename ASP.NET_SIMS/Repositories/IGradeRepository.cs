using SIMS.Models;

namespace ASP.NET_SIMS.Repositories
{
    public interface IGradeRepository
    {
        Task AddGrade(Grade grade);
        void AssignGrade(int enrollmentID, int facultyID, double score);
    }
}
