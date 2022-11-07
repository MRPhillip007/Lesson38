using Microsoft.EntityFrameworkCore;
using AdminPanel.Entities;

namespace AdminPanel.DAL
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<UserEntity> Users { get; set; }
    }
}