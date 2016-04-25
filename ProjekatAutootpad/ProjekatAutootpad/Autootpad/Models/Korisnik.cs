using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAutootpad.Autootpad.Models
{
    class Korisnik
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KorisnikId { get; set; }

        public string imePrezime { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public DateTime datumRodjenja { get; set; }
        public string email { get; set; }
    }
}
