using EmployerPortal.Data;
using EmployerPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployerPortal.Repository
{
    public class EmployeeRepository
    {
        private readonly AppDbContext db;

        public EmployeeRepository(AppDbContext dbContext)
        {
            this.db = dbContext;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await db.Employees.ToListAsync();
        }
        public async Task SaveEmployee(Employee emp)
        {
            await db.Employees.AddAsync(emp);
            await db.SaveChangesAsync();
        }

        public async Task UpdateEmployee(int id, Employee obj)
        {
            var employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("Employee Not found");
            }
            employee.Name = obj.Name;
            employee.Email = obj.Email;
            employee.Phone = obj.Phone;
            employee.Salary = obj.Salary;

            await db.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("Employee Not found");
            }
            db.Employees.Remove(employee);

            await db.SaveChangesAsync();
        }
    }
}
