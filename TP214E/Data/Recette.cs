using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Recette
    {

        private ObjectId Id { get; set; }

        private string nomRecette;

        private string descritpionRecette;

        private List<TypeAliment> lstTypeAliment { get; set; }

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
        public string DescritpionRecette
        {
            get { return descritpionRecette; }
            set
            {
                string strDescritpionRecette = value;

                if (strDescritpionRecette == "")
                {
                    throw new ArgumentException("La description de la recette est vide");
                }
                descritpionRecette = strDescritpionRecette;
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

        public List<TypeAliment> getListAliment()
        {
            return lstTypeAliment;
        }


        public int getTempsMoyen()
        {
            return tempsMoyenRecette;
        }


        public decimal getCout()
        {
            return cout;
        }

        public Recette( string nomRecette, string descritpionRecette, List<TypeAliment> lstTypeAliment, int tempsMoyenRecette, decimal cout)
        {
            this.Id = ObjectId.GenerateNewId();
            NomRecette = nomRecette;
            DescritpionRecette = descritpionRecette;
            this.lstTypeAliment = lstTypeAliment;
            TempsMoyenRecette = tempsMoyenRecette;
            Cout = cout;
        }

        public override string ToString()
        {
            return this.nomRecette + " | " + this.descritpionRecette + ", (" + this.cout + "$)";
        }
    }

}
