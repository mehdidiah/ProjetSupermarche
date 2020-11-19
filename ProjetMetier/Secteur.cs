using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProjetMetier
{
    public class Secteur
    {
        private int numSecteur;
        private string nomSecteur;

        public Secteur(int unNumS, string unNomS)
        {
            NumSecteur = unNumS;
            NomSecteur = unNomS;
        }

        public int NumSecteur { get => numSecteur; set => numSecteur = value; }
        public string NomSecteur { get => nomSecteur; set => nomSecteur = value; }
    }
}
