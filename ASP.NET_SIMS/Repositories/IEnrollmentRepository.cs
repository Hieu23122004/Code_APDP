using SIMS.Models;

namespace ASP.NET_SIMS.Repositories
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Enrollment>> GetEnrollmentsByCourse(int courseId);

    }
}
