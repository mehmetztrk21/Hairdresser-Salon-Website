using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MekhannDb: DbContext
    {
        public DbSet<Team> Team { get; set; }
        public DbSet<General> General { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<EntrySlider> EntrySliders { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<PriceList> PriceList { get; set; }
        public DbSet<Services> Services { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MekhannDb");
        }
    }
}
