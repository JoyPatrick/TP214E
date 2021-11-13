using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace TP214E.Data
{
    public class Commandes
    {
        private ObjectId Id { get; set; }

        private DateTime dateCommande;

        private DateTime dateRemiseCommande;

        private Decimal coutCommande;

        private List<Recette> listRecettes = new List<Recette>();

        private int tempsMoyen;


        private bool besoinKitUsentile;
        private bool ajoutCondiment;

        #region Getters

        public ObjectId obtenirID()
        {
            return Id;
        }

        public DateTime getDateCommande()
        {
            return dateCommande;
        }
        public DateTime getDateRemiseCommande()
        {
            return dateRemiseCommande;
        }
        public Decimal getCoutCommande()
        {
            return coutCommande;
        }
        public List<Recette> getRecettesCommande()
        {
            return listRecettes;
        }
        public int getTempsMoyen()
        {
            return tempsMoyen;
        }
        public bool getBesoinKitUstensile()
        {
            return besoinKitUsentile;
        }
        public bool getAjoutCondiment()
        {
            return ajoutCondiment;
        }
        #endregion

        #region Setters

        public void setDateCommande(DateTime datetimeCommande)
        {
            dateCommande = datetimeCommande;
        }
        public void setDateCommandeRemise(DateTime datetimeCommande)
        {
            dateRemiseCommande = datetimeCommande;
        }
        public void setCout(decimal cout)
        {
            coutCommande += cout;
        }
        public void setRecettes(List<Recette> recettes)
        {
            listRecettes = recettes;
        }
        public void setTempsMoyen(int temps)
        {
            tempsMoyen += temps;
        }
        public void setBesoinUstensile(bool besoinUstensile)
        {
            besoinKitUsentile = besoinUstensile;
        }
        public void setAjoutCondiment(bool condiment)
        {
            ajoutCondiment = condiment;
        }


        #endregion

        public Commandes()
        {
        }

        public Commandes(DateTime dateCommande, DateTime dateRemiseCommande, decimal coutCommande,
            List<Recette> listRecettes, int tempsMoyen, bool kitUstensile)
        {
            this.Id = ObjectId.GenerateNewId();
            this.dateCommande = dateCommande;
            this.dateRemiseCommande = dateRemiseCommande;
            this.coutCommande = coutCommande;
            this.listRecettes = listRecettes;
            this.tempsMoyen = tempsMoyen;
            this.besoinKitUsentile = kitUstensile;
        }
        public override string ToString()
        {
            string valeurDeRetour = this.dateCommande + " " + this.coutCommande
                 + " " + this.listRecettes.ToString();
            return valeurDeRetour;
        }
    }
}
