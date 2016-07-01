﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class ModelsContext :DbContext
    {
        public ModelsContext(DbContextOptions<ModelsContext> options)
            : base(options)
        { }

        public DbSet<Post> Posts { get; set; }
    }
}
