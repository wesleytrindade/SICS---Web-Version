using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SICS___WEB_2._0.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SICS___WEB_2._0.Context
{
    public class ApplicationDataContext : IdentityDbContext<AppUser>
    {
        public ApplicationDataContext()
            : base("DefaultConnection")
        { }

        public System.Data.Entity.DbSet<AppUser> AppUsers { get; set; }
    }
}