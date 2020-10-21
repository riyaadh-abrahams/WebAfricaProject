using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Localization;
using Abp.MultiTenancy;
using WebAfricaProject.Entities;

namespace WebAfricaProject.EntityFrameworkCore.Seed.Host
{
    public class DefaultProjectEmployeesCreator
    {
        public List<ProjectEmployee> InitialLanguages => GetInitialProjectEmployees();

        private readonly WebAfricaProjectDbContext _context;

        private  List<ProjectEmployee> GetInitialProjectEmployees()
        {

            return new List<ProjectEmployee>
            {
                new ProjectEmployee(_context.Project.FirstOrDefault(x => x.Name == "Arsenal Playground").Id,_context.Employee.FirstOrDefault(x => x.Name == "Dani").Id),
                new ProjectEmployee(_context.Project.FirstOrDefault(x => x.Name == "Arsenal Playground").Id,_context.Employee.FirstOrDefault(x => x.Name == "Alexis").Id),
                new ProjectEmployee(_context.Project.FirstOrDefault(x => x.Name == "Arsenal Playground").Id,_context.Employee.FirstOrDefault(x => x.Name == "Mesut").Id),
                new ProjectEmployee(_context.Project.FirstOrDefault(x => x.Name == "Aston Villa Training Facility").Id,_context.Employee.FirstOrDefault(x => x.Name == "Dani").Id),
                new ProjectEmployee(_context.Project.FirstOrDefault(x => x.Name == "Aston Villa Training Facility").Id,_context.Employee.FirstOrDefault(x => x.Name == "Anthony").Id),
                new ProjectEmployee(_context.Project.FirstOrDefault(x => x.Name == "Manchester Foundation").Id,_context.Employee.FirstOrDefault(x => x.Name == "Anthony").Id),
                new ProjectEmployee(_context.Project.FirstOrDefault(x => x.Name == "Manchester Foundation").Id,_context.Employee.FirstOrDefault(x => x.Name == "Romelu").Id),
                new ProjectEmployee(_context.Project.FirstOrDefault(x => x.Name == "Manchester Foundation").Id,_context.Employee.FirstOrDefault(x => x.Name == "Roy").Id)
            };
        }

        public DefaultProjectEmployeesCreator(WebAfricaProjectDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateProjectEmployees();
        }

        private void CreateProjectEmployees()
        {
            foreach (ProjectEmployee projectEmployee in InitialLanguages)
            {
                AddProjectEmployeeIfNotExists(projectEmployee);
            }
        }

        private void AddProjectEmployeeIfNotExists(ProjectEmployee projectEmployee)
        {
            if (_context.ProjectEmployee.IgnoreQueryFilters().Any(l => l.ProjectId == projectEmployee.ProjectId && l.EmployeeId == projectEmployee.EmployeeId))
            {
                return;
            }

            _context.ProjectEmployee.Add(projectEmployee);
            _context.SaveChanges();
        }
    }
}
