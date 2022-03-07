using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public interface IMediator
    {
        public void RequestAuthorization(IFlight caller, EnumAction action);
        public IFlight GetFlightByNumber(int flightNumber);
    }
}
