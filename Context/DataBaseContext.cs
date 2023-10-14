using Microsoft.EntityFrameworkCore;
using student.Models;

namespace student.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        { 
          Database.SetCommandTimeout(150000);
        }

        public DbSet<Student> Students { get; set; }

        public virtual DbSet<BulkLedger> BulkLedgers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=teststunew;Integrated Security=True;TrustServerCertificate=True;Command Timeout=3600;");
                                                                                                                                                                    //Server=DESKTOP-P9L7UG7\\MSSQLSERVER23;Database=teststu;Intergrated Security=True;");//DESKTOP-P9L7UG7\MSSQLSERVER23
                                                                                                                                                                    //optionsBuilder.CommandTimeout(120);
                                                                                                                                                                    //optionsBuilder.sqlbulkcopy
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-P9L7UG7\\MSSQLSERVER23;Initial Catalog=teststunew;Integrated Security=True;TrustServerCertificate=True;");//;Command Timeout=3600;
        }
    }
}
