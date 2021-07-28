using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public class Repostitory : IRepository
    {
        private ScoolContext _context = null;
        private readonly ILogger _logger = null;

        public Repostitory(ScoolContext context, ILogger<Repostitory> logger)
        {
            _context = context;
            _logger = logger;
        }


        public IEnumerable<Student> GetStudents()
        {

            var student = from s in _context.tbl_Student
                          join st in _context.tbl_Standards
                          on s.StandardRefId equals st.Id
                          // into tab
                          //from x in tab.DefaultIfEmpty()
                          select new Student
                          {
                              Id = s.Id,
                              FirstName = s.FirstName,
                              LastName = s.LastName,
                              Mobile = s.Mobile,
                              StandardRefId = s.StandardRefId,
                              //Standard = st,
                              Description = s.Description
                              ,
                              Email = s.Email

                          };


            return student.ToList();
        }

        public IEnumerable<Standard> GetStandards()
        {

            return _context.tbl_Standards.ToList();

        }

        public async Task<string> AddStudent(Student std)
        {


            try
            {
                //throw new NullReferenceException("Student object is null.");

                await _context.tbl_Student.AddAsync(std);
                await _context.SaveChangesAsync();
                return std.Id.ToString();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error in Repository");
                return exception.Message;
            }

        }


        public async Task<string> DeleteStudent(int id)
        {

            try
            {


                var stud = await _context.tbl_Student.FindAsync(id);
                if (stud != null)
                {
                    _context.tbl_Student.Remove(stud);
                    await _context.SaveChangesAsync();
                    return "success";
                }
                else
                    return "Something went wrong!!";

            }
            catch (Exception ex)
            {

                return ex.Message.ToString();
            }

        }


        public async Task<string> UpdateStudent(Student std)
        {


            try
            {

                
                _context.Entry(std).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return std.Id.ToString();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error in Repository");
                return exception.Message;
            }



        }

    }
}
