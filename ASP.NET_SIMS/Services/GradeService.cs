using ASP.NET_SIMS.Repositories;
using SIMS.Models;

namespace ASP.NET_SIMS.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;

        public GradeService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }


        void IGradeService.AssignGrade(int enrollmentID, int facultyID, double score)
        {
            _gradeRepository.AssignGrade(enrollmentID, facultyID, score);
        }

        object IGradeService.GetAll()
        {
            throw new NotImplementedException();
        }
    }

}
