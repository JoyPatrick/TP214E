using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public enum CategorieDeRecette
    {
        Burger,
        Poutine,
        Pizza,
        Salade
    }


    public class Recette
    {

        private ObjectId Id { get; set; }



        private string nomRecette;

        private string descriptionRecette;

        private CategorieDeRecette categorieRecette;
        private List<(TypeAliment, int)> lstTypeAliment;

        private int tempsMoyenRecette;

        private decimal cout;


        public string NomRecette
        {
            get { return nomRecette; }
            set
            {
                string strNomRecette = value;

                if (strNomRecette == "")
                {
                    throw new ArgumentException("Le nom de la recette est vide");
                }
                nomRecette = strNomRecette;
            }
        }

        public string DescriptionRecette
        {
            get { return descriptionRecette; }
            set
            {
                string strDescritpionRecette = value;

                if (strDescritpionRecette == "")
                {
                    throw new ArgumentException("La description de la recette est vide");
                }
                descriptionRecette = strDescritpionRecette;
            }
        }
        public List<(TypeAliment, int)> ListeTypeAliments
        {
            get { return lstTypeAliment; }
            set
            {
                List<(TypeAliment, int)> listeTypeAliments = value;

                if (listeTypeAliments.Count == 0)
                {
                    throw new ArgumentException("Le nom de la recette est vide");
                }
                lstTypeAliment = listeTypeAliments;
            }
        }

        public int TempsMoyenRecette
        {
            get { return tempsMoyenRecette; }
            set
            {
                int iTemps = value;

                if (iTemps <= 0)
                {
                    throw new ArgumentException("Le temps de preparation doit être supérieur a 0");
                }
                tempsMoyenRecette = iTemps;
            }
        }

        public decimal Cout
        {
            get { return cout; }
            set
            {
                decimal iCout = value;

                if (iCout <= 0)
                {
                    throw new ArgumentException("Le cout doit être supérieur a 0");
                }
                cout = iCout;
            }
        }

        public List<(TypeAliment, int)> getListAliment()
        {
            return ListeTypeAliments;
        }


        public Recette(string nomRecette, string descriptionRecette, List<(TypeAliment, int)> lstTypeAliment, int tempsMoyenRecette, decimal cout)
        {
            this.Id = ObjectId.GenerateNewId();
            NomRecette = nomRecette;
            DescriptionRecette = descriptionRecette;
            ListeTypeAliments = lstTypeAliment;
            TempsMoyenRecette = tempsMoyenRecette;
            Cout = cout;
        }

        public override string ToString()
        {
            return this.NomRecette + " | " + this.DescriptionRecette + ", (" + this.Cout + "$)";
        }
    }
}
