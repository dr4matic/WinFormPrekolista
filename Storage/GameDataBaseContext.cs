using Microsoft.EntityFrameworkCore;
using Storage.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class GameDataBaseContext : DbContext
    {
        public GameDataBaseContext(DbContextOptions<GameDataBaseContext> options)
            : base(options) 
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<GameInfo>()
                .ToTable(nameof(GameInfo))
                .HasKey(e => e.Id);

            modelBuilder
                .Entity<GameInfo>()
                .ToTable(nameof(GameInfo))
                .HasKey(e => e.Name);
        }

    }
}
