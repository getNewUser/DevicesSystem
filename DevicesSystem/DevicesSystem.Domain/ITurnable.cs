using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevicesSystem.Domain
{
    public interface ITurnable
    {
        Guid Id { get;}
        void TurnOn();
        void TurnOff();
    }
}
