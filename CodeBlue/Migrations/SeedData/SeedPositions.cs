using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using CodeBlue.Models;

namespace CodeBlue.Migrations.SeedData
{
    public static class SeedPositions
    {
        public static void Seed()
        {
            var context = ApplicationDbContext.Create();

            //Add additional positions here
            context.Positions.AddOrUpdate(x => x.Id,
                new Position() { Id = 1, TitleDescription = "Administrator"},
                new Position() { Id = 2, TitleDescription = "Technician Supervisor"},
                new Position() { Id = 3, TitleDescription = "Advanced Technician"},
                new Position() { Id = 4, TitleDescription = "Technician"},
                new Position() { Id = 5, TitleDescription = "Field Technician"},
                new Position() { Id = 6, TitleDescription = "Customer Support Staff"}
            );
            context.SaveChanges();

        }
    }
}