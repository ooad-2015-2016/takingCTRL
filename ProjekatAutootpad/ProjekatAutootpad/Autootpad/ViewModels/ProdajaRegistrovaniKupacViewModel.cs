using ProjekatAutootpad.Autootpad.Helper;
using ProjekatAutootpad.Autootpad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjekatAutootpad.Autootpad.ViewModels
{
    class ProdajaRegistrovaniKupacViewModel
    {
        public decimal cijena { get; set; }
        public List<Dio> trazeniDijelovi
        {
            get
            {
                using (var db = new OtpadDbContext())
                {
                    return db.trazeniDijelovi.ToList();
                }
            }
        }

        public ICommand ponudi { get; set; }
        public ICommand otkazi { get; set; }

        public Dio selectedDio { get; set; }


        void ponudiDio(object parametar)
        {
            ponudi = new RelayCommand<object>(dodavanje, mozeLiSeDodati);
        }

        void dodavanje(object parametar)
        {
            var db = new OtpadDbContext();
            db.ponudeniDijelovi.Add(selectedDio);
        }

        bool mozeLiSeDodati(object parametar)
        {
            return true;
        }

    }
}
