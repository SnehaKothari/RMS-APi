using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using recruitmentmanagementsystem.CommonMethods;
using recruitmentmanagementsystem.CommonModel;

namespace recruitmentmanagementsystem.Data
{
    public class Recruitmentcontext:IdentityDbContext<ApplicationUser>
    {
        public Recruitmentcontext(DbContextOptions<Recruitmentcontext> options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>()
               .HasData(
                        new IdentityRole { Name = "SUPER ADMIN", NormalizedName="SUPER ADMIN" },
                        new IdentityRole { Name="HR", NormalizedName="HR" },
                        new IdentityRole { Name="TALENT REQUISITION", NormalizedName= "TALENT REQUISITION"}
               );

            modelBuilder.HasSequence<int>("requisitionid", schema: "shared")
               .StartsAt(1000)
               .IncrementsBy(1);
            modelBuilder.Entity<Requisition>()
                .Property(o => o.id)
                .HasDefaultValueSql("nextval('shared.requisitionid')");
            modelBuilder.UseSerialColumns();

        }
       // public DbSet<LoginFields> login { get; set; }

        public DbSet<Requisition> requisition { get; set; }

        public DbSet<Resumes> resume { get; set; }

        //public DbSet<ResumeDemo> demo_resumes { get; set; }

        public DbSet<Calendar> calendar { get; set; }
        public DbSet<CandidateResume> candidateresume { get; set; }

    }
}
