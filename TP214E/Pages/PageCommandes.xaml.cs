using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TP214E.Data;


namespace TP214E.Pages
{
    /// <summary>
    /// Logique d'interaction pour PageCommandes.xaml
    /// </summary>
    public partial class PageCommandes : Page
    {
        List<Commandes> historiqueCommandes = new List<Commandes>();

        Commandes commandeEnCours = new Commandes();

        List<Recette> recettesDansCatalogue = new List<Recette>();

        List<TypeAliment> alimentsDansInventaire = new List<TypeAliment>();

        DAL DAL2;

        public PageCommandes()
        {
            InitializeComponent();
            DAL2 = new DAL();
            List<TypeAliment> alimentsDansRecette = new List<TypeAliment>();
            alimentsDansRecette = GenererAlimentDansRecette(alimentsDansRecette);

            historiqueCommandes = DAL2.getHistoriqueCommandes();
            recettesDansCatalogue = DAL2.getRecettesDansCatalogue();

            GenererRecetteDansCatalogue(alimentsDansRecette);

            RafraichirLesListView();

        }

        private void GenererRecetteDansCatalogue(List<TypeAliment> alimentsDansRecette)
        {
            recettesDansCatalogue.Add(new Recette("Spagetthi", "Gros Spag", alimentsDansRecette, 4, 4));
            recettesDansCatalogue.Add(new Recette("Lasagne", "Grosse lasagne", alimentsDansRecette, 19, 20));
        }

        private List<TypeAliment> GenererAlimentDansRecette(List<TypeAliment> alimentsDansRecette)
        {
            alimentsDansRecette.Add(new TypeAliment("Page", "gramme", 5));
            alimentsDansRecette.Add(new TypeAliment("Tomate", "gramme", 4));
            alimentsDansRecette.Add(new TypeAliment("Viande", "gramme", 38));
            return alimentsDansRecette;
        }

        public void RafraichirLesListView()
        {
            lstViewRecettesCatalogue.Items.Clear();
            foreach (Recette recette in recettesDansCatalogue)
            {
                lstViewRecettesCatalogue.Items.Add(recette);
            }
            historiqueCommandes = DAL2.getHistoriqueCommandes();
            lstViewHistoriqueCommandes.Items.Clear();
            foreach (Commandes commandes in historiqueCommandes)
            {
                lstViewHistoriqueCommandes.Items.Add(commandes);
            }
            alimentsDansInventaire = DAL2.ALiments();
        }


        private void btnPayer_Click(object sender, RoutedEventArgs e)
        {
            commandeEnCours.setDateCommande(DateTime.Now);
            RetirerAlimentDeInventaire(commandeEnCours);
            if (commandeEnCours.GenererTempsMoyen(commandeEnCours.getRecettesCommande()) &&
                commandeEnCours.GenererCoutTotal(commandeEnCours.getRecettesCommande()))
            {
                DAL2.insertCommande(commandeEnCours);
            }
            ReinitialiserCommande();

        }

        private void ReinitialiserCommande()
        {
            lstViewCommandeEnCours.Items.Clear();
            commandeEnCours = new Commandes();
            btnAjouterKit.Content = "Ajouter kit ustensile";
            BtnAjouterCondiments.Content = "Ajouter condiment";
            RafraichirLesListView();
        }

        public void RetirerAlimentDeInventaire(Commandes commande)
        {
            foreach (Recette recetteDeLaCommande in commande.getRecettesCommande())
            {
                foreach (TypeAliment aliment in recetteDeLaCommande.getListAliment())
                {
                    for (int i = 0; i < alimentsDansInventaire.Count; i++)
                    {
                        if (alimentsDansInventaire[i] == aliment)
                        {
                            alimentsDansInventaire[i].Quantite -= aliment.Quantite;
                        }
                    }
                }
            }
        }

        private void btnAjouterKit_Click(object sender, RoutedEventArgs e)
        {
            if (!commandeEnCours.getBesoinKitUstensile())
            {
                commandeEnCours.setBesoinUstensile(true);
                btnAjouterKit.Content = "Enlever kit ustensile";
            }
            else
            {
                commandeEnCours.setBesoinUstensile(false);
                btnAjouterKit.Content = "Ajouter kit ustensile";
            }
        }

