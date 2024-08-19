using GamesStudio.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace GamesStudio.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<GameDevice> GameDevices { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(new Category[]
                {
                    new Category{ Id=1 , Name = "Sports"},
                    new Category{ Id=2 , Name = "Action"},
                    new Category{ Id=3 , Name = "Racing"},
                    new Category{ Id=4 , Name = "Advencture"},
                    new Category{ Id=5 , Name = "figthing"},
                    new Category{ Id=6 , Name = "fantazy"}

                }
                );

            modelBuilder.Entity<Device>()
               .HasData(new Device[]
               {
                    new Device{ Id=1 , Name = "Pc" , Icon="bi bi-Pc"},
                    new Device{ Id=2 , Name = "Xbox",Icon="bi bi-Xbox"},
                    new Device{ Id=3 , Name = "Playstation",Icon="bi bi-Playsytation"},
                    new Device{ Id=4 , Name = " RedSwitch",Icon="bi bi-RedSwitch"},


               }
               );




            modelBuilder.Entity<GameDevice>().HasKey(e => new { e.GameId, e.DeviceId });
            base.OnModelCreating(modelBuilder);
        }
    }
}

