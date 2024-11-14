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

    public DbSet<Proforma> Proformas { get; set;}

    public DbSet<Payment> Pagos { get; set;}

    public DbSet<Order> Pedidos { get; set;}

    public DbSet<OrderDetails> DetallePedidos { get; set;}

}
