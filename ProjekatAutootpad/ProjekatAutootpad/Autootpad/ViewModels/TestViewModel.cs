using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAutootpad.Autootpad.ViewModels
{
    class TestViewModel
    {

        public string Test {get;set;}

        public TestViewModel(AdminPogledUposlenikaViewModel apuvm)
        {
            Test = "test";
        }
    }
}
