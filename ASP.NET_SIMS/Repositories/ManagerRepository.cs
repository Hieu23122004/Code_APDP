using ASP.NET_SIMS.Data;
using ASP.NET_SIMS.Repositories;
using SIMS.Models;

public class GradeRepository : IGradeRepository
{
    private readonly AppDbContext _context;

    public GradeRepository(AppDbContext context)
    {
        _context = context;
    }



    Task IGradeRepository.AddGrade(Grade grade)
    {
        throw new NotImplementedException();
    }

    void IGradeRepository.AssignGrade(int enrollmentID, int facultyID, double score)
    {
        var grade = new Grade
        {
            EnrollmentID = enrollmentID,
            FacultyID = facultyID,
            Score = score
        };

        _context.Grades.Add(grade);
        _context.SaveChanges();
    }
}
