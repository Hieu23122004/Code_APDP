using ASP.NET_SIMS.Data;
using ASP.NET_SIMS.Models;
using ASP.NET_SIMS.Services;

using System.Collections.Generic;
using System.Linq;

public class StudentService : IStudentService
{
    private readonly AppDbContext _context;

    public StudentService(AppDbContext context)
    {
        _context = context;
    }

    public List<Student> GetAllStudents()
    {
        return _context.Students.ToList();
    }

    public void AddStudent(Student student)
    {
        // Kiểm tra xem UserID có tồn tại trong bảng Users không
        var userExists = _context.Users.Any(u => u.Id == student.UserID);
        if (!userExists)
        {
            throw new Exception("UserID không tồn tại trong hệ thống.");
        }

        // Kiểm tra xem UserID đã tồn tại trong bảng Students chưa
        var studentExists = _context.Students.Any(s => s.UserID == student.UserID);
        if (studentExists)
        {
            throw new Exception("UserID đã được sử dụng cho một sinh viên khác.");
        }

        // Nếu cả hai điều kiện trên đều thỏa mãn, thêm sinh viên mới vào bảng Students
        _context.Students.Add(student);
        _context.SaveChanges();
    }


    public void UpdateStudent(Student student)
    {
        var existingStudent = _context.Students.Find(student.StudentID);
        if (existingStudent != null)
        {
            existingStudent.FullName = student.FullName;
            existingStudent.DateOfBirth = student.DateOfBirth;
            existingStudent.Address = student.Address;
            existingStudent.PhoneNumber = student.PhoneNumber;
            _context.SaveChanges();
        }
    }

    public void DeleteStudent(int id)
    {
        var student = _context.Students.Find(id);
        if (student != null)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }
}
