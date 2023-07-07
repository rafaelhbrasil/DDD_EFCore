using EFCoreTest.Repository.Database.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using EFCoreTest.Domain;
using EFCoreTest.Repository.Database.Models;

namespace EFCoreTest.Repository.Database;


public partial class MemoryContext : DbContext
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly bool _enableSensitiveData;

    public MemoryContext(ILoggerFactory loggerFactory, bool enableSensitiveData)
    {
        _loggerFactory = loggerFactory;
        this._enableSensitiveData = enableSensitiveData;
    }

    public MemoryContext(DbContextOptions options)
        : base(options)
    {
        Console.WriteLine("[WARNING] Using in-memory database.");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("EFCoreTest");

        optionsBuilder.UseLoggerFactory(_loggerFactory);
        if (_enableSensitiveData)
            optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserMapping());


        Seed(modelBuilder);
        Task.Factory.StartNew(async () =>
        {
            await Task.Delay(50);
            Database.EnsureCreated();
        });
    }

    private void Seed(ModelBuilder modelBuilder)
    {
        var user = new User("Rafael", "rafael@test.com", "123456");
        var address = new Address("Rua 1", "Cidade 1", "Estado 1", "A99 B999", null, 1);

        SetId(address, 2);
        SetId(user, 1);

        modelBuilder.Entity<User>().HasData(user);
        modelBuilder.Entity<Address>().HasData(address);

    }

    private static void SetId<T>(T obj, int v) where T : Entity
    {
        var property = obj.GetType().GetProperty("Id")!;
        property = property.DeclaringType!.GetProperty("Id")!;
        property.SetValue(obj, v);
        //var setter = property.GetSetMethod(true);
        //setter!.Invoke(obj, new object[] { v });
    }
}
