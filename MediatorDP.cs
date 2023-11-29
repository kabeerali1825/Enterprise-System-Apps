using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_8
{
    internal class Mediator_Design_Pattern
    {
        //Example-01- Mediator Design Pattern
        // Mediator Design Pattern
        public interface IChatMediator
        {
            void SendMessage(string message, IUser user);
            void RegisterUser(IUser user);
        }

        // Concrete mediator for chat
        public class ChatRoom : IChatMediator
        {
            private readonly List<IUser> users = new List<IUser>();

            public void RegisterUser(IUser user)
            {
                users.Add(user);
            }

            public void SendMessage(string message, IUser user)
            {
                foreach (var u in users)
                {
                    if (u != user)
                        u.Receive(message);
                }
            }
        }

        // Colleague interface
        public interface IUser
        {
            void Send(string message);
            void Receive(string message);
        }

        // Concrete colleague
        public class User : IUser
        {
            private readonly IChatMediator mediator;
            private readonly string name;

            public User(IChatMediator mediator, string name)
            {
                this.mediator = mediator;
                this.name = name;
                mediator.RegisterUser(this);
            }

            public void Send(string message)
            {
                Console.WriteLine($"{name} sends: {message}");
                mediator.SendMessage(message, this);
            }

            public void Receive(string message)
            {
                Console.WriteLine($"{name} receives: {message}");
            }
        }
        //Example-02- Mediator Design Pattern
        public interface IAirTrafficControl
        {
            void RegisterFlight(Flight flight);
            void SendMessage(string message, Flight sender);
        }

        // Concrete mediator for air traffic control
        public class AirTrafficControl : IAirTrafficControl
        {
            private readonly List<Flight> flights = new List<Flight>();

            public void RegisterFlight(Flight flight)
            {
                flights.Add(flight);
            }

            public void SendMessage(string message, Flight sender)
            {
                foreach (var flight in flights)
                {
                    if (flight != sender)
                        flight.ReceiveMessage(message);
                }
            }
        }

        // Colleague interface
        public interface IFlight
        {
            void SendMessage(string message);
            void ReceiveMessage(string message);
        }

        // Concrete colleague
        public class Flight : IFlight
        {
            private readonly IAirTrafficControl atc;
            private readonly string flightNumber;

            public Flight(IAirTrafficControl atc, string flightNumber)
            {
                this.atc = atc;
                this.flightNumber = flightNumber;
                atc.RegisterFlight(this);
            }

            public void SendMessage(string message)
            {
                Console.WriteLine($"Flight {flightNumber} sends: {message}");
                atc.SendMessage(message, this);
            }

            public void ReceiveMessage(string message)
            {
                Console.WriteLine($"Flight {flightNumber} receives: {message}");
            }
        }

    }
}
