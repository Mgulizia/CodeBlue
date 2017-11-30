using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using CodeBlue.Models;

namespace CodeBlue.Migrations.SeedData
{
    public static class SeedKnowledgeBaseCatagories
    {
        public static void Seed()
        {
            var context = ApplicationDbContext.Create();

            //Add additional positions here
            context.KnowledgeBaseCatagories.AddOrUpdate(x => x.Id,
                new KnowledgeBaseCatagory() { Id = 1,    CatagoryName = "Excel"},
                new KnowledgeBaseCatagory() { Id = 2,    CatagoryName = "Printers"},
                new KnowledgeBaseCatagory() { Id = 3,    CatagoryName = "Windows"},
                new KnowledgeBaseCatagory() { Id = 4,    CatagoryName = "Monitors"},
                new KnowledgeBaseCatagory() { Id = 5,    CatagoryName = "Bing"},
                new KnowledgeBaseCatagory() { Id = 6,    CatagoryName = "WiFi connection"},
                new KnowledgeBaseCatagory() { Id = 7,    CatagoryName = "Web Browsers"},
                new KnowledgeBaseCatagory() { Id = 8,    CatagoryName = "SharePoint"},
                new KnowledgeBaseCatagory() { Id = 9,    CatagoryName = "Peripherals"}
                );
            context.SaveChanges();

        }
    }
}