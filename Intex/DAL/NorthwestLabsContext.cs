using Intex.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Intex.DAL
{
    public class NorthwestLabsContext : DbContext
    {
        public NorthwestLabsContext()
            :base("NorthwestContext")
        {

        }

        public DbSet<User_Roles> User_Roles { get; set; }
        public DbSet<Customer_Payment> Customer_Payments { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Work_Orders> Work_Orders { get; set; }
        public DbSet<Work_Order_Assays> Work_Order_Assays { get; set; }
        public DbSet<Assays> Assays { get; set; }
        public DbSet<Assay_Tests> Assay_Tests { get; set; }
        public DbSet<Compound_Receipts> Compound_Receipts { get; set; }
        public DbSet<Tests> Tests { get; set; }
        public DbSet<Test_Materials> Test_Materials { get; set; }
        public DbSet<Materials> Materials { get; set; }

    }
}