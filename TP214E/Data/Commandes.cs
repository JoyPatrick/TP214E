using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP214E.Data
{
    public class Commandes
    {
        public ObjectId Id { get; set; }

        public DateTime dateCommande;

        public DateTime dateRemiseCommande;

        public Decimal coutCommande;

        public List<Recette> listRecettes = new List<Recette>();

        public int tempsMoyen;

        public Employe EmployeAttitre;

        public bool kitUstensile;
        public bool ajoutCondiment;

        public Commandes()
        {
        }

        public Commandes(DateTime dateCommande, DateTime dateRemiseCommande, decimal coutCommande,
            List<Recette> listRecettes, int tempsMoyen, Employe employeAttitre, bool kitUstensile)
        {
            this.dateCommande = dateCommande;
            this.dateRemiseCommande = dateRemiseCommande;
            this.coutCommande = coutCommande;
            this.listRecettes = listRecettes;
            this.tempsMoyen = tempsMoyen;
            EmployeAttitre = employeAttitre;
            this.kitUstensile = kitUstensile;
        }
        public override string ToString()
        {
            string valeurDeRetour = this.dateCommande + " " + this.coutCommande + 
                " " + this.EmployeAttitre + " " + this.listRecettes.ToString();
            return valeurDeRetour;
        }
    }
}
