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
                new Employee("Riyaadh", "Abrahams", _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "Developer").Id, new System.DateTime(1998,1,26)),
                new Employee("John", "Wick", _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "Business Analyst").Id, new System.DateTime(1984,6,8)),
                new Employee("Dani", "Welbeck", _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "Business Analyst").Id, new System.DateTime(1979,7,15)),
                new Employee("Alexis", "Sanchez", _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "DBA").Id, new System.DateTime(1947,1,5)),
                new Employee("Mesut", "Ozil",  _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "Developer").Id, new System.DateTime(1994,6,21)),
                new Employee("Musa" , "Dembele", _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "DBA").Id, new System.DateTime(1996,4,2)),
                new Employee("Harry", "Kane", _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "Tester").Id, new System.DateTime(1978,9,2)),
                new Employee("David", "Silva", _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "Developer").Id, new System.DateTime(2001,2,5)),
                new Employee("Roy", "Keane", _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "DBA").Id, new System.DateTime(1995,6,19)),
                new Employee("Dele", "Alli", _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "Developer").Id, new System.DateTime(1950,1,14)),
                new Employee("Romelu", "Lukaku", _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "Developer").Id, new System.DateTime(1999,6,25)),
                new Employee("Anthony", "Martial", _context.JobTitles.FirstOrDefault(x => x.JobTitleLabel == "DBA").Id, new System.DateTime(2000,1,2))



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
