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
                    raiz = new Nodo(); 
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
                if (raiz.hijos[0] != null || raiz.hijos[1] != null)
                {
                    insert_sheets(N, f, i, p, M,raiz.datos);
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
                         if (num == grado-1) /// full
                         {
                        Aux(N, f, i, p, M);
                         }
                    }
                    Ordenar(ref raiz.datos); 
                  } // end add
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
           public void separar(ref Bebidas[] nodo, Bebidas[] nodo2, Nodo inicial) 
           {
            int mitad = (auxiliar.Length / 2);
            Array.Clear(nodo,0,grado-1);
            nodo[0] = nodo2[mitad]; //index
            var izq = new Nodo();
            izq.padre = inicial;
            inicial.hijos[0] = izq; //index
            for (int llenado_izq = 0; llenado_izq < mitad; llenado_izq++)
            {
                izq.datos[llenado_izq] = nodo2[llenado_izq];            
            }
            var der = new Nodo();
            inicial.hijos[1] = der; //index + 1
             int contador = 0;
            for (int llenado_der = mitad + 1; llenado_der > mitad && llenado_der < nodo2.Length; llenado_der++)
            {
                der.datos[contador] = nodo2[llenado_der];
                contador++;
            }
           }
        public void insert_sheets(string N, string f, int i, double p, string M, Bebidas[] nodo)
        {
            foreach (var item in nodo)
            {
               if (N.CompareTo(item.Name) > 0)
               {

               }                
            }
        }
        #endregion
    }
    
}
