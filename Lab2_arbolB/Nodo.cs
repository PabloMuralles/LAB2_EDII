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


        public Bebidas Busqueda(string nombre)
        {
            Bebidas BebidaBuscada = new Bebidas();
            for (int i = 0; i < grado-1; i++)
            {
                int x = (String.Compare(nombre, datos[i].Name));

                if (String.Compare(nombre,datos[i].Name) == -1)
                {
                    hijos[i].Busqueda(nombre);
                }

                if (String.Compare(nombre,datos[i].Name) == 1)
                {
                    if (datos[i+1]==null)
                    {
                        hijos[i+1].Busqueda(nombre);

                    }
                    else
                    {
                        if (String.Compare(nombre, datos[i + 1].Name) == -1)
                        {
                            hijos[i].Busqueda(nombre);
                        }
                    }
                   
                    
                         


                }
               

                if (String.Compare(nombre,datos[i].Name) == 0)
                {
                     

                    BebidaBuscada.Name = datos[i].Name;
                    BebidaBuscada.flavor = datos[i].flavor;
                    BebidaBuscada.inventory = datos[i].inventory;
                    BebidaBuscada.price = datos[i].price;
                    BebidaBuscada.Made= datos[i].Made;


                    break;

                }

            

            }

            return BebidaBuscada;
        }
    }
}
