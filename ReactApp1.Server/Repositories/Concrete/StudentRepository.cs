using ReactApp1.Server.Data;
using ReactApp1.Server.Entities;
using System.Linq.Expressions;
using ReactApp1.Server.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ReactApp1.Server.Repositories.Concrete
{
    public class StudentRepository:IStudentRepository
    {
        private readonly StudentDbContext _context;

        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<Student> Add(Student entity)
        {
            await _context.Students.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(Student entity)
        {
            await Task.Run(() =>
            {
                _context.Students.Remove(entity);
            });
            return await _context.SaveChangesAsync(true) > 0;
        }

        public async Task<Student> Get(Expression<Func<Student, bool>> predicate)
        {
            return await _context.Students.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task Update(Student entity)
        {
            await Task.Run(() =>
            {
                _context.Students.Update(entity);
            });
            await _context.SaveChangesAsync();
        }
    }
}

