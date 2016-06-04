using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNETProjekatAutootpad.Models
{
    public class _Dio
    {
        
        public int ID { get; set; }
        public decimal ProdajnaCijena { get; set; }
        public string Model { get; set; }
        public string Proizvodjac { get; set; }
        public string ImeDijela { get; set; }
        public bool UProdaji { get; set; }
        public byte[] QR { get; set; }
        public byte[] Slika { get; set; }

    }
}