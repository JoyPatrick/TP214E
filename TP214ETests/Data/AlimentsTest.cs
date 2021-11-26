using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP214E.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class AlimentsTest
    {
        [TestMethod()]
        public void Verifier_constructeur_aliment()
        {
            TypeAliment unAliment;

            unAliment = new TypeAliment("tomates", "kl", 20);

            Assert.AreEqual("tomates", unAliment.Nom);
            Assert.AreEqual("kl", unAliment.Unite);
            Assert.AreEqual(20, unAliment.Quantite);
        }
        [TestMethod()]
        public void TesterConstructeurAvecPremierParametreInvalide()
        {
            TypeAliment unAliment = null;

            try
            {
                unAliment = new TypeAliment("", "kl", 20);
                Assert.Fail();
            }
            catch(ArgumentException ex)
            {
                Assert.IsNull(unAliment);
                Assert.AreEqual("Le nom de l'aliment est vide", ex.Message);
            }
        }
        [TestMethod()]
        public void TesterConstructeurAvecDeuxiemeParametreInvalide()
        {
            TypeAliment unAliment = null;

            try
            {
                unAliment = new TypeAliment("tomates", "", 20);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsNull(unAliment);
                Assert.AreEqual("Entre une unite valide", ex.Message);
            }

        }

        [TestMethod()]
        public void TesterConstructeurAvecTroisièmeParametreInvalide()
        {
            TypeAliment unAliment = null;

            try
            {
                unAliment = new TypeAliment("tomates", "kl", 0);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsNull(unAliment);
                Assert.AreEqual("La Quantité n'est pas supérieur a 0", ex.Message);
            }

            try
            {
                unAliment = new TypeAliment("tomates", "kl", -1);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsNull(unAliment);
                Assert.AreEqual("La Quantité n'est pas supérieur a 0", ex.Message);
            }


        }

        [TestMethod()]
        public void TesterMethodeToString()
        {
            string strNomAliment = "tomates";
            string strUnite = "kl";
            TypeAliment unAliment = new TypeAliment(strNomAliment, strUnite,20);

            Assert.AreEqual(string.Format(strNomAliment+ " Qté: " + 20 + " " + strUnite), unAliment.ToString());


        }
        public void TestAccesseurSetUniteAvecParametreValide()
        {
            TypeAliment unAliment;

            unAliment = new TypeAliment("tomates", "kl", 20);

            unAliment.Unite = "gr";
            Assert.AreEqual("tomates", unAliment.Nom);
            Assert.AreEqual("gr", unAliment.Unite);
            Assert.AreEqual(20, unAliment.Quantite);
        }




        [TestMethod()]
        public void TestAccesseurSetQuantiteAvecParametreValide()
        {
            TypeAliment unAliment;

            unAliment = new TypeAliment("tomates", "kl", 20);

            unAliment.Quantite = 50;

            Assert.AreEqual("tomates", unAliment.Nom);
            Assert.AreEqual("kl", unAliment.Unite);
            Assert.AreEqual(50, unAliment.Quantite);
        }



        [TestMethod()]
        public void TestAccesseurSetQuantiteAvecPametreInvalide()
        {
            TypeAliment unAliment;

            unAliment = new TypeAliment("tomates", "kl", 20);

            try
            {
                unAliment.Quantite = 0;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(20, unAliment.Quantite);
                Assert.AreEqual("La Quantité n'est pas supérieur a 0", ex.Message);
            }

            try
            {
                unAliment.Quantite = -1;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(20, unAliment.Quantite);
                Assert.AreEqual("La Quantité n'est pas supérieur a 0", ex.Message);
            }
        }
    }
}