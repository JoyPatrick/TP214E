using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Windows;

namespace TP214E.Data
{
    public class DAL
    {
        public MongoClient mongoDBClient;
        public DAL()
        {
            mongoDBClient = OuvrirConnexion();
        }
        public void insertAliment(TypeAliment alimentsInserer)
        {
            IMongoDatabase db = mongoDBClient.GetDatabase("TP2DB");
            IMongoCollection<TypeAliment> unAliments = db.GetCollection<TypeAliment>("Aliments");
            unAliments.InsertOne(alimentsInserer);
        }

        public void insertCommande(Commandes commandesInserer)
        {
            IMongoDatabase db = mongoDBClient.GetDatabase("TP2DB");
            IMongoCollection<Commandes> uneCommande = db.GetCollection<Commandes>("Commandes");
            uneCommande.InsertOne(commandesInserer);
        }
        public void insertRecette(Recette recetteInserer)
        {
            IMongoDatabase db = mongoDBClient.GetDatabase("TP2DB");
            IMongoCollection<Recette> uneRecette = db.GetCollection<Recette>("Recettes");
            uneRecette.InsertOne(recetteInserer);
        }
        public void ModificationAliment(TypeAliment alimentsModifier)
        {
            suppressionAliment(alimentsModifier);
            insertAliment(alimentsModifier);
        }
        public void suppressionAliment(TypeAliment AlimentsSupprimer)
        {
            IMongoDatabase db = mongoDBClient.GetDatabase("TP2DB");
            IMongoCollection<TypeAliment> unAliment = db.GetCollection<TypeAliment>("Aliments");
            unAliment.FindOneAndDelete(Builders<TypeAliment>.Filter.Eq("_id", AlimentsSupprimer.Id));
        }
        public List<TypeAliment> ALiments()
        {
            var aliments = new List<TypeAliment>();
            try
            {
                IMongoDatabase db = mongoDBClient.GetDatabase("TP2DB");
                aliments = db.GetCollection<TypeAliment>("Aliments").Aggregate().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            return aliments;
        }

        public int NbrKitUstensiles()
        {
            int nbr = 0;
            return nbr;
        }
        public List<Commandes> getHistoriqueCommandes()
        {
            var commandes = new List<Commandes>();
            try
            {
                IMongoDatabase db = mongoDBClient.GetDatabase("TP2DB");
                commandes = db.GetCollection<Commandes>("Commandes").Aggregate().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            return commandes;
        }

        public List<Recette> getRecettesDansCatalogue()
        {
            var recette = new List<Recette>();
            try
            {
                IMongoDatabase db = mongoDBClient.GetDatabase("TP2DB");
                recette = db.GetCollection<Recette>("Recettes").Aggregate().ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            return recette;
        }

        private MongoClient OuvrirConnexion()
        {
            MongoClient dbClient = null;
            try
            {
                dbClient = new MongoClient("mongodb://localhost:27017/TP2DB");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dbClient;
        }

    }
}
