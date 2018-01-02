﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Site.Models
{
    public class MyContext : DbContext
    {
        public MyContext()
            : base(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString)
        {

        }

        public DbSet<Pessoa> Pessoa { get; set; }

    }
}