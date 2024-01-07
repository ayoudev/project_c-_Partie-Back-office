using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Projet3.Model
{
    public class Livres
    {
        [Key]
        public int LivreID { get; set; }
        public string titre { get; set; }
        public string Auteur { get; set; }
        public string Disponible { get; set; }
        public double Prix { get; set; }
        public int quantite { get; set; }
        public int CategorieID { get; set; }
        public string URLimage { get; set; }
        public byte[] Img { get; set; }
    }

   



}
