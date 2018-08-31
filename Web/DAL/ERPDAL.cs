using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.DAL
{
    public class ERPDAL : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<SysFunc> SysFunc { get; set; }
        public DbSet<SysPower> SysPower { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<SysRole> SysRole { get; set; }
        public DbSet<SysUserRole> SysUserRole { get; set; }
    }
}