using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrimeChemicalConnectionsCalculator;
using ChemicalConnectionsDB.Models;

namespace ChemicalConnectionsDB
{
    public class ChemicalContext:DbContext
    {
        public DbSet<ChemicalConnectionModel> ChemicalConnectionModels { get; set; }
        public DbSet<ChemicalElementModel> ChemicalElementModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TestEFcore;Trusted_Connection=True;");
    }

    
    
}
