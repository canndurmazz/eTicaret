
using eTicaret.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading;
using System.Threading.Tasks;

namespace eTicaret.DataAccsess
{
    
    public class ETicaretDbContext : DbContext
    {
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<ProductInformation> ProductInformations { get; set; }
        public DbSet<ChangeLog> ChangeLogs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Shopping> Shoppings { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyEarning> CompanyEarnings { get; set; }
        public DbSet<CompanyProduct> CompanyProducts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<WaitingProduct> WaitingProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=CANPC; Database=eTicaretDBAuth;uid=NT AUTHORITY\\NETWORK SERVICE;Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>().Property(c => c.RowVersion).IsRowVersion();
        }
        public override int SaveChanges()
        {
            try
            {
                var modifiedEntities = ChangeTracker.Entries().Where(p => p.State == EntityState.Modified).ToList();
                var now = System.DateTime.UtcNow;
                foreach (var change in modifiedEntities)
                {
                    var entityName = change.Entity.GetType().Name;
                    var PrimaryKey = change.OriginalValues.Properties.FirstOrDefault(prop => prop.IsPrimaryKey() == true).Name;
                    if (entityName == "Product" | entityName == "Stock")
                    {                 
                        foreach (IProperty prop in change.CurrentValues.Properties)
                        {
                            if (prop.Name == "Price" | prop.Name == "StockProduct" | prop.Name == "SoldProduct")
                            {
                            var originalValue = change.OriginalValues[prop.Name].ToString();
                            var currentValue = change.CurrentValues[prop.Name].ToString();
                                if (originalValue != currentValue)
                                {
                                    ChangeLog log = new()
                                    {
                                        PrimaryKey = int.Parse(change.OriginalValues[PrimaryKey].ToString()),
                                        EntityName = entityName,
                                        PropertyName = prop.Name,
                                        OldValue = originalValue,
                                        NewValue = currentValue,
                                        DataChanged = now
                                    };
                                    ChangeLogs.Add(log);
                                }
                            }
                        }
                    }
                }
                return base.SaveChanges();
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return 0;
            }
        }
    } 
}
