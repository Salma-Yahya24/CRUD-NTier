﻿using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data;

public class ClsAppNtierContext:DbContext
{
    public ClsAppNtierContext(DbContextOptions<ClsAppNtierContext> options):base(options)
    {
            
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}
