using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;

namespace ProjetMetier
{
    public class GestionnaireBdd
    {
        //cnx sert à se connecter à la BDD
        private MySqlConnection cnx;
        //cmd sert à écrire nos requêtes 
        private MySqlCommand cmd;
        //dr permet de récupérer le jeu d'enregistrement de ma requête
        private MySqlDataReader dr;

        public GestionnaireBdd()
        {
            //La chaine va nous permettre de donner
            // 1) le nom du serveur
            // 2) le nom de la base de donnée
            // 3) le nom de l'utilisateur
            // 4) le nom de le mot de passe
            string chaine = "Server =localhost; Database =supermarche; Uid =root; Pwd =";
            cnx = new MySqlConnection(chaine);
            cnx.Open();
        }

        public List<Secteur> GetAllSecteurs()
        {
            List<Secteur> lesSecteurs = new List<Secteur>();
            cmd = new MySqlCommand("select numS, nomS from secteur ", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Secteur unSecteur = new Secteur(Convert.ToInt16(dr[0].ToString()), dr[1].ToString() );
                lesSecteurs.Add(unSecteur);
            }
            dr.Close();
            return lesSecteurs;            
        }

        public List<Rayon> GetAllRayonsByNumS(int numS)
        {
            List<Rayon> lesRayons = new List<Rayon>();
            cmd = new MySqlCommand("select numR, nomR from rayon where numSecteur = "+numS , cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Rayon unRayon = new Rayon(Convert.ToInt16(dr[0].ToString()), dr[1].ToString());
                lesRayons.Add(unRayon);
            }
            dr.Close();
            return lesRayons;
        }

        public List<Employe> GetAllEmployes()
        {
            List<Employe> lesEmployes = new List<Employe>();
            cmd = new MySqlCommand("select numE, prenomE from employe", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Employe unEmploye = new Employe(Convert.ToInt16(dr[0]), dr[1].ToString());
                lesEmployes.Add(unEmploye);
            }
            dr.Close();
            return lesEmployes;
        }

        public int GetLastNumEmploye()
        {
            int max;
            cmd = new MySqlCommand("select max(numE) from employe", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            max = Convert.ToInt16(dr[0].ToString()) + 1;
            dr.Close();
            return max;
        }

        public void InsererEmploye(int numEmploye, string nomEmploye)
        {
            cmd = new MySqlCommand("insert into employe values(" + numEmploye + ", '" + nomEmploye + "')", cnx);
            cmd.ExecuteNonQuery();
        }
        public List<Rayon> GetAllRayons()
        {
            List<Rayon> lesRayons = new List<Rayon>();
            cmd = new MySqlCommand("select numR, nomR from rayon", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Rayon unRayon = new Rayon(Convert.ToInt16(dr[0]), dr[1].ToString());
                lesRayons.Add(unRayon);
            }
            dr.Close();
            return lesRayons;
        }
        
        public List<Travailler> GetTravaillerEmploye(int numEmploye)
        {            
            List<Travailler> lesHeures = new List<Travailler>();
            cmd = new MySqlCommand("select nomR, date, temps from travailler t INNER JOIN rayon r on t.codeR = r.numR where codeE = "+numEmploye, cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Travailler uneHeure = new Travailler(dr[0].ToString(), dr[1].ToString(), Convert.ToInt16(dr[2]));
                lesHeures.Add(uneHeure);
            }
            dr.Close();
            return lesHeures;
        }

        public void InsererUnHoraire(int numEmploye, int unNumRayon, string uneDate, int unTemps)
        {
            cmd = new MySqlCommand("insert into travailler values(" + numEmploye + ", " + unNumRayon + ", '" + uneDate + "', " + unTemps + ")", cnx);
            cmd.ExecuteNonQuery();
        }

        public bool VerificationRayon(int numEmploye, int unNumRayon, string uneDate)
        {
            bool verif = true;
            int compteur = 0;
            cmd = new MySqlCommand("select count(codeR) from travailler WHERE codeE = "+ numEmploye + " and date = " + uneDate + "and codeR = " + unNumRayon , cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            compteur = Convert.ToInt16(dr[0].ToString());
            dr.Close();
            return verif;
        }
    }
}
