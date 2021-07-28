using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;
using WebAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolAPIController : ControllerBase
    {

        private IRepository _repository = null;
       
        public SchoolAPIController(IRepository repository)
        {
            _repository = repository;
        }



        // GET: api/<SchoolAPIController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {

            return _repository.GetStudents();

        }


        [HttpGet]
         [ Route("standard")]
        public IEnumerable<Standard> GetStandard()
        {

            return _repository.GetStandards();

        }


        // GET api/<SchoolAPIController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _repository.GetStudents().Where(x => x.Id == id).FirstOrDefault();
        }

        // POST api/<SchoolAPIController>
        [HttpPost]
        public async Task<string> AddStudent(Student student)
        {
            var x = await _repository.AddStudent(student);
            return x.ToString();
        }

        // PUT api/<SchoolAPIController>/5
        [HttpPut]
        public async Task<string> Put(Student student)
        {
            var x = await _repository.UpdateStudent(student);
            return x.ToString();
        
      
        }

        // DELETE api/<SchoolAPIController>/5
        [HttpDelete("Delete/{id}")]
        public async Task<string> Delete(int id)
        {
            var result = await _repository.DeleteStudent(id);

            if (!string.IsNullOrEmpty(result))
                return result;
            else
                return "Data does not exost";
        }
    }
}
