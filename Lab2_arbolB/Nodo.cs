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

        public void Buscar(string nombre)
        {
            for (int i = 0; i < grado-2; i++)
            {
                if ((String.Compare((datos[i].Name),nombre)) == -1)
                {
                    // HIJO IZQUIERDO EN LA MISMA POSICION
                }

                if ((String.Compare((datos[i].Name), nombre)) == 1)
                {
                    // PRUEVO CON LA POSICION SIGUIENTE
                }

                if ((String.Compare((datos[i].Name), nombre)) == 0)
                {
                    // PRUEVO CON LA POSICION SIGUIENTE
                }

            }

        }
    }
}
