using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Report.API.Models.ORM.Entities;

namespace Report.API.Models.ORM.Context
{
    public class ReportContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=ec2-52-209-134-160.eu-west-1.compute.amazonaws.com;Database=ddviu4em55pmv8;UID=rtqfemquqveese;PWD=77ef001f8f35d7c9541c7b5513af55c5346fdfc3c71f2b1689bcbb8cf70f4456;SSL Mode= Require;TrustServerCertificate=True");
        }


        public DbSet<Reports> Reports { get; set; }



    }
}
