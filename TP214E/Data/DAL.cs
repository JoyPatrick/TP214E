using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace TP214E.Data
{
    public class DAL
    {
        public MongoClient mongoDBClient;
        public DAL()
        {
            mongoDBClient = OuvrirConnexion();
        }

        public List<TypeAliment> ALiments()
        {
            var aliments = new List<TypeAliment>();
            try
            {
                IMongoDatabase db = mongoDBClient.GetDatabase("TP2DB");
                aliments = db.GetCollection<TypeAliment>("Aliments").Aggregate().ToList();
            }catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            return aliments;
        }

        public int NbrKitUstensiles()
        {
            int nbr = 0;
            //Todo aller get le nombre d'ustensiles
            return nbr;
        }
        public List<Commandes> getCommandes()
        {
            List<Commandes> lstCommandes = new List<Commandes>();
            //Todo aller get les commandes
            return lstCommandes;
        }
        public void ajoutCommande(Commandes uneCommande)
        {
            //Ajout de la commande dans la base de données
        }

        public List<Recette> getRecettes()
        {
            List<Recette> lstRecettes = new List<Recette>();
            //Todo aller get les recettes
            return lstRecettes;
        }

        private MongoClient OuvrirConnexion()
        {
            MongoClient dbClient = null;
            try{
                dbClient = new MongoClient("mongodb://localhost:27017/TP2DB");
            }catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dbClient;
        }

    }
}
