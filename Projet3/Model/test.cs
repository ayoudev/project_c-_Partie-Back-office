using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet3.Model
{
    public class test
    {
        [Key]
        public int id {  get; set; }
        public string nom { get; set; }
    }
}
