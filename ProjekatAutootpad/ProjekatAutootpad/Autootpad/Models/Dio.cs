using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjekatAutootpad.Autootpad.Models
{
    class Dio
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DioID { get; set; }

        public decimal ProdajnaCijena { get; set; }
        public string Model { get; set; }
        public string Proizvodjac { get; set; }
        public string ImeDijela { get; set; }
        public bool UProdaji { get; set; }

        [NotMapped]
        public decimal NabavnaCijena { get { return 1.1M * ProdajnaCijena; } private set { } }

        public Dio()
        {

        }

        public Dio(NarudžbaDijela nd, decimal cijena)
        {
            Model = nd.Model;
            Proizvodjac = nd.Proizvođač;
            ImeDijela = nd.NazivDijela;
            ProdajnaCijena = cijena;
            UProdaji = false;
        }
    }
}
