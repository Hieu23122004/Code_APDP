using SIMS.Models;

namespace ASP.NET_SIMS.Repositories
{
    public class EnrollmentRepository
    {
        IEnumerable<Enrollment> GetAll();
        Enrollment GetById(int id);
        void Add(Enrollment enrollment);
        void Update(Enrollment enrollment);
        void Delete(int id);
    }
}
