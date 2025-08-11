using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        #region Fields
        private readonly ApplicationDBContext _context;
        #endregion

        #region Constructors
        public StudentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        #endregion

        #region Handles Functions
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _context.Students
                .Include(d=>d.Department)
                .ToListAsync();
        }
        #endregion

        
    }
}
