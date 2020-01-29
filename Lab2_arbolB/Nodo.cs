using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_arbolB
{
    public class Nodo<T> where T : IComparable<T>
    {
        public Nodo<T> Raiz;
        public List<object> datos = new List<object>();
        public List<Nodo<T>> hijos = new List<Nodo<T>>();
        public Bebidas bebidas;
    }
}
