using CarGallery_ef.Models;
using Microsoft.EntityFrameworkCore;

namespace CarGallery_ef.DAL;
internal class AppDbContext : DbContext
{
    private readonly string _connectionString = @"Server=localhost;Database=CarGallery;Trusted_Connection=True;TrustServerCertificate=True";

    public DbSet<Car> Cars { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Rental> Rentals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(_connectionString);
    }
}