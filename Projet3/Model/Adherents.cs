using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet3.Model
{
    public class Adherents
    {
        [Key]
        public int AdherentID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string telephone { get; set; }
        public string adresse { get; set; }
        public string Email { get; set; }
    }
}
