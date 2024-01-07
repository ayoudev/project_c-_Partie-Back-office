using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet3.Model
{
    public class Poste
    {
        [Key]
        public int idPost { get; set; }
        public string type { get; set; }
    }
}
