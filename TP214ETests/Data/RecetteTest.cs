using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class RecetteTest
    {
        [TestMethod()]
        public void Verifier_constructeur_Recette()
        {
            Recette uneRecette;
            List<TypeAliment> alimentsDansRecette = new List<TypeAliment>();

            alimentsDansRecette.Add(new TypeAliment("Page", "gramme", 5));
            uneRecette = new Recette("Spagetthi", "Gros Spag", alimentsDansRecette, 4, 4);


            Assert.AreEqual("Spagetthi", uneRecette.NomRecette);
            Assert.AreEqual("Gros Spag", uneRecette.DescritpionRecette);
            Assert.AreEqual(4, uneRecette.TempsMoyenRecette);
            Assert.AreEqual(4, uneRecette.Cout);
        }

        [TestMethod()]
        public void TesterConstructeurAvecPremierParametreInvalide()
        {
            Recette uneRecette = null;

            try
            {
                List<TypeAliment> alimentsDansRecette = new List<TypeAliment>();
                alimentsDansRecette.Add(new TypeAliment("Page", "gramme", 5));

                uneRecette = new Recette("", "Gros Spag", alimentsDansRecette, 4, 4);
                Assert.Fail();

            }
            catch (ArgumentException ex)
            {
                Assert.IsNull(uneRecette);
                Assert.AreEqual("Le nom de la recette est vide", ex.Message);
            }

        }
        [TestMethod()]
        public void TesterConstructeurAvecDeuxiemeParametreInvalide()
        {
            Recette uneRecette = null;

            try
            {
                List<TypeAliment> alimentsDansRecette = new List<TypeAliment>();
                alimentsDansRecette.Add(new TypeAliment("Page", "gramme", 5));
                uneRecette = new Recette("Spagetthi", "", alimentsDansRecette, 4, 4);
                Assert.Fail();

            }
            catch (ArgumentException ex)
            {
                Assert.IsNull(uneRecette);
                Assert.AreEqual("La description de la recette est vide", ex.Message);
            }

        }
        [TestMethod()]
        public void TesterConstructeurAvecQuatriemeParametreInvalide()
        {
            Recette uneRecette = null;

            try
            {
                List<TypeAliment> alimentsDansRecette = new List<TypeAliment>();
                alimentsDansRecette.Add(new TypeAliment("Page", "gramme", 5));
                uneRecette = new Recette("Spagetthi", "Gros Spag", alimentsDansRecette, 0, 4);
                Assert.Fail();

            }
            catch (ArgumentException ex)
            {
                Assert.IsNull(uneRecette);
                Assert.AreEqual("Le temps de preparation doit être supérieur a 0", ex.Message);
            }

            try
            {
                List<TypeAliment> alimentsDansRecette = new List<TypeAliment>();
                alimentsDansRecette.Add(new TypeAliment("Page", "gramme", 5));
                uneRecette = new Recette("Spagetthi", "Gros Spag", alimentsDansRecette, -1, 4);
                Assert.Fail();

            }
            catch (ArgumentException ex)
            {
                Assert.IsNull(uneRecette);
                Assert.AreEqual("Le temps de preparation doit être supérieur a 0", ex.Message);
            }

        }

        [TestMethod()]
        public void TesterConstructeurAvecCinquiemeParametreInvalide()
        {
            Recette uneRecette = null;

            try
            {
                List<TypeAliment> alimentsDansRecette = new List<TypeAliment>();
                alimentsDansRecette.Add(new TypeAliment("Page", "gramme", 5));
                uneRecette = new Recette("Spagetthi", "Gros Spag", alimentsDansRecette, 4, 0);
                Assert.Fail();

            }
            catch (ArgumentException ex)
            {
                Assert.IsNull(uneRecette);
                Assert.AreEqual("Le cout doit être supérieur a 0", ex.Message);
            }

            try
            {
                List<TypeAliment> alimentsDansRecette = new List<TypeAliment>();
                alimentsDansRecette.Add(new TypeAliment("Page", "gramme", 5));
                uneRecette = new Recette("Spagetthi", "Gros Spag", alimentsDansRecette, 4, -1);
                Assert.Fail();

            }
            catch (ArgumentException ex)
            {
                Assert.IsNull(uneRecette);
                Assert.AreEqual("Le cout doit être supérieur a 0", ex.Message);
            }

        }


    }
}