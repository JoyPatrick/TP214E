using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Recette
    {

        private ObjectId Id { get; set; }

        private string nomRecette { get; set; }

        private string descritpionRecette { get; set; }

        private List<TypeAliment> lstTypeAliment { get; set; }

        private int tempsMoyenRecette;

        public int getTempsMoyen()
        {
            return tempsMoyenRecette;
        }

        private decimal cout;

        public decimal getCout()
        {
            return cout;
        }

        public Recette(string nomRecette, string descritpionRecette, List<TypeAliment> lstTypeAliment, int tempsMoyenRecette, decimal cout)
        {
            this.nomRecette = nomRecette;
            this.descritpionRecette = descritpionRecette;
            this.lstTypeAliment = lstTypeAliment;
            this.tempsMoyenRecette = tempsMoyenRecette;
            this.cout = cout;
        }

        public override string ToString()
        {
            return this.nomRecette + " | " + this.descritpionRecette + ", (" + this.cout + "$)";
        }
    }

}
