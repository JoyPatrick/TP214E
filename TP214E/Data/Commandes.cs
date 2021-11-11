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

        public Decimal cout;

        public List<Recette> listRecettes = new List<Recette>();

        public int tempsMoyen;

        public Employe EmployeAttitre;

        public bool kitUstensile;
        public bool ajoutCondiment;

        public Commandes()
        {
        }

        public Commandes(DateTime dateCommande, DateTime dateRemiseCommande, decimal cout,
            List<Recette> listRecettes, int tempsMoyen, Employe employeAttitre, bool kitUstensile)
        {
            this.dateCommande = dateCommande;
            this.dateRemiseCommande = dateRemiseCommande;
            this.cout = cout;
            this.listRecettes = listRecettes;
            this.tempsMoyen = tempsMoyen;
            EmployeAttitre = employeAttitre;
            this.kitUstensile = kitUstensile;
        }
        public override string ToString()
        {
            string valeurDeRetour = this.dateCommande + " " + this.cout + 
                " " + this.EmployeAttitre + " " + this.listRecettes.ToString();
            return valeurDeRetour;
        }
    }
}
