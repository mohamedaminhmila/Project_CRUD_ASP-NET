using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GSoutenance.Models;

    public class SoutenanceContext : DbContext
    {
        public SoutenanceContext (DbContextOptions<SoutenanceContext> options)
            : base(options)
        {
        }

 public DbSet<Ensignant> Ensignant { get; set; } = default!;

public DbSet<Etudiant> Etudiant { get; set; } 
public DbSet<Pfe> Pfe { get; set; }

public DbSet<Pfe_Etudiant> Pfe_Etudiant { get; set; } 

public DbSet<Societe> Societe { get; set; }
    }
