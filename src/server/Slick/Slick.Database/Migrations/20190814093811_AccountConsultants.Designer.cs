﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Slick.Database;

namespace Slick.Database.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20190814093811_AccountConsultants")]
    partial class AccountConsultants
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Slick.Models.Contact.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Number");

                    b.Property<string>("Street");

                    b.Property<int>("Zip");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Slick.Models.Contracts.Contract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ConsultantId");

                    b.Property<Guid>("ContractId");

                    b.Property<Guid>("ContractTypeId");

                    b.Property<string>("DocumentUrl");

                    b.Property<DateTime?>("EndDate");

                    b.Property<decimal>("Salary");

                    b.Property<DateTime?>("SignedDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("ConsultantId");

                    b.HasIndex("ContractTypeId");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("Slick.Models.Contracts.ContractType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ContractTypes");
                });

            modelBuilder.Entity("Slick.Models.Customers.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AddressId");

                    b.Property<string>("CompanyName")
                        .IsRequired();

                    b.Property<string>("TelephoneNumber");

                    b.Property<string>("VatNumber");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Slick.Models.Customers.AccountConsultant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountId");

                    b.Property<decimal>("BuyPrice");

                    b.Property<Guid>("ConsultantId");

                    b.Property<Guid?>("EmployeeId");

                    b.Property<DateTime>("EndDate");

                    b.Property<decimal>("SellPrice");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("ConsultantId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("AccountConsultants");
                });

            modelBuilder.Entity("Slick.Models.Customers.AccountManager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountId");

                    b.Property<Guid>("EmployeeId");

                    b.Property<bool>("IsActive");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("AccountManager");
                });

            modelBuilder.Entity("Slick.Models.People.Consultant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AddressId");

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("Email");

                    b.Property<string>("Firstname")
                        .IsRequired();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Lastname")
                        .IsRequired();

                    b.Property<string>("Middlename");

                    b.Property<string>("Mobile");

                    b.Property<string>("Telephone");

                    b.Property<string>("WorkEmail");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Consultants");
                });

            modelBuilder.Entity("Slick.Models.People.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AddressId");

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("Email");

                    b.Property<string>("Firstname")
                        .IsRequired();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Lastname")
                        .IsRequired();

                    b.Property<string>("Middlename");

                    b.Property<string>("Telephone");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Slick.Models.Skills.ConsultantSpecialisation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ConsultantId");

                    b.Property<Guid>("SpecialisationId");

                    b.HasKey("Id");

                    b.HasIndex("ConsultantId");

                    b.HasIndex("SpecialisationId");

                    b.ToTable("ConsultantSpecialisations");
                });

            modelBuilder.Entity("Slick.Models.Skills.Specialisation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<Guid>("SpecialisationLevelId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("SpecialisationLevelId");

                    b.ToTable("Specialisations");
                });

            modelBuilder.Entity("Slick.Models.Skills.SpecialisationLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("Weight");

                    b.HasKey("Id");

                    b.ToTable("SpecialisationLevel");
                });

            modelBuilder.Entity("Slick.Models.Contracts.Contract", b =>
                {
                    b.HasOne("Slick.Models.People.Consultant", "Consultant")
                        .WithMany("Contracts")
                        .HasForeignKey("ConsultantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Slick.Models.Contracts.ContractType", "ContractType")
                        .WithMany()
                        .HasForeignKey("ContractTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Slick.Models.Customers.Account", b =>
                {
                    b.HasOne("Slick.Models.Contact.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("Slick.Models.Customers.AccountConsultant", b =>
                {
                    b.HasOne("Slick.Models.Customers.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Slick.Models.People.Consultant", "Consultant")
                        .WithMany()
                        .HasForeignKey("ConsultantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Slick.Models.People.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("Slick.Models.Customers.AccountManager", b =>
                {
                    b.HasOne("Slick.Models.Customers.Account", "Account")
                        .WithMany("AccountManagers")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Slick.Models.People.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Slick.Models.People.Consultant", b =>
                {
                    b.HasOne("Slick.Models.Contact.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Slick.Models.People.Employee", b =>
                {
                    b.HasOne("Slick.Models.Contact.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Slick.Models.Skills.ConsultantSpecialisation", b =>
                {
                    b.HasOne("Slick.Models.People.Consultant", "Consultant")
                        .WithMany("Specialisations")
                        .HasForeignKey("ConsultantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Slick.Models.Skills.Specialisation", "Specialisation")
                        .WithMany("Consultant")
                        .HasForeignKey("SpecialisationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Slick.Models.Skills.Specialisation", b =>
                {
                    b.HasOne("Slick.Models.Skills.SpecialisationLevel", "SpecialisationLevel")
                        .WithMany()
                        .HasForeignKey("SpecialisationLevelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
