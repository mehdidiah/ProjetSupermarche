using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetMetier
{
    public class Rayon
    {
        private int numR;
        private string nomR;

        public Rayon(int unNumR, string unNomR)
        {
            NumR = unNumR;
            NomR = unNomR;
        }

        public int NumR { get => numR; set => numR = value; }
        public string NomR { get => nomR; set => nomR = value; }
    }
}
