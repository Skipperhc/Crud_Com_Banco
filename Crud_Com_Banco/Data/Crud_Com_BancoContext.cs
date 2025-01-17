﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Crud_Com_Banco.Models;

namespace Crud_Com_Banco.Data {
    public class Crud_Com_BancoContext : DbContext {
        public Crud_Com_BancoContext(DbContextOptions<Crud_Com_BancoContext> options)
            : base(options) {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
