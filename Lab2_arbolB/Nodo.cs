using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_arbolB
{
    public class Nodo
    { 
        public Nodo padre;
        static int grado = 5;
        public Bebidas[] datos = new Bebidas[grado - 1];
        public Nodo[] hijos = new Nodo[grado];
    }
}
