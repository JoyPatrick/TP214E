using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class RecetteTest
    {
        private List<(TypeAliment, int)> alimentsDansRecette;

        public void Inialisation()
        {
            alimentsDansRecette = new List<(TypeAliment, int)>();
            alimentsDansRecette.Add((new TypeAliment("Pates", "gramme", 10000), 150));
            alimentsDansRecette.Add((new TypeAliment("Sauce Tomates", "gramme", 10000), 50));
            alimentsDansRecette.Add((new TypeAliment("Boeuf hachés", "gramme", 20000), 100));
        }
        [TestMethod()]
        public void Verifier_constructeur_Recette()
        {
            Inialisation();
            Recette uneRecette;

            uneRecette = new Recette("Spagetthi", "Gros Spag", alimentsDansRecette, 4, 4);


            Assert.AreEqual("Spagetthi", uneRecette.NomRecette);
            Assert.AreEqual("Gros Spag", uneRecette.DescriptionRecette);
            Assert.AreEqual(4, uneRecette.TempsMoyenRecette);
            Assert.AreEqual(4, uneRecette.Cout);
        }

        [TestMethod()]
        public void TesterConstructeurAvecPremierParametreInvalide()
        {
            Inialisation();
            Recette uneRecette = null;

            try
            {
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
            Inialisation();
            Recette uneRecette = null;

            try
            {
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
            Inialisation();
            Recette uneRecette = null;

            try
            {
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
            Inialisation();
            Recette uneRecette = null;

            try
            {
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
                uneRecette = new Recette("Spagetthi", "Gros Spag", alimentsDansRecette, 4, -1);
                Assert.Fail();

            }
            catch (ArgumentException ex)
            {
                Assert.IsNull(uneRecette);
                Assert.AreEqual("Le cout doit être supérieur a 0", ex.Message);
            }

        }
        [TestMethod()]
        public void TestAccesseurSetNomAvecParametreValide()
        {
            Inialisation();
            Recette uneRecette;
            uneRecette = new Recette("Spagetthi", "Gros Spag", alimentsDansRecette, 4, 4);



            uneRecette.NomRecette = "Laitue";



            Assert.AreEqual("Laitue", uneRecette.NomRecette);
            Assert.AreEqual("Gros Spag", uneRecette.DescriptionRecette);
            Assert.AreEqual(4, uneRecette.TempsMoyenRecette);
            Assert.AreEqual(4, uneRecette.Cout);



        }
        [TestMethod()]
        public void TestAccesseurTempsRecetteAvecParametreInvalide()
        {
            Inialisation();
            Recette uneRecette;
            uneRecette = new Recette("Spagetthi", "Gros Spag", alimentsDansRecette, 4, 4);




            try
            {
                uneRecette.TempsMoyenRecette = 0;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(4, uneRecette.TempsMoyenRecette);
                Assert.AreEqual("Le temps de preparation doit être supérieur a 0", ex.Message);
            }



            try
            {
                uneRecette.TempsMoyenRecette = -1;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(4, uneRecette.TempsMoyenRecette);
                Assert.AreEqual("Le temps de preparation doit être supérieur a 0", ex.Message);
            }
        }


    }
}