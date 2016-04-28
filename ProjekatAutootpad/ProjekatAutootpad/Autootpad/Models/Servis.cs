using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAutootpad.Autootpad.Models
{
    class Servis
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int servisId { get; set; }

        public decimal cijena { get; set; }
        public bool odraden { get; set; }
        public NarudzbaServisa narudzba { get; set; }
    }
}
