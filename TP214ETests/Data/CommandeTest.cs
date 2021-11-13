using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class CommandeTest
    {
        [TestMethod()]
        public void Verifier_constructeur_Commande()
        {
            Commandes uneCommandes;
            List<TypeAliment> alimentsDansRecette = new List<TypeAliment>();

            alimentsDansRecette.Add(new TypeAliment("Page", "gramme", 5));

            var date1 = new DateTime(2021, 3, 1, 7, 0, 0);
            var date2 = new DateTime(2021, 3, 1, 7, 0, 0);


            uneCommandes = new Commandes(date1, date2, 10, alimentsDansRecette ,10,false);
        }

       
        

    }
}