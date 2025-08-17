using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class EmpresaContext : DbContext
{
    public DbSet<Empresa> Empresas { get; set; }

    public string DbPath { get; }

    public EmpresaContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "Empresa.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        //Microsoft.EntityFrameworkCore.Sqlite
        options.UseSqlite($"Data Source={DbPath}");
    }
}
