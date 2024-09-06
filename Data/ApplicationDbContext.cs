using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSet'ler
    public DbSet<Role> Roles { get; set; }
    public DbSet<Tax> Taxes { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Work> Works { get; set; }
    public DbSet<Staging> Stagings { get; set; }
    public DbSet<EmployeeRole> EmployeeRoles { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    // Staging ve Work arasındaki ilişkiyi kaldır
    modelBuilder.Entity<Work>()
        .HasOne(w => w.Staging)
        .WithMany(s => s.Works)
        .HasForeignKey(w => w.StagingId)
        .OnDelete(DeleteBehavior.ClientNoAction); // İlişkiyi kaldırır, silme davranışını değiştirebilirsiniz

    // Staging ve Work arasındaki ilişkiyi kaldır
    modelBuilder.Entity<Staging>()
        .HasMany(s => s.Works)
        .WithOne(w => w.Staging)
        .HasForeignKey(w => w.StagingId)
        .OnDelete(DeleteBehavior.ClientNoAction); // İlişkiyi kaldırır, silme davranışını değiştirebilirsiniz

    // Work ve Company arasındaki ilişkiyi kaldır
    modelBuilder.Entity<Work>()
        .HasOne(w => w.Company)
        .WithMany(c => c.Works)
        .HasForeignKey(w => w.CompanyId)
        .OnDelete(DeleteBehavior.ClientNoAction); // İlişkiyi kaldırır, silme davranışını değiştirebilirsiniz

    // Work ve Employee arasındaki ilişkiyi kaldır
    modelBuilder.Entity<Work>()
        .HasOne(w => w.Employee)
        .WithMany(e => e.Works)
        .HasForeignKey(w => w.EmployeeId)
        .OnDelete(DeleteBehavior.ClientNoAction); // İlişkiyi kaldırır, silme davranışını değiştirebilirsiniz

    // Work ve Comment arasındaki ilişkiyi kaldır
    modelBuilder.Entity<Work>()
        .HasMany(w => w.Comments)
        .WithOne(c => c.Work)
        .HasForeignKey(c => c.WorkId)
        .OnDelete(DeleteBehavior.ClientNoAction); // İlişkiyi kaldırır, silme davranışını değiştirebilirsiniz

    // Work ve Notification arasındaki ilişkiyi kaldır
    modelBuilder.Entity<Work>()
        .HasMany(w => w.Notifications)
        .WithOne(n => n.Work)
        .HasForeignKey(n => n.WorkId)
        .OnDelete(DeleteBehavior.ClientNoAction); // İlişkiyi kaldırır, silme davranışını değiştirebilirsiniz
}


}
