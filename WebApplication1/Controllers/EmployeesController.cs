
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Model;
using WebApplication1.Model.Entities;


namespace WebApplication1.Controllers
{
    //
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            //var allEmployees= dbContext.employees.ToList();
            // return Ok(allEmployees);
           
            return Ok(dbContext.employees.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeesById(Guid id)
        {
            var employee = dbContext.employees.Find(id);
            if (employee == null)
            {

                return NotFound();
            }
            return Ok(employee);

        }

        [HttpPost]
        public IActionResult AddEmployees(AddEmployeeDto addEmployeeDto)
        {
            var employeeentity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };
            dbContext.employees.Add(employeeentity);
            dbContext.SaveChanges();
            return Ok(employeeentity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee=dbContext.employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.Name = updateEmployeeDto.Name;
            employee.Email = updateEmployeeDto.Email;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Salary = updateEmployeeDto.Salary;
            //dbContext.employees.Update(employee);
            dbContext.SaveChanges();
            return Ok(employee);    
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployees(Guid id)
        {
            var emp=dbContext.employees.Find(id);
            if (emp == null)
            {
                return NotFound();  
            }
            dbContext.employees.Remove(emp);
            dbContext.SaveChanges();
            return Ok(emp);
        }
    }
}
