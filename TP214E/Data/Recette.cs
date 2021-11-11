using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Recette
    {

        private ObjectId Id { get; set; }

        private string nom { get; set; }

        private string description { get; set; }

        private List<TypeAliment> lstTypeAliment { get; set; }

        private int tempsMoyen;

        public int getTempsMoyen()
        {
            return tempsMoyen;
        }

        private decimal cout;

        public decimal getCout()
        {
            return cout;
        }

        public Recette(string nom, string description, List<TypeAliment> lstTypeAliment, int tempsMoyen, decimal cout)
        {
            this.nom = nom;
            this.description = description;
            this.lstTypeAliment = lstTypeAliment;
            this.tempsMoyen = tempsMoyen;
            this.cout = cout;
        }

        public override string ToString()
        {
            return this.nom + " | " + this.description + ", (" + this.cout + "$)";
        }
    }

}
