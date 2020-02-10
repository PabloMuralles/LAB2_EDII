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
            public static int grado = 7;
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
            if(num_hijos < grado - 1)
            {
            if (inicial.hijos[num_hijos] != null)///
            {
                int asignador = 0;
                if (num_hijos == 0)
                {
                    inicial.hijos[num_hijos + 2] = new Nodo();
                    foreach (var item in inicial.hijos[num_hijos + 1].datos)
                    {
                        inicial.hijos[num_hijos + 2].datos[asignador] = item;
                        asignador++;
                    }
                }
                else
                {
                        if (num_hijos != 4)
                        {
                         inicial.hijos[num_hijos + 1] = new Nodo();
                        }
                    foreach (var item in inicial.hijos[num_hijos].datos)
                    {
                        inicial.hijos[num_hijos + 1].datos[asignador] = item;
                        asignador++;
                    }
                }
                Array.Clear(inicial.hijos[num_hijos + 1].datos, 0, grado - 1);
            }
            }
            int mitad = (nodo2.Length / 2);
            Array.Clear(nodo,0,grado-1);
            int cont = 0;
            foreach (var item in inicial.datos)
            {
                if (inicial.datos[grado-2] != null)
                {
                    var temporal = new Bebidas[grado];
                    var Nueva_raiz = new Nodo();
                    int entrada = 0;
                    foreach (var asignacion in inicial.datos)
                    {
                        temporal[entrada]= asignacion;
                        entrada++;
                    }
                    temporal[entrada] = auxiliar[mitad];                   
                    Ordenar(ref temporal);
                    Nueva_raiz.datos[0] = temporal[mitad];
                    inicial.padre = Nueva_raiz;
                   
                }
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
            if (inicial.hijos[num_hijos] != null)
            {
            Array.Clear(inicial.hijos[num_hijos].datos,0,grado-1);
            }            
           
            inicial.hijos[num_hijos] = new Nodo(); //index
            for (int llenado_izq = 0; llenado_izq < mitad; llenado_izq++)
            {
                inicial.hijos[num_hijos].datos[llenado_izq] = nodo2[llenado_izq];                    
            }          
            inicial.hijos[num_hijos + 1] = new Nodo(); //index + 1 
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
            foreach (var item in nodo)
            {
                if (cont == grado - 2)
                {
                    for (int contar_padres = 0; contar_padres < nuevo.datos.Length; contar_padres++)
                    {
                        if (N.CompareTo(nuevo.datos[contar_padres].Name) > 0)
                        {
                            asignar(N, f, i, p, M, cont + 1, 0, nuevo);
                            break;
                        }
                    }
                }
                else 
                { 
                if (nodo[cont+1] == null)
                {
                #region hijos a la derecha
                if (N.CompareTo(item.Name) > 0)
                {                   
                    asignar(N, f, i, p, M, cont+1 , 0 , nuevo);
                    break;
                }
                #endregion
                #region hijos a la izquierda
                else
                {                    
                    asignar(N, f, i, p, M, cont, 0, nuevo);
                    break;
                }
                #endregion
                }
                cont++;
                }
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
                        separar(ref nuevo.hijos[cont].datos, auxiliar, nuevo, cont);                                              
                    }                         
                }
                Ordenar(ref nuevo.hijos[cont].datos);                  
            }
              public void Nueva_Raiz(Bebidas[] anterior,Bebidas[] concatenacion, int num_hijo, Nodo root)
              {
                var nuevo = new Nodo();
               var temporal = new Bebidas[grado - 1];
               int mitad = (concatenacion.Length/2);
               Array.Clear(anterior, 0, grado - 1);               
                 temporal = concatenacion;
                Aux(anterior[mitad].Name,anterior[mitad].flavor, anterior[mitad].inventory, anterior[mitad].price, anterior[mitad].Made,root.padre.datos);               
            if (nuevo.datos[0] == null)
                {
                nuevo.datos[0] = auxiliar[mitad];
                }              
                nuevo.hijos[0] = new Nodo(); //index
                 for (int llenado_izq = 0; llenado_izq < mitad; llenado_izq++)
                 {
                nuevo.hijos[0].datos[llenado_izq] = auxiliar[llenado_izq];
                 }
            nuevo.hijos[0 + 1] = new Nodo(); //index + 1 
            int contador = 0;
            for (int llenado_der = mitad + 1; llenado_der > mitad && llenado_der < auxiliar.Length; llenado_der++)
            {
                nuevo.hijos[0 + 1].datos[contador] = auxiliar[llenado_der];
                contador++;
            }
            raiz.datos = nuevo.datos;
            raiz.hijos[0] = nuevo.hijos[0];
            raiz.hijos[1] = nuevo.hijos[1];
         
        }
        #endregion

        public Bebidas Buscar(string _nombre)
        {
            Bebidas bebida = raiz.Busqueda(_nombre);
            return bebida;
        }
    }    
}
