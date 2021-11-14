using MongoDB.Bson;
using System;

namespace TP214E.Data
{
    public class TypeAliment
    {
        public ObjectId Id;
        public string nom;
        public int quantite;
        public string unite;


        public string Nom
        {
            get { return nom; }
            set
            {
                string strNom = value;

                if (strNom == "")
                {
                    throw new ArgumentException("Le nom de l'aliment est vide");
                }
                nom = strNom;
            }
        }

        public int Quantite
        {
            get { return quantite; }
            set
            {
                int iQuantite = value;

                if (iQuantite <= 0)
                {
                    throw new ArgumentException("La quantité n'est pas supérieure a 0");
                }
                quantite = iQuantite;
            }
        }

        public string Unite
        {
            get { return unite; }
            set
            {
                string strUnite = value;

                if (strUnite == "")
                {
                    throw new ArgumentException("Entrez une unité valide");
                }
                unite = strUnite;
            }
        }

        public TypeAliment(string pNom, string pUnite, int pQuantite)
        {
            this.Id = ObjectId.GenerateNewId();
            Nom = pNom;
            Unite = pUnite;
            Quantite = pQuantite;
        }

        public override string ToString()
        {
            return  this.Nom +
                    " Qté: " + this.Quantite +
                    " " + this.Unite;
        }
    }
}
