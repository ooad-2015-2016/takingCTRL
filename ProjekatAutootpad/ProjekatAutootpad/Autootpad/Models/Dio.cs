using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ProjekatAutootpad.Autootpad.Models
{
    [DataContract]
    class Dio
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public int DioID { get; set; }
        [DataMember]
        public decimal ProdajnaCijena { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public string Proizvodjac { get; set; }
        [DataMember]
        public string ImeDijela { get; set; }
        [DataMember]
        public bool UProdaji { get; set; }
        [DataMember]
        public byte[] QR { get; set; }
        [DataMember]
        public byte[] Slika { get; set; }
        
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
