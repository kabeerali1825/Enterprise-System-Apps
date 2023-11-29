using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_8
{
    
    internal class State_Design_Pattern
    {
         //Example-01-BITF20M018
        // Context
        public class Fan
        {
            private IFanState currentState;

            public Fan()
            {
                currentState = new OffState();
            }

            public void SetState(IFanState state)
            {
                currentState = state;
            }

            public void PullChain()
            {
                currentState.HandleRequest(this);
            }
        }
        public interface IFanState
        {
            void HandleRequest(Fan fan);
        }
        public class OffState : IFanState
        {
            public void HandleRequest(Fan fan)
            {
                Console.WriteLine("Turning fan on low");
                fan.SetState(new LowState());
            }
        }

        public class LowState : IFanState
        {
            public void HandleRequest(Fan fan)
            {
                Console.WriteLine("Turning fan on medium");
                fan.SetState(new MediumState());
            }
        }

        public class MediumState : IFanState
        {
            public void HandleRequest(Fan fan)
            {
                Console.WriteLine("Turning fan on high");
                fan.SetState(new HighState());
            }
        }

        public class HighState : IFanState
        {
            public void HandleRequest(Fan fan)
            {
                Console.WriteLine("Turning fan off");
                fan.SetState(new OffState());
            }
        }
        //Example-02-BITF20M018
        public class TrafficLight
        {
            private ITrafficLightState currentState;

            public TrafficLight()
            {
                currentState = new RedState();
            }

            public void SetState(ITrafficLightState state)
            {
                currentState = state;
            }

            public void Change()
            {
                currentState.Change(this);
            }
        }

        // State interface
        public interface ITrafficLightState
        {
            void Change(TrafficLight trafficLight);
        }

        // Concrete states
        public class RedState : ITrafficLightState
        {
            public void Change(TrafficLight trafficLight)
            {
                Console.WriteLine("Changing to green");
                trafficLight.SetState(new GreenState());
            }
        }

        public class GreenState : ITrafficLightState
        {
            public void Change(TrafficLight trafficLight)
            {
                Console.WriteLine("Changing to red");
                trafficLight.SetState(new RedState());
            }
        }
    }
}
