using Microsoft.EntityFrameworkCore;
using NeuFinesse.Data.Model;
using System;

namespace NeuFinesse.Data.Repository
{
    public class NeuFinesseContext : DbContext
    {
        public NeuFinesseContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<SellerItem> SellerItem { get; set; }
        public DbSet<SellerDetail> SellerDetail { get; set; }
        public DbSet<SellerSkill> SellerSkill { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<Interest> Interest { get; set; }
        public DbSet<UserInterest> UserInterest { get; set; }
        public DbSet<ReviewRating> ReviewRating { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<WishList> WishList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = "123",
                UserName = "suraj",
                Email = "surajdma@gmail.com",
                Role = Roles.Buyer
            }
        );
        }

    }
}
