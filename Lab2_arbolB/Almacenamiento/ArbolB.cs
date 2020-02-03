using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_arbolB.Almacenamiento
{
    public class ArbolB
        {
            private static ArbolB _instance = null;
            public static ArbolB Instance
            {
                get
                {
                    if (_instance == null) _instance = new ArbolB();
                    return _instance;
                }
            }
            public static int grado = 5;
            public Nodo raiz = null;
            public Bebidas[] auxiliar = new Bebidas[grado];
            #region Metodos          
            public void Add(string N, string f, int i, double p, string M)
            {
               if (raiz == null)
                {
                    raiz = new Nodo();  /////
                    raiz.datos[0] = new Bebidas()
                    {
                        Name = N,
                        flavor = f,
                        inventory = i,
                        price = p,
                        Made = M,
                    };
                }
                else
                {
                   int num = 0;
                    foreach (var espasio in raiz.datos)
                    {
                        if (espasio == null && num < grado-1)
                        {
                        raiz.datos[num] = new Bebidas()
                        {
                            Name = N,
                            flavor = f,
                            inventory = i,
                            price = p,
                            Made = M,
                        };
                          break;
                        }
                       num++;
                         if (num == grado-1) // esta lleno
                         {
                        Aux(N, f, i, p, M);
                         }
                    }
                    Ordenar(ref raiz.datos); /// metodo de ordenamiento
                }
            }
            public void Ordenar(ref Bebidas[] valores)
            {
            var lista = new List<Bebidas>();
            foreach (var iteraciones in valores)
            {
                if (iteraciones != null)
                {
                    lista.Add(iteraciones);
                }
            }
            lista = lista.OrderBy( x => x.Name).ToList(); 
            var contador = 0;
            foreach (var item in lista)
            {
                valores[contador] = item;
                contador++;
            }
        }       
            public void Aux(string N, string f, int i, double p, string M)
           {
            int entrada = 0;
            foreach (var item in raiz.datos)
            {
                auxiliar[entrada] = item;
                entrada++;
            }
            auxiliar[entrada] = new Bebidas()
            {
                Name = N,
                flavor = f,
                inventory = i,
                price = p,
                Made = M,
            };
            Ordenar(ref auxiliar);

            separar(ref raiz.datos, auxiliar, raiz);
           }
           public void separar(ref Bebidas[] nodo, Bebidas[] nodo2, Nodo inicial) /// podria pasar aux como 
           {
            int mitad = (auxiliar.Length / 2);
            Array.Clear(nodo,0,grado-1);
            nodo[0] = nodo2[mitad];
            Nodo sub = new Nodo();
            sub.padre = inicial;
            for (int llenado = 0; llenado < mitad; llenado++)
            {
                sub.hijos[llenado].datos[llenado] = nodo2[llenado];
             //   sub = nodo2[llenado];
             //raiz.hijos[llenado].datos[llenado] = sub;
            }
           }
            #endregion
        }
    
}
