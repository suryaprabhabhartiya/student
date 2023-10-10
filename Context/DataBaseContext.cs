using Microsoft.EntityFrameworkCore;


namespace student.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        { 
        Database.SetCommandTimeout(150000);
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-P9L7UG7\\MSSQLSERVER23;Initial Catalog=teststu;Integrated Security=True;TrustServerCertificate=True;Command Timeout=360;");
                //Server=DESKTOP-P9L7UG7\\MSSQLSERVER23;Database=teststu;Intergrated Security=True;");//DESKTOP-P9L7UG7\MSSQLSERVER23
                //optionsBuilder.CommandTimeout(120);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
