using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TaskMaster.API.Models;

namespace TaskMaster.API.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}
