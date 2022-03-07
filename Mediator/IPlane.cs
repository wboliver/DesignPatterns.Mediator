using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public interface IFlight
    {
        public bool  Land();
        public bool  TakeOff();
        public bool  Wait();
        public int Number { get; set; }
        public DateTime DepartureTime { get; set; }
    }


    public class Flight : IFlight
    {
        private readonly IMediator _mediator;
        public int Number { get; set; }
        public DateTime DepartureTime { get; set; }

        public Flight(IMediator mediator, int flightNumber, DateTime departureTime)
        {
            _mediator = mediator;
            Number = flightNumber;
            DepartureTime = departureTime;

        }


        public bool Land()
        {
            Console.WriteLine($"{Number} is Landing");
            return true;
        }

        public bool TakeOff()
        {
            Console.WriteLine($"{Number} is Taking off");
            return true;
        }


        public bool Wait()
        {
            Console.WriteLine($"{Number} is waiting");
            return true;
        }

    }


}


