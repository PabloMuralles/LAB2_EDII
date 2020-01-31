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
            public Nodo[] auxiliar = new Nodo[grado - 1];
            #region Metodos          
            public void Add(string N, string f, int i, double p, string M)
            {
                if (raiz == null)
                {
                    raiz = new Nodo();  /////
                    raiz.datos[0] = new Bebidas()
                    {
                        Name = N,
                        flavoe = f,
                        inventory = i,
                        price = p,
                        Made = M,
                    };
                }
                else
                {

                    raiz = new Nodo();  /////
                    for (int num = 1; num > raiz.datos.Length; num++)
                    {
                        raiz.datos[num] = new Bebidas()
                        {
                            Name = N,
                            flavoe = f,
                            inventory = i,
                            price = p,
                            Made = M,
                        };

                    }
                    //int n = 0;
                    //foreach ( var item in raiz.datos)
                    //{                                       
                    //}            
                }
            }
            public Bebidas[] Ordenar()
            {
                return null;
            }
            #endregion
        }
    
}
