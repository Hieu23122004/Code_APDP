namespace ASP.NET_SIMS.Services
{
    public interface IGradeService
    {
        void AssignGrade(int enrollmentID, int facultyID, double score);
        object GetAll();
    }
}
