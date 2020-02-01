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
                        flavor = f,
                        inventory = i,
                        price = p,
                        Made = M,
                    };
                }
                else
                {
                   int num = 1;
                    foreach (var espasio in raiz.datos)
                    {
                        if (espasio == null)
                        {
                        raiz.datos[num] = new Bebidas()
                        {
                            Name = N,
                            flavor = f,
                            inventory = i,
                            price = p,
                            Made = M,
                        };
                        }
                    Ordenar(raiz.datos);
                    num++;
                    }                             
                }
            }
            public void Ordenar(Bebidas[] valores)
            {
            var lista = valores.ToList();
            foreach (var iteraciones in valores)
            {
                if (iteraciones != null)
                {
                    lista.Add(iteraciones);
                }
            }
            lista = lista.OrderBy(o => o.Name).ToList();
            var contador = 0;
            foreach (var item in lista)
            {
                valores[contador] = item;
                contador++;
            }
        }
            #endregion
        }
    
}
