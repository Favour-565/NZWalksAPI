using Microsoft.EntityFrameworkCore;
using NzApp.Model.Domain;

namespace NzApp.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions): base(dbContextOptions)

        {


        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seed data for difficulties
            //Easy, Medium, Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("581f3df6-bf66-424d-ba58-b14ea2abde2f"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id =Guid.Parse("1f093595-67c5-4294-a41d-685968cbbcf0"),
                    Name = "Medium"
                },

                new Difficulty()
                {
                    Id =Guid.Parse("3ae930c2-1f39-4d24-912f-6c864cf920b6"),
                    Name = "Hard"
                }

                
            };

            //Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            //Seed data for Regions
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("9b893b06-f42e-4322-ac4b-a4b340649d68"),
                    Name = "ALK",
                    Code = "https://media.istockphoto.com/id/1437816897/photo/business-woman-manager-or-human-resources-portrait-for-career-success-company-we-are-hiring.jpg?s=612x612&w=is&k=20&c=tw9TuTigzhSlLA_b1Avy0X6GNF9ZFVvgTHIZ9i68Q0I="
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);



        }
    }
}

