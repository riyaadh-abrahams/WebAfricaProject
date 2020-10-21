using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Localization;
using Abp.MultiTenancy;
using WebAfricaProject.Entities;

namespace WebAfricaProject.EntityFrameworkCore.Seed.Host
{
    public class DefaultEmployeesCreator
    {
        public List<Employee> InitialLanguages => GetInitialEmployees();

        private readonly WebAfricaProjectDbContext _context;

        private List<Employee> GetInitialEmployees()
        {

            return new List<Employee>
            {
                new Employee("Riyaadh", "Abrahams", _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "Developer").Id),
                new Employee("John", "Wick", _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "Business Analyst").Id),
                new Employee("Dani", "Welbeck", _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "Business Analyst").Id),
                new Employee("Alexis", "Sanchez", _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "DBA").Id),
                new Employee("Mesut", "Ozil",  _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "Developer").Id),
                new Employee("Musa" , "Dembele", _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "DBA").Id),
                new Employee("Harry", "Kane", _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "Tester").Id),
                new Employee("David", "Silva", _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "Developer").Id),
                new Employee("Roy", "Keane", _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "DBA").Id),
                new Employee("Dele", "Alli", _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "Developer").Id),
                new Employee("Romelu", "Lukaku", _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "Developer").Id),
                new Employee("Anthony", "Martial", _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "DBA").Id)



            };
        }

        public DefaultEmployeesCreator(WebAfricaProjectDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateEmployees();
        }

        private void CreateEmployees()
        {
            foreach (Employee employee in InitialLanguages)
            {
                AddEmployeeIfNotExists(employee);
            }
        }

        private void AddEmployeeIfNotExists(Employee employee)
        {
            if (_context.Employee.IgnoreQueryFilters().Any(l => l.Name == employee.Name && l.Surname == employee.Surname && l.JobTitleId == employee.JobTitleId))
            {
                return;
            }

            _context.Employee.Add(employee);
            _context.SaveChanges();
        }
    }
}
