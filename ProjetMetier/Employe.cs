using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetMetier
{
    public class Employe
    {
        private int numE;
        private string prenomE;

        public Employe(int unNum, string unPrenom)
        {
            NumE = unNum;
            PrenomE = unPrenom;
        }

        public int NumE { get => numE; set => numE = value; }
        public string PrenomE { get => prenomE; set => prenomE = value; }
    }
}
