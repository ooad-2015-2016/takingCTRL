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
    class DodavanjeDijelaRadnik
    {
        public ICommand DodajDio { get; set; }
        public ICommand OtkaziDodavanje { get; set; }
        public ICommand OdbijPonuduDijela { get; set; }

        List<Dio> ponudeniAutodijelovi
        {
            get
            {
                using (var db = new OtpadDbContext())
                {
                    return db.ponudeniDijelovi.ToList();
                }
            }
        }

        public void DodajPonudeniDio()
        {
            DodajDio = new RelayCommand<object>(dodaj, mozeLiSeDodati);
        }
        public void OdbijPonudeniDio()
        {
            OdbijPonuduDijela = new RelayCommand<object>(odbij, mozeLiSeDodati);
        }


        public void dodaj(object parametar)
        {
            var db = new OtpadDbContext();
            db.Dijelovi.Add(); // Dodavanje u listu Dijelovi koja sluzi za Dijelove koji su u prodaji
        }

        public void odbij(object parametar)
        {

        }

        public bool mozeLiSeDodati(object parametar) // Za sada ovu funkciju koristimo i za odbijanje ponuđenog dijela
        {
            return true;
        }

    }
}
