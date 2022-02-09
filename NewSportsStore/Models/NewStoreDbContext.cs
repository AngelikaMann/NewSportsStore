﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewSportsStore.Models
{
    public class NewStoreDbContext:DbContext
    {
        public NewStoreDbContext(DbContextOptions<NewStoreDbContext> options): base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
