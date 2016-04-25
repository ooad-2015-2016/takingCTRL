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
        public decimal NabavnaCijena { get; set; }
        public decimal ProdajnaCijena { get; set; }
        public string Model { get; set; }
        public string Proizvodjac { get; set; }
    }
}
