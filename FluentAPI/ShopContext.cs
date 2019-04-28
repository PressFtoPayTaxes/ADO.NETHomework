namespace FluentAPI
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ShopContext : DbContext
    {
        public ShopContext()
            : base("name=ShopContext")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Basket>().HasRequired(basket => basket.User);

            modelBuilder.Entity<Basket>().HasMany(basket => basket.Products).WithMany(product => product.Baskets);

            base.OnModelCreating(modelBuilder);
        }
    }
}