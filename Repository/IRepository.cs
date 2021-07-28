using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public interface IRepository
    {
        public IEnumerable<Student> GetStudents();
        public IEnumerable<Standard> GetStandards();
        public Task<string> AddStudent(Student std);

        public Task<string> DeleteStudent(int id);

        public Task<string> UpdateStudent(Student std);
    }
       
}
