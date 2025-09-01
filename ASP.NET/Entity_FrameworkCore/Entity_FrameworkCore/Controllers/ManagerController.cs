using Entity_FrameworkCore.Data;
using Entity_FrameworkCore.ModelDto;
using Entity_FrameworkCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Entity_FrameworkCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ManagerController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("Transaction")]
        public IActionResult Transaction()
        {
            var transaction=_context.Database.BeginTransaction();
            var manager = _context.Managers.FirstOrDefault(m => m.ManagerId == 1);

            if (manager != null)
            {
                try
                {
                    manager.Man_FName = "Riaz";
                    manager.Man_LName = "Mehadi";
                    _context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
            return Ok();
        }

        [HttpGet("allLoading")]
        public IActionResult AllLoading()
        {
            // Eager loading
            var employee = _context.Employees.Include(e => e.EmployeeDetails).ToList();

            foreach (var emp in employee) {
                Console.WriteLine($"Id={emp.EmployeeDetails.EmployeeId} Name={emp.Emp_FName} Address={emp.EmployeeDetails.Address}"); 
            } 

            var projects = _context.projects.Include(p => p.employeeProjects).ThenInclude(e => e.Employee).ToList(); 

            foreach (var project in projects) {
                Console.WriteLine(project.ProjectName);
                foreach (var empPro in project.employeeProjects) {
                    Console.WriteLine(empPro.Employee.Emp_FName); 
                } 
            } 
            //Exlicit Loading
            var employee1 = _context.Employees.Include(e => e.EmployeeDetails).ToList();
            foreach (var emp in employee1) {
                _context.Entry(emp).Reference(e => e.EmployeeDetails).Load();//Reference single entity
                Console.WriteLine($"Id={emp.EmployeeDetails.EmployeeId} Name={emp.Emp_FName} Address={emp.EmployeeDetails.Address}");
            } 
            var managers = _context.Managers.ToList();
            foreach (var manager in managers) {
                _context.Entry(manager).Collection(m => m.Employees).Load();//Collection multiple entity
                foreach (var emp in manager.Employees) {
                    Console.WriteLine($"FirstName={emp.Emp_LName} lastname={emp.Emp_LName}"); 
                } 
            }
            // Lazy Loading
            /*
             step - 1 = Install->Microsoft.EntityFrameWorkCore.Proxies
            
             step - 2 = UseLazyLoadingProxies() 
             protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
             { 
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(ConnectionString); 
             } 
             step-3=>all navigation properties make virtual type 
            */

            return Ok();
        }

        // ✅ Get all managers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var managers = await _context.Managers.ToListAsync();

            if (!managers.Any())
            {
                return NotFound("No managers found.");
            }

            return Ok(managers);
        }

        // ✅ Get manager by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var manager = await _context.Managers.SingleOrDefaultAsync(man => man.ManagerId == id);

            if (manager == null)
            {
                return NotFound("Manager not found.");
            }

            return Ok(manager);
        }

        // ✅ Add new manager
        [HttpPost("add")]
        public async Task<IActionResult> AddData([FromBody] CreateUpdateManagerDto managerDto)
        {
            if (managerDto == null)
            {
                return BadRequest("Manager data is required.");
            }

            var manager = new Manager
            {
                Man_FName = managerDto.Man_FName,
                Man_LName = managerDto.Man_LName
            };

            await _context.Managers.AddAsync(manager);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = manager.ManagerId }, manager);
        }

        // ✅ Update manager
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateData([FromBody] CreateUpdateManagerDto managerDto, [FromRoute] int id)
        {
            if (managerDto == null)
            {
                return BadRequest("Manager data is required.");
            }

            var manager = await _context.Managers.SingleOrDefaultAsync(m => m.ManagerId == id);
            if (manager == null)
            {
                return NotFound("Manager not found.");
            }

            manager.Man_FName = managerDto.Man_FName;
            manager.Man_LName = managerDto.Man_LName;

            await _context.SaveChangesAsync();

            return Ok(manager); // Returning updated manager object
        }

        // ✅ Delete manager
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteData(int id)
        {
            var manager = await _context.Managers.SingleOrDefaultAsync(m => m.ManagerId == id);
            if (manager == null)
            {
                return NotFound("Manager not found.");
            }

            _context.Managers.Remove(manager);
            await _context.SaveChangesAsync();

            return NoContent(); // Standard REST response for delete
        }
    }
}
