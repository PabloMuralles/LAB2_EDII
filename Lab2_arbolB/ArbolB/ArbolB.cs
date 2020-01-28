using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_arbolB.ArbolB
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
          
        public void Add()
        {
            
        }
        public void find()
        {

        }
    }
}
