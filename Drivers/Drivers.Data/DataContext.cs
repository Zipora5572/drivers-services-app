using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using CsvHelper;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drivers.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Drivers.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<User> Users { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public virtual EntityEntry Entry(object entity)
        {
            return base.Entry(entity);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id); // Set Id as primary key

            modelBuilder.Entity<Driver>(e =>
            {
                e.ToTable("Drivers"); // Define table for Driver
            });
        }

        //public DataContext()
        //{
        //    Cars = LoadData<Car>();
        //    Drivers = LoadData<Driver>();
        //    Users = LoadData<User>();
        //    Travels = LoadData<Travel>();
        //    Orders = LoadData<Order>();
        //}


        //    public List<T> LoadData<T>()
        //    {
        //        try
        //        {
        //            List<T> data;
        //            string path = GetPath<T>();
        //            using (var reader = new StreamReader(path))
        //            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        //            {
        //                data = csv.GetRecords<T>().ToList();

        //            }
        //            if (data == null)
        //            {
        //                return null;
        //            }
        //            return data;
        //        }
        //        catch
        //        {

        //            return null;
        //        }
        //    }
        //    private string GetPath<T>()
        //    {
        //        return Path.Combine(AppContext.BaseDirectory, "Data", $"{typeof(T).Name}.csv");
        //    }
        //    public bool SaveData<T>(List<T> data)
        //    {
        //        try
        //        {

        //            string path = GetPath<T>();

        //            using (var writer = new StreamWriter(path))
        //            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        //            {
        //                csv.WriteRecords(data);
        //            }

        //            return true;
        //        }
        //        catch { return false; }
        //    }

    }
}
