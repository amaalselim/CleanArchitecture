﻿using SchoolProject.Data.Entities;

namespace SchoolProject.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetAllStudentsAsync();
        public Task<Student> GetStudentByIdAsync(int id);
        public Task<string> AddAsync(Student student);
        public Task<bool> IsNameExist(string name);
        public Task<bool> IsNameExistExcludeSelf(string name, int id);
    }
}
