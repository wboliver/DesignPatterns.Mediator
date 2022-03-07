using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public class Mediator : IMediator
    {
        private List<IFlight> Flights { get; set; } = new List<IFlight>();

        public Mediator(List<Tuple<int, DateTime>> flights)
        {
            //adiciono os voos 
            foreach (var flight in flights)
            {
                Flights.Add(new Flight(this, flight.Item1, flight.Item2));
            }
        }

        public IFlight GetFlightByNumber(int flyNumber) => 
            Flights.FirstOrDefault(a => a.Number == flyNumber);


        private bool CheckTakeOffRules(IFlight caller)
        {
            return caller.DepartureTime == DateTime.Now;
        }

        private bool CheckLandingRules(IFlight caller)
        {
            //aqui as regras para pouso
            return true;
        }


        public void RequestAuthorization(IFlight caller, EnumAction action)
        {
            bool result = false;
            switch (action)
            {
                case EnumAction.TakeOff:
                    result = CheckTakeOffRules(caller) ? caller.TakeOff() : caller.Wait();
                    break;
                case EnumAction.Land:
                    result = CheckLandingRules(caller) ? caller.Land() : caller.Wait();
                    break;
                default:
                    break;
            }
        }
    }
}
