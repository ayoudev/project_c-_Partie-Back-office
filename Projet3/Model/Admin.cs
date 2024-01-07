using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet3.Model
{
    public class Admin
    {
        [Key]
        public int AdminID {  get; set; }
        public string nom {  get; set; }
        public string prenom {  get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
