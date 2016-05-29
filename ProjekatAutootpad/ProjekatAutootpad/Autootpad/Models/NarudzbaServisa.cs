using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAutootpad.Autootpad.Models
{
    class NarudzbaServisa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NarudzbaServisaId { get; set; }

        public string opisKvara { get; set; }
        public Kupac narucilac { get; set; }

        public string Model { get; set; }
        public string Proizvodjac { get; set; }
        public string NacinPlacanja { get; set; }
    }
}

