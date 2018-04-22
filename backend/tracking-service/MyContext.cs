﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace TrackingService
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


        public DbSet<TrackedOrder> TrackedOrders { get; set; }

        
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {

        }
    }
}
