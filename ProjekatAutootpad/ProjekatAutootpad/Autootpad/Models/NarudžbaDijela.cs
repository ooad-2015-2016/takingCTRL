using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAutootpad.Autootpad.Models
{
    class NarudžbaDijela
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NarudžbaDijelaId { get; set; }

        public string Proizvođač { get; set; }
        public string Model { get; set; }
        public string NazivDijela { get; set; }
        public bool Prihvaćena { get; set; }

        public NarudžbaDijela()
        {

        }

        public NarudžbaDijela(string proizvođač, string model, string naziv)
        {
            Proizvođač = proizvođač;
            Model = model;
            NazivDijela = naziv;
            Prihvaćena = false;

        }

        public NarudžbaDijela(Dio d)
        {
            Proizvođač = d.Proizvodjac;
            Model = d.Model;
            NazivDijela = d.ImeDijela;
            Prihvaćena = false;
        }
    }

    
}
