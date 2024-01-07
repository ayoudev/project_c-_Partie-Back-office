using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet3.Model
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }
        public DateTime DateReservation { get; set; }
        public DateTime DateRetourPrevu { get; set; }
        public string EstEmprunte { get; set; }

        public int AdherentID { get; set; }
        public int LivreID { get; set; }
    }
}
