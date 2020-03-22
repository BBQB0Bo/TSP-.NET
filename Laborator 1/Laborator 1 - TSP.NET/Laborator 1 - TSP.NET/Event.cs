using System;

namespace Laborator_1___TSP.NET
{
    public class Event
    {
        public delegate void Atentionare();

        public event Atentionare atentionareEvent;

        public void Afisare(int number)
        {
            if (atentionareEvent != null)
                atentionareEvent();

            Console.WriteLine(number);
        }
    }
}
