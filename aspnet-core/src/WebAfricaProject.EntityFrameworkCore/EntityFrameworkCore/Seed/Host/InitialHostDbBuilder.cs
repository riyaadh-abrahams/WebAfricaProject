using Abp.Domain.Repositories;
using WebAfricaProject.Entities;

namespace WebAfricaProject.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly WebAfricaProjectDbContext _context;


        public InitialHostDbBuilder(WebAfricaProjectDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            new DefaultJobTitlesCreator(_context).Create();
            new DefaultEmployeesCreator(_context).Create();
            new DefaultProjectsCreator(_context).Create();
            new DefaultProjectEmployeesCreator(_context).Create();
            new DefaultSkillsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
