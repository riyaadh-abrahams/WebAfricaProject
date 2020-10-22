using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using WebAfricaProject.Authorization.Roles;
using WebAfricaProject.Authorization.Users;
using WebAfricaProject.MultiTenancy;
using WebAfricaProject.Entities;

namespace WebAfricaProject.EntityFrameworkCore
{
    public class WebAfricaProjectDbContext : AbpZeroDbContext<Tenant, Role, User, WebAfricaProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Employee> Employee { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployee { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkill { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeSkill>()
                .HasKey(x => new { x.Id });

            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(x => x.Employee)
                .WithMany(y => y.EmployeeSkills)
                .HasForeignKey(y => y.EmployeeId);

            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(x => x.Skill)
                .WithMany(y => y.EmployeeSkills)
                .HasForeignKey(y => y.SkillId);

            modelBuilder.Entity<ProjectEmployee>()
                .HasKey(x => new { x.Id });

            modelBuilder.Entity<ProjectEmployee>()
                .HasOne(x => x.Project)
                .WithMany(y => y.ProjectEmployees)
                .HasForeignKey(y => y.ProjectId);

            modelBuilder.Entity<ProjectEmployee>()
                .HasOne(x => x.Employee)
                .WithMany(y => y.ProjectEmployees)
                .HasForeignKey(y => y.EmployeeId);
        }

        public WebAfricaProjectDbContext(DbContextOptions<WebAfricaProjectDbContext> options)
            : base(options)
        {

        }
    }
}
