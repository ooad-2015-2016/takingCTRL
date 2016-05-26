using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatAutootpad.Autootpad.Helper
{
    public interface ITriggerValue
    {
        bool IsActive { get; }
        event EventHandler IsActiveChanged;
    }
}
