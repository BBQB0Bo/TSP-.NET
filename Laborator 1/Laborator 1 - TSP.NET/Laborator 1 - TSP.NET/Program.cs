using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator_1___TSP.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            EventSubscriber sub = new EventSubscriber(10);
            sub.Printeaza();
        }
    }
}
