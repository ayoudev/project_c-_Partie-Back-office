using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet3.Model
{
    public class Categorie
    {
        [Key]
        public int CategorieID { get; set; }
        public string Nom { get; set; }

    }
}
