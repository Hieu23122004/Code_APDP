using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SIMS.Models;
using ASP.NET_SIMS.Data;
using ASP.NET_SIMS.Models;

namespace ASP.NET_SIMS.Repositories
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly ApplicationDbContext _context;

        public FacultyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy danh sách tất cả giảng viên
        public IEnumerable<Faculty> GetAll()
        {
            return _context.Faculties.ToList();
        }

        // Lấy thông tin giảng viên theo ID
        public Faculty GetById(int id)
        {
            return _context.Faculties.Find(id);
        }

        // Thêm giảng viên mới
        public void Add(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
            _context.SaveChanges();
        }

        // Cập nhật thông tin giảng viên
        public void Update(Faculty faculty)
        {
            _context.Faculties.Update(faculty);
            _context.SaveChanges();
        }

        // Xóa giảng viên theo ID
        public void Delete(int id)
        {
            var faculty = _context.Faculties.Find(id);
            if (faculty != null)
            {
                _context.Faculties.Remove(faculty);
                _context.SaveChanges();
            }
        }
    }
}
