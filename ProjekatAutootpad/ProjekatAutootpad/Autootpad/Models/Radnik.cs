using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAutootpad.Autootpad.Models
{
    class Radnik: Korisnik
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int radnikId { get; set; }

        public List<Servis> rasporedServisa { get; set; }
    }
}
