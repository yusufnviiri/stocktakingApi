using Microsoft.EntityFrameworkCore;

namespace stocktakingApi.Models.Context
{
    public class ApplicationDbContext : DbContext
    {



        //configure context
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<StaffTask> StaffTasks { get; set; }
        public DbSet<StockItem> StockItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>().HasData(
        new Staff { StaffId = 1, StaffName = "George Soros", StaffDescription = "George is the CEO of the enterprise.His office is S001", StaffRole = "CEO" },
        new Staff { StaffId = 2, StaffName = "Dorcus Samatha", StaffDescription = "Annet is the procurement manager.She has served the business for more than 8 solid years. Her Office is S009", StaffRole = "Procurement Manager" },
        new Staff { StaffId = 3, StaffName = "Yusuf Nviiri", StaffDescription = "Yusuf serves as the technical director and business advisor. He has served  the business for more than 6 years", StaffRole = "Business Psychologist" },
        new Staff { StaffId = 4, StaffName = "Martin Sanders", StaffDescription = "A competent Electrical Engineer, Martin is married to Suzan and a father of 3 beautiful girls", StaffRole = "Maintainance manager" },
        new Staff { StaffId = 5, StaffName = "Barbra Walters", StaffDescription = "Barbra specializes in Product Quality.She has served the company for more than 24 years ", StaffRole = "Quality Supervisor" });
            // seeding stockitems
            modelBuilder.Entity<StockItem>().HasData(
        new StockItem { Description = "LaserJet Printers D426S with portable print head ", Name = "LaserJet Printers", StockItemId = 1,StockAmount=4},
        new StockItem { Description = "Lenovo T430 model 2023 s/n= 2638JK23893MOS", Name = "Lenovo laptop", StockItemId = 2, StockAmount = 87 },
        new StockItem { Description = "Dell D39 model 2022 s/n = P537X3672", Name = "Dell Laptop ", StockItemId = 3, StockAmount = 27 },
        new StockItem { Description = "Kyocera Printers with mini paper cabins s/n Up673Jd", Name = "Kyocera Printers", StockItemId = 4, StockAmount = 6 });
            // seeding staffTasks
          

        } 





    }

    
}
