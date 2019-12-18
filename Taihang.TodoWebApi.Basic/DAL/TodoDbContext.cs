using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

using Taihang.TodoWebApi.Basic.Models;

namespace Taihang.TodoWebApi.Basic.DAL
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext() : base("name=DefaultConnection")
        {

        }

        public virtual DbSet<Todo> Todo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 删除复数表名约定
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}