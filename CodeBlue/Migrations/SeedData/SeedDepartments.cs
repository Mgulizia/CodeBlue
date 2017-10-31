using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using CodeBlue.Models;

namespace CodeBlue.Migrations.SeedData
{
    public static class SeedDepartments
    {
        public static void Seed()
        {
            var context = ApplicationDbContext.Create();

            //Add additional positions here
            context.Departments.AddOrUpdate(x => x.Id,
                new Department() { Id = 1,  IsEnabled= true, DepartmentName = "Administrative"},
                new Department() { Id = 2,  IsEnabled= true, DepartmentName = "Accounting"},
                new Department() { Id = 3,  IsEnabled= true, DepartmentName = "Human Resources"},
                new Department() { Id = 4,  IsEnabled= true, DepartmentName = "Marketing"},
                new Department() { Id = 5,  IsEnabled= true, DepartmentName = "Food Preperation Specialist" },
                new Department() { Id = 6,  IsEnabled= true, DepartmentName = "Production"},
                new Department() { Id = 7,  IsEnabled= true, DepartmentName = "Information Technology"},
                new Department() { Id = 8,  IsEnabled= true, DepartmentName = "Application Development"},
                new Department() { Id = 9,  IsEnabled= true, DepartmentName = "Enviromental Technicians"},
                new Department() { Id = 10, IsEnabled= true, DepartmentName = "Food Preperation Specialist"},
                new Department() { Id = 11, IsEnabled= true, DepartmentName = "Logistics"},
                new Department() { Id = 12, IsEnabled= true, DepartmentName = "Customer Service"},
                new Department() { Id = 13, IsEnabled= true, DepartmentName = "Help Desk"},
                new Department() { Id = 14, IsEnabled= true, DepartmentName = "Executive"}
            );
            context.SaveChanges();

        }
    }
}