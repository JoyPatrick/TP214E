using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace TP214E.Data
{
    public interface ITypeAliment
    {
        public ObjectId Id { get; }
        public string Nom { get; set; }
        public int Quantite { get; set; }
        public string Unite { get; set; }

    }
}
