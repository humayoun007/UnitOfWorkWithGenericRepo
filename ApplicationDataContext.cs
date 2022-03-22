using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TestProject
{
    public class ApplicationDataContext: DbContext
    {
        public ApplicationDataContext()
        {

        }
        public ApplicationDataContext(DbContextOptions options):base(options)
        {            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            if (!options.IsConfigured)

            {
                options.UseSqlServer("Data Source=localhost; Initial Catalog=TestDB; User Id=sa; Password=123456");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            //Seeding data
            //modelBuilder.Entity<Notification>().HasData(
            //    new Notification() { UserId = "hk", IsRead = false, DateCreated = new System.DateTime(2022, 08, 02) },
            //    new Notification() { UserId = "fs", IsRead = false, DateCreated = new System.DateTime(2022, 04, 11) }
            //    );
            base.OnModelCreating(modelBuilder);            
            
        }

        public DbSet<Notification> Notifications { get; set; }
    }

    //For Code first:
    // Package Manager Console command is : Add-Migration InitialDatabaseCreate ( for change or add any field again this command should execute also)
    // Package Manager Console command is : Update-Database 
    //For Db First:
    // Package manager console command is : Scaffold-DbContext -Connection "Server=DESKTOP-XYZ; Database=SampleDB; Trusted_Connection=True; MultipleActiveResultSets=true;" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir "Models" -ContextDir "Data" -Context "SampleDbContext"
    // For OnConfiguring method error we need this: Scaffold-DbContext -Connection "Server=DESKTOP-XYZ; Database=SampleDB; Trusted_Connection=True; MultipleActiveResultSets=true;" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir "Models" -ContextDir "Data" -Context "SampleDbContext" -NoOnConfiguring –Force


}