        private void BtnAjouterCondiments_Click(object sender, RoutedEventArgs e)
        {
            if (!commandeEnCours.getAjoutCondiment())
            {
                commandeEnCours.setAjoutCondiment(true);
                BtnAjouterCondiments.Content = "Enlever condiment";
            }
            else
            {
                commandeEnCours.setAjoutCondiment(false);
                BtnAjouterCondiments.Content = "Ajouter condiment";
            }
        }

        private void btnAjouterPlatCommande_Click(object sender, RoutedEventArgs e)
        {
            if (lstViewRecettesCatalogue.SelectedIndex != -1)
            {
                lstViewCommandeEnCours.Items.Add(lstViewRecettesCatalogue.SelectedItem);
                commandeEnCours.setRecettes((Recette)lstViewRecettesCatalogue.SelectedItem);
            }
        }

        private void btnSupprimerPlatCommande_Click(object sender, RoutedEventArgs e)
        {
            if (lstViewCommandeEnCours.SelectedIndex != -1)
            {
                Recette recetteRetirer = (Recette)lstViewCommandeEnCours.SelectedItem;
                lstViewCommandeEnCours.Items.Remove(recetteRetirer);
                commandeEnCours.getRecettesCommande().Remove(recetteRetirer);
            }
        }

        private void btnDupliquerRecette_Click(object sender, RoutedEventArgs e)
        {
            if (lstViewCommandeEnCours.SelectedIndex != -1)
            {
                Recette recetteAjout = (Recette)lstViewCommandeEnCours.SelectedItem;
                lstViewCommandeEnCours.Items.Add(recetteAjout);
                commandeEnCours.getRecettesCommande().Add(recetteAjout);
            }
        }


        private void btnHistoriqueCommandes_Click(object sender, RoutedEventArgs e)
        {
            EnleverPageCommande();
            AfficherPageHistorique();
        }

        private void AfficherPageHistorique()
        {
            lstViewHistoriqueCommandes.Visibility = Visibility.Visible;
            lstViewRecetteDeCommande.Visibility = Visibility.Visible;
            lblTitrePage.Content = "Historique";
        }

        public void EnleverPageCommande()
        {
            lstViewRecettesCatalogue.Visibility = Visibility.Hidden;
            btnPayer.Visibility = Visibility.Hidden;
            lstViewCommandeEnCours.Visibility = Visibility.Hidden;
            btnAjouterKit.Visibility = Visibility.Hidden;
            BtnAjouterCondiments.Visibility = Visibility.Hidden;
            btnAjouterPlatCommande.Visibility = Visibility.Hidden;
            btnDupliquerPlatCommande.Visibility = Visibility.Hidden;
            btnSupprimerPlatCommande.Visibility = Visibility.Hidden;
            lblCommandeEnCours.Visibility = Visibility.Hidden;
            lblListePlats.Visibility = Visibility.Hidden;
            btnHistoriqueCommandes.Visibility = Visibility.Hidden;
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
            EnleverPageHistorique();
            AfficherPageCommande();
        }

        private void AfficherPageCommande()
        {

            btnAjouterKit.Visibility = Visibility.Visible;
            BtnAjouterCondiments.Visibility = Visibility.Visible;
            btnAjouterPlatCommande.Visibility = Visibility.Visible;
            btnDupliquerPlatCommande.Visibility = Visibility.Visible;
            btnSupprimerPlatCommande.Visibility = Visibility.Visible;
            lblCommandeEnCours.Visibility = Visibility.Visible;
            lblListePlats.Visibility = Visibility.Visible;
            btnHistoriqueCommandes.Visibility = Visibility.Visible;
        }

        private void EnleverPageHistorique()
        {

            lstViewHistoriqueCommandes.Visibility = Visibility.Hidden;
            lstViewRecetteDeCommande.Visibility = Visibility.Hidden;
            lblTitrePage.Content = "Chez Victor";
        }

        private void lstViewHistoriqueCommandes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstViewRecetteDeCommande.Items.Clear();
            foreach (Recette recette in historiqueCommandes[lstViewHistoriqueCommandes.SelectedIndex].getRecettesCommande())
            {
                lstViewRecetteDeCommande.Items.Add(recette);
            }
        }


        private void retour_Click(object sender, RoutedEventArgs e)
        {
            PageAccueil frmAccueil = new PageAccueil();

            this.NavigationService.Navigate(frmAccueil);
        }
    }
}
