﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace OrdersService
{

    public class MyContext : DbContext
    {
        
        public static MyContext Connect(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseMySQL(connectionString);

            //Ensure database creation
            var context = new MyContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            return context;
        }


        public DbSet<Order> Orders { get; set; }

        
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {

        }
    }
}
