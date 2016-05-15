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
	public bool jeliPenzioner { get; set; }

        public List<string> obavijesti { get; set; }

        public Kupac()
        {

        }
        public Kupac(string imPR, string user, string pass, DateTime dRodj, string email, bool penzioner):base(imPR, user, pass, dRodj, email)
        {
            kupacId = 0;
            jeliPenzioner = penzioner;
        }
    }
}
