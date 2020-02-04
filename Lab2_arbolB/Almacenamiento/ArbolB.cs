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
             public Nodo izq = new Nodo();
             public Nodo der = new Nodo();             
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
                    insert_sheets(N, f, i, p, M,raiz.datos,raiz);
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
                        Aux(N, f, i, p, M, raiz.datos);
                        separar(ref raiz.datos, auxiliar, raiz, 0);
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
            public void Aux(string N, string f, int i, double p, string M, Bebidas[] nodos)
           {
            int entrada = 0;
            foreach (var item in nodos)
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
           }
           public void separar(ref Bebidas[] nodo, Bebidas[] nodo2, Nodo inicial, int num_hijos) 
           {           
            if (inicial.hijos[num_hijos] != null)///
            {
                int asignador = 0;
                inicial.hijos[num_hijos+ 2] = new Nodo();
                foreach (var item in inicial.hijos[num_hijos + 1].datos)
                {
                    inicial.hijos[num_hijos + 2].datos[asignador] = item;
                    asignador++;
                }
                Array.Clear(inicial.hijos[num_hijos+ 1].datos, 0, grado - 1);
            }
            int mitad = (nodo2.Length / 2);
            Array.Clear(nodo,0,grado-1);
            int cont = 0;
            foreach (var item in inicial.datos)
            {
                if (inicial.datos[0] == null)
                {
                    inicial.datos[0] = nodo2[mitad];
                    break;
                }
                if (cont+1>=inicial.datos.Length)
                {
                    inicial.datos[cont] = nodo2[mitad];
                    Ordenar(ref inicial.datos);
                    break;
                }
               if (inicial.datos[cont + 1] == null)
                {
                    inicial.datos[cont + 1] = nodo2[mitad]; //index
                    Ordenar(ref inicial.datos);
                    break;
                }
                cont++;
            }            
            izq.padre = inicial;
            if (inicial.hijos[num_hijos] != null)
            {
            Array.Clear(inicial.hijos[num_hijos].datos,0,grado-1);
            }            
            inicial.hijos[num_hijos] = izq; //index
            for (int llenado_izq = 0; llenado_izq < mitad; llenado_izq++)
            {
                inicial.hijos[num_hijos].datos[llenado_izq] = nodo2[llenado_izq];                    
            }            
            inicial.hijos[num_hijos + 1] = der; //index + 1 
            int contador = 0;
            for (int llenado_der = mitad + 1; llenado_der > mitad && llenado_der < nodo2.Length; llenado_der++)
            {
                inicial.hijos[num_hijos + 1].datos[contador] = nodo2[llenado_der];
                contador++;
            }
           }
        public void insert_sheets(string N, string f, int i, double p, string M, Bebidas[] nodo,Nodo nuevo)
        {
            int cont = 0;
            foreach (var item in nodo) ///revisar el foreach con mas numeros
            {
                if (nodo[cont+1] == null)
                {
                #region hijos a la derecha
                if (N.CompareTo(item.Name) > 0)
                {
                    int num = 0;
                    asignar(N, f, i, p, M, cont+1 , num , nuevo);
                    break;
                }
                #endregion
                #region hijos a la izquierda
                else
                {
                    int num = 0;
                    asignar(N, f, i, p, M, cont, num, nuevo);
                    break;
                }
                #endregion
                }
                cont++;
            }
        }
            public void asignar(string N, string f, int i, double p, string M,int cont ,int num, Nodo nuevo)
            {
            foreach (var nuevo_espacio in nuevo.hijos[cont].datos)
            {
                if (nuevo_espacio == null)
                {
                    nuevo.hijos[cont].datos[num] = new Bebidas()
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
                if (num == grado - 1) /// full
                {
                    Aux(N, f, i, p, M, nuevo.hijos[cont].datos);
                    separar(ref nuevo.hijos[cont].datos, auxiliar, nuevo.hijos[cont].padre,cont);
                }
              }
              Ordenar(ref nuevo.hijos[cont].datos);
            }
        #endregion
    }    
}
