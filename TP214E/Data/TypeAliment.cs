using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class TypeAliment
    {
        public ObjectId Id { get; set; }
        public string Nom { get; set; }
        public int Quantite { get; set; }
        public string Unite { get; set; }

        public TypeAliment(string nom, string unite)
        {
            Nom = nom;
            Unite = unite;
            Quantite = 0;
        }

        public override string ToString()
        {
            return "Nom:" + this.Nom +
                    "Quantité:" + this.Quantite +
                    " " + this.Unite;
        }
    }
}
