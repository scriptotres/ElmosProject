using Microsoft.EntityFrameworkCore;
using Slick.Models.Contact;
using Slick.Models.Contracts;
using Slick.Models.Customers;
using Slick.Models.People;
using Slick.Models.Skills;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slick.Database
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Specialisation> Specialisations { get; set; }
        public DbSet<ConsultantSpecialisation> ConsultantSpecialisations { get; set; }
        public DbSet<SpecialisationLevel> SpecialisationLevel { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountConsultant> AccountConsultants { get; set; }
        public object Books { get; set; }
    }
}

//Data Source=ELMOS-BPCT94\JAN;Initial Catalog=tempdb;Integrated Security=True