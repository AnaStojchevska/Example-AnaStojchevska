using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Transactions;

namespace Example.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transaction { get; set; } = null!;
        public DbSet<Category> Category { get; set; } = null!;
    }
}