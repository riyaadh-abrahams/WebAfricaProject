using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Localization;
using Abp.MultiTenancy;
using WebAfricaProject.Entities;

namespace WebAfricaProject.EntityFrameworkCore.Seed.Host
{
    public class DefaultJobTitlesCreator
    {
        public static List<JobTitle> InitialLanguages => GetInitialJobTitles();

        private readonly WebAfricaProjectDbContext _context;

        private static List<JobTitle> GetInitialJobTitles()
        {
            var tenantId = WebAfricaProjectConsts.MultiTenancyEnabled ? null : (int?)MultiTenancyConsts.DefaultTenantId;
            return new List<JobTitle>
            {
                new JobTitle("Developer", 2500d),
                new JobTitle("DBA", 3000d),
                new JobTitle("Tester", 1000d),
                new JobTitle("Business Analyst", 4500d)

            };
        }

        public DefaultJobTitlesCreator(WebAfricaProjectDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateJobTitles();
        }

        private void CreateJobTitles()
        {
            foreach (JobTitle jobTitle in InitialLanguages)
            {
                AddJobTitleIfNotExists(jobTitle);
            }
        }

        private void AddJobTitleIfNotExists(JobTitle jobTitle)
        {
            if (_context.JobTitles.IgnoreQueryFilters().Any(l => l.JobTitleLabel == jobTitle.JobTitleLabel && l.ExtraProjectCost == jobTitle.ExtraProjectCost))
            {
                return;
            }

            _context.JobTitles.Add(jobTitle);
            _context.SaveChanges();
        }
    }
}
