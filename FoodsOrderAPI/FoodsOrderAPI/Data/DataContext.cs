using System;
using System.Collections.Generic;
using FoodsOrderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodsOrderAPI.Data;

public partial class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<FoodItem> FoodItems { get; set; }
    public virtual DbSet<LoginModel> LoginModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FoodItem>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__FoodItem__3213E83FA8A9E88F");
        });

        modelBuilder.Entity<LoginModel>(entity =>
        {
            entity.HasKey(e => e.id);
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
