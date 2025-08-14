using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Repositories
{
    public class StudentRepository :GenericRepositoryAsync<Student>,IStudentRepository
    {
        #region Fields
        private readonly DbSet<Student> _students;
        #endregion

        #region Constructors
        public StudentRepository(ApplicationDBContext context) : base(context)
        {
            _students = context.Set<Student>();
        }
        #endregion

        #region Handles Functions
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _students
                .Include(d=>d.Department)
                .ToListAsync();
        }

        
        #endregion


    }
}
