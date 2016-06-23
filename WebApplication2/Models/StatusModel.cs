namespace WebApplication2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StatusModel : DbContext
    {
        public StatusModel()
            : base("name=StatusModel")
        {
        }

        public virtual DbSet<StatusUpdate> StatusUpdates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatusUpdate>()
                .Property(e => e.Topic)
                .IsUnicode(false);

            modelBuilder.Entity<StatusUpdate>()
                .Property(e => e.Status)
                .IsUnicode(false);
        }
    }
}
