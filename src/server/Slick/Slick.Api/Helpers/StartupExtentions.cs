using Microsoft.Extensions.DependencyInjection;
using Slick.Models.People;
using Slick.Models.Skills;
using Slick.Models.Contact;
using Slick.Repositories;
using Slick.Repositories.Skills;
using Slick.Services;
using Slick.Services.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Slick.Models.Contracts;
using Slick.Services.People;
using Slick.Services.Contracts;
using Slick.Models.Customers;
using Slick.Services.Costumers;

namespace Slick.Api
{
    public static class StartupExtentions
    {
        public  static void RegisterRepositories(this IServiceCollection service)
        {
            service.AddTransient<IEntityRepository<SpecialisationLevel>, EntityRepository<SpecialisationLevel>>();
            service.AddTransient<IEntityRepository<Contract>, EntityRepository<Contract>>();
            service.AddTransient<IEntityRepository<Consultant>, EntityRepository<Consultant>>();
            service.AddTransient<IEntityRepository<Employee>, EntityRepository<Employee>>();
            service.AddTransient<IEntityRepository<Account>, EntityRepository<Account>>();
            service.AddTransient<IEntityRepository<AccountConsultant>, EntityRepository<AccountConsultant>>();


        }
        public static void RegisterServices(this IServiceCollection service)
        {
            service.AddTransient<ISpecialisationLevelService, SpecialisationLevelService>();
            service.AddTransient<IConsultantService, ConsultantsService>();
            service.AddTransient<IContractService, ContractService>();
            service.AddTransient<IEmployeeService, EmployeesService>();
            service.AddTransient<IAccountService, AccountsService>();
            service.AddTransient<IAccountConsultantsService, AccountConsultantsService>();

        }
        public static void ConfigureCorse(this IServiceCollection service)
        {
            service.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", bobTheCorsBuilder =>
                {
                    bobTheCorsBuilder.AllowAnyOrigin().
                    AllowAnyMethod().
                    AllowAnyHeader().
                    AllowCredentials();
                });
            });
        }

    }
}
