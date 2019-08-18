using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {        
        private readonly APIContext _context;

        public EmployeeController(APIContext context)
        {
            _context = context;
        }
        //GET:      api/Employee
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployee()
        {
            return _context.Employee;
        }

        // GET api/Employee/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var Emp = _context.Employee.Find(id);

            if (Emp == null)
            {
                return NotFound();
            }
            return Emp;
        }


        // POST api/Employee
        [HttpPost]
        public ActionResult<Employee> PostEmployee([FromBody]Employee Emp)
        {
            _context.Employee.Add(Emp);
            _context.SaveChanges();

            return CreatedAtAction("GetEmployeeById", new Employee { Id = Emp.Id }, Emp);
        }


        // PUT api/Employee/5
        [HttpPut("{id}")]
        public ActionResult PutEmployee(int id, [FromBody]Employee Emp)
        {
            if (id != Emp.Id)
            {
                return BadRequest();
            }

            _context.Entry(Emp).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE api/Employee/5
        [HttpDelete("{id}")]
        public ActionResult<Employee> DeleteEmployee(int id)
        {
            var Emp = _context.Employee.Find(id);

            if (Emp == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(Emp);
            _context.SaveChanges();

            return Emp;
        }
    }
}
