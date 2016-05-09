using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatAutootpad.Autootpad.Models;
using System.ComponentModel;
using ProjekatAutootpad.Autootpad.Helper;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace ProjekatAutootpad.Autootpad.ViewModels
{
    class AdminPogledUposlenikaViewModel
    {
        public Radnik User { get; set; }
        public INavigationService NavigationService { get; set; }
        public ICommand IzmjenaRadnika { get; set; }
        public ICommand DodavanjeRadnika { get; set; }
        public ICommand BrisanjeRadnika { get; set; }


        List<Radnik> radnici
        {
            get
            {
                using (var db = new OtpadDbContext())
                {
                    return db.Radnici.ToList();
                }
            }
        }

        public AdminPogledUposlenikaViewModel()
        {
            NavigationService = new NavigationService();
            IzmjenaRadnika = new RelayCommand<object>(izmjenaRadnika);
            DodavanjeRadnika = new RelayCommand<object>(dodavanjeRadnika);
            BrisanjeRadnika = new RelayCommand<object>(brisanjeRadnika);
        }

        public void izmjenaRadnika(object parametar)
        {

        }

        public void dodavanjeRadnika(object parametar)
        {
            var db = new OtpadDbContext();
            db.Radnici.Add(new Radnik());
        }

        public void brisanjeRadnika(object parametar)
        {

        }

    }
}
