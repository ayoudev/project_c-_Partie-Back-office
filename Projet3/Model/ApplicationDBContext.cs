using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet3.Model
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<test> test { get; set; }
       public DbSet<Livres> Livres { get; set; }
       public DbSet<Categorie> Categorie { get; set; }
        public DbSet<Adherents> Adherents { get; set; }

        public DbSet<Employe> Employe { get; set; }

        public DbSet<Poste> Poste { get; set; }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Reservation> Reservation { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-I5O01QK\SQLEXPRESS;Encrypt=False;Initial Catalog=pfa;Integrated Security=True");
        }
    }
}
