using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator_1___TSP.NET
{
    public class EventSubscriber
    {
        private int valoare;

        private Event eventHelper;

        /*Handler*/
        void Helper()
        {
            Console.WriteLine("Handler Event : se va printa o valoare");
        }

        public EventSubscriber(int val)
        {
            valoare = val;

            eventHelper = new Event();

            eventHelper.atentionareEvent += Helper;
        }

        public void Printeaza()
        {
            eventHelper.Afisare(valoare);
        }


    }
}
