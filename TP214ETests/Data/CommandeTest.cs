using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace TP214E.Data.Tests
{
    [TestClass()]
    public class CommandeTest
    {
        [TestMethod()]

        public void Verifier_si_liste_recette_vide_dans_generer_cout()
        {
            List<Recette> listRecette = new List<Recette>();
            Commandes uneCommande = new Commandes();
            if (uneCommande.GenererCoutTotal(listRecette))
            {
                Assert.Fail();
            }
        }
        [TestMethod()]
        public void Verifier_si_liste_recette_vide_dans_generer_temps()
        {
            List<Recette> listRecette = new List<Recette>();
            Commandes uneCommande = new Commandes();
            if (uneCommande.GenererTempsMoyen(listRecette))
            {
                Assert.Fail();
            }
        }

    }
}