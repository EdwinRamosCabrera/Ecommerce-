using Ecommerce_.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public DbSet<Contact> Contactos { get; set;}

    public DbSet<Product> Productos { get; set;}

    public DbSet<Category> Categorias { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                      .WithMany(c => c.Products)
                                      .HasForeignKey(p => p.CategoryId)
                                      .HasConstraintName("FK_Category_Product")
                                      .OnDelete(DeleteBehavior.SetNull);
        
        modelBuilder.Entity<Category>( entity => {
            entity.ToTable("Categorias");
            entity.HasKey(c => c.CategoryId);
            entity.HasIndex(c => c.CategoryId).IsUnique();                           
        });
    }
}
