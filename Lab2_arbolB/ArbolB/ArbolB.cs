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
        public static int grado = 5;
        public Nodo raiz = null;
        public Nodo[] auxiliar = new Nodo[grado - 1];
        #region Metodos    
        public void ArbolOrden()
        {
            raiz.nodos(grado);
        }
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
           
         }
        public void Add(object value)
        {
            if(raiz == null)
            {
                raiz = new Nodo();

             
            }
        }
        void Ordenar(List<object> ordenamiento)
        {
            ordenamiento.Sort();
        }
        #endregion
    }
}
