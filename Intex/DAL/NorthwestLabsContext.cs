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

        public DbSet<User_R>


    }
}