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



        //public void ModificationCommande(Commandes CommandesModifier)
        //{
        //    IMongoDatabase db = mongoDBClient.GetDatabase("TP2DB");
        //    IMongoCollection<Commandes> uneCommande = db.GetCollection<Commandes>("Commandes");
        //    //uneCommande.UpdateOne(Builders<Commandes>.Filter.Eq("_id",CommandesModifier.obtenirID));

        //}


        public void ModificationAliment(TypeAliment alimentsModifier)
        {
            IMongoDatabase db = mongoDBClient.GetDatabase("TP2DB");
            IMongoCollection<TypeAliment> unAliments = db.GetCollection<TypeAliment>("Aliments");


            FilterDefinition<TypeAliment> filtre = Builders<TypeAliment>.Filter.Eq("_id", alimentsModifier.Id);
            UpdateDefinition<TypeAliment> modifications = Builders<TypeAliment>.Update.Set("Nom", alimentsModifier.Nom)
            .Set("Quantite", alimentsModifier.Quantite)
            .Set("Unite", alimentsModifier.Unite);
            unAliments.UpdateOne(filtre, modifications);



            //unAliments.UpdateOne(Builders<TypeAliment>.Filter.Eq("_id", alimentsModifier.Id));
        }







        //public void suppressionCommande(Commandes CommandesSupprimer)
        //{
        //    IMongoDatabase db = mongoDBClient.GetDatabase("TP2DB");
        //    IMongoCollection<Commandes> uneCommande = db.GetCollection<Commandes>("Commandes");


        //}


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
            //Todo aller get le nombre d'ustensiles
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
        public void ajoutCommande(Commandes uneCommande)
        {
            //Ajout de la commande dans la base de données


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
