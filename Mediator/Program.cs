using System;
using System.Collections.Generic;
using System.Linq;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tuple<int, DateTime>> flights = new List<Tuple<int, DateTime>>();

            flights.Add(new Tuple<int, DateTime>(123456, new DateTime(2022, 3, 1, 5, 50, 00)));
            flights.Add(new Tuple<int, DateTime>(321595, new DateTime(2022, 3, 1, 6, 30, 00)));

            IMediator mediator = new Mediator(flights);


            //voo 123456 pedindo autorização para pousar 
            var request = mediator.GetFlightByNumber(123456);
            if (request != null)
            {
                mediator.RequestAuthorization(request, EnumAction.Land);
            }


            //voo 321595 pedindo autorização para decolar 
            request = mediator.GetFlightByNumber(321595);
            if (request != null)
            {
                mediator.RequestAuthorization(request, EnumAction.TakeOff);
            }


            Console.ReadLine();


            
        }
    }
}
