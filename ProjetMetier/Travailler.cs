using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetMetier
{
    public class Travailler
    {
        private string nomRayon;
        private string uneDate;
        private int temps;

        public Travailler(string unNomRayon, string laDate, int leTemps)
        {
            NomRayon = unNomRayon;
            UneDate = laDate;
            Temps = leTemps;
        }

        public string NomRayon { get => nomRayon; set => nomRayon = value; }
        public string UneDate { get => uneDate; set => uneDate = value; }
        public int Temps { get => temps; set => temps = value; }
    }
}
