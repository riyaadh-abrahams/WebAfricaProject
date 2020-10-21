using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Localization;
using Abp.MultiTenancy;
using WebAfricaProject.Entities;

namespace WebAfricaProject.EntityFrameworkCore.Seed.Host
{
    public class DefaultProjectsCreator
    {
        public static List<Project> InitialLanguages => GetInitialProjects();

        private readonly WebAfricaProjectDbContext _context;

        private static List<Project> GetInitialProjects()
        {

            return new List<Project>
            {
                new Project("Arsenal Playground", new System.DateTime(2017,1,1), null, 100),
                new Project("Aston Villa Training Facility", new System.DateTime(2017,4,2), new System.DateTime(2017,5,1), 1200d),
                new Project("Manchester Foundation", new System.DateTime(2016,4,2), new System.DateTime(2017,1,1), 120000d),
                new Project("Chelsea's Funeral", new System.DateTime(2015,1,1), new System.DateTime(2015,2,2), 1000d),
            };
        }

        public DefaultProjectsCreator(WebAfricaProjectDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateProjects();
        }

        private void CreateProjects()
        {
            foreach (Project project in InitialLanguages)
            {
                AddProjectIfNotExists(project);
            }
        }

        private void AddProjectIfNotExists(Project project)
        {
            if (_context.Project.IgnoreQueryFilters().Any(l => l.Name == project.Name && l.Startdate == project.Startdate && l.Enddate == project.Enddate && l.Cost == project.Cost))
            {
                return;
            }

            _context.Project.Add(project);
            _context.SaveChanges();
        }
    }
}
