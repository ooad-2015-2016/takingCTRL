using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAutootpad.Autootpad.ViewModels
{
    class DodavanjeDijelaRadnikViewModel
    {
        public List<Dio> ponudeniAutodijelovi { get; set; }

        public ICommand DodavanjeDijela { get; set; }

        public DodavanjeDijelaRadnikViewModel()
        {

            NavigationService = new NavigationService;
            DodavanjeDijela = new RelayCommand<object>(dodavanjeDijela, true);
        }

        public void dodavanjeDijela(object parametar)
        {

        }
    }
}
