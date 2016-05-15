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
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public int KorisnikId { get; set; }

        public string imePrezime { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Email { get; set; }

        public Korisnik()
        {

        }
	public Korisnik(string imPr, string user, string pass, DateTime dRodj, string email)
        {
            imePrezime = imPr;
            Username = user;
            Password = pass;
            DatumRodjenja = dRodj;
            Email = email;
        }
    }
}
