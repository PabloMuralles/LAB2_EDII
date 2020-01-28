using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_arbolB
{
    public class Nodo<T> where T : IComparable<T>
    {
        public string Name { get; set; }
        public string flavoe { get; set; }
        public int inventory { get; set; }
        public double price { get; set; }
        public string Made { get; set; }

        T[] Valore = new T[5-1];
        Nodo<T>[] hijos = new Nodo<T>[5];

    }
}
