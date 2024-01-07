using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet3.Model
{
    public class Employe
    {
        [Key]
        public string Matricule { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int idPost { get; set; }
        public DateTime DateEmbauche { get; set; }
        public decimal Salaire { get; set; }
        public string Adresse { get; set; }
        public string NumeroTelephone { get; set; }
    }
}
