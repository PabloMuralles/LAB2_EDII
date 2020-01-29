using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_arbolB
{
    public class ArbolB<T> where T : IComparable<T>
    {
        private static ArbolB<T> _instance = null;
        public static ArbolB<T> Instance
        {
            get
            {
                if (_instance == null) _instance = new ArbolB<T>();
                return _instance;
            }
        }
        public Nodo<T> raiz = null;
        public List<Nodo<T>> auxiliar = new List<Nodo<T>>();
        int grado = 5;
        #region Metodos
        public void Crear(string N, string f, int i, double p, string M)
        {
            new Bebidas()
            {
                Name = N,
                flavoe = f,
                inventory = i,
                price = p,
                Made = M,
            };
            Bebidas bebidas = new Bebidas();
            raiz.bebidas = bebidas;
            Add(raiz.bebidas);
        }
        public void Add(object value)
        {
            if(raiz == null)
            {
                raiz = new Nodo<T>();
                if (raiz.hijos == null || raiz.datos.Count < grado-1)
                {
                    raiz.datos.Add(value);
                   Ordenar(raiz.datos); 
                    
                }

             
            }
        }
        void Ordenar(List<object> ordenamiento)
        {
            ordenamiento.Sort();
        }
        #endregion
    }
}
