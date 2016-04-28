using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAutootpad.Autootpad.Models
{
    class Kupac: Korisnik
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int kupacId { get; set; }

        public List<string> obavijesti { get; set; }
    }
}
