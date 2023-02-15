using DocumentsStory.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentsStory.Data.Contexts
{
    public sealed class MainContext : DbContext
    {
        public MainContext() : base("Default")
        {

        }

        public MainContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Document>()
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }
    }
}
