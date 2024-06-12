using Microsoft.EntityFrameworkCore;
using Escola.Data;
using Escola.Models;

namespace Escola.Repositories
{
    public class StudentRepository
    {
        private readonly SchoolDBContext _dbContext;

        public StudentRepository(SchoolDBContext schoolDBContext)
        {
            _dbContext = schoolDBContext;
        }

        public async Task<List<StudentModel>> GetAllStudents()
        {
            return await _dbContext.Students.ToListAsync();
        }
    }
}
