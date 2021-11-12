using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TP214E.Data;


namespace TP214E.Pages
{
    /// <summary>
    /// Logique d'interaction pour PageCommandes.xaml
    /// </summary>
    public partial class PageCommandes : Page
    {
        List<Commandes> lstCommandes = new List<Commandes>();
        Commandes commandeEnCours = new Commandes();
        List<Recette> lstRecettes = new List<Recette>();
        DAL DAL2;
        public PageCommandes()
        {
            InitializeComponent();
            DAL2 = new DAL();
            lstCommandes = DAL2.getCommandes();
            lstRecettes = DAL2.getRecettes();
            foreach (Recette recette in lstRecettes)
            {
                lstViewRecettes.Items.Add(recette);
            }
            lstCommandes = DAL2.getCommandes();
            foreach (Commandes commandes in lstCommandes)
            {
                lstViewHistoriqueCommandes.Items.Add(commandes);
            }

        }



        private void btnPayer_Click(object sender, RoutedEventArgs e)
        {
            //Ajout de la commande dans la base de données.
            foreach (Recette recette in commandeEnCours.listRecettes)
            {
                commandeEnCours.coutCommande += recette.getCout();
                commandeEnCours.tempsMoyen += recette.getTempsMoyen();
            }
            commandeEnCours.dateCommande = DateTime.Now;
            //À changer 
            // |
            // | 
            // v
            commandeEnCours.dateRemiseCommande = DateTime.Now;
            commandeEnCours.EmployeAttitre = null;
        }

        private void btnAjouterKit_Click(object sender, RoutedEventArgs e)
        {
            if (!commandeEnCours.kitUstensile)
            {
                commandeEnCours.kitUstensile = true;
                btnAjouterKit.Content = "Enlever kit ustensile";
            }
            else
            {
                commandeEnCours.kitUstensile = false;
                btnAjouterKit.Content = "Ajouter kit ustensile";
            }
        }

        private void BtnAjouterCondiments_Click(object sender, RoutedEventArgs e)
        {
            if (!commandeEnCours.ajoutCondiment)
            {
                commandeEnCours.ajoutCondiment = true;
                BtnAjouterCondiments.Content = "Enlever condiment";
            }
            else
            {
                commandeEnCours.ajoutCondiment = false;
                BtnAjouterCondiments.Content = "Ajouter condiment";
            }
        }

        private void btnAjouterPlatCommande_Click(object sender, RoutedEventArgs e)
        {
            lstViewCommandeEnCours.Items.Add(lstViewRecettes.SelectedItem);
            commandeEnCours.listRecettes.Add((Recette)lstViewRecettes.SelectedItem);
        }

        private void btnSupprimerPlatCommande_Click(object sender, RoutedEventArgs e)
        {
            Recette recetteRetirer = (Recette)lstViewCommandeEnCours.SelectedItem;
            lstViewCommandeEnCours.Items.Remove(recetteRetirer);
            commandeEnCours.listRecettes.Remove(recetteRetirer);
        }

        private void btnDupliquerRecette_Click(object sender, RoutedEventArgs e)
        {
            Recette recetteAjout = (Recette)lstViewCommandeEnCours.SelectedItem;
            lstViewCommandeEnCours.Items.Add(recetteAjout);
            commandeEnCours.listRecettes.Add(recetteAjout);
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {

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
            lblTitrePage.Content = "Historique de commandes";
        }

        public void EnleverPageCommande()
        {

            lblSousTotal.Visibility = Visibility.Hidden;
            lblTPS.Visibility = Visibility.Hidden;
            lblTotal.Visibility = Visibility.Hidden;
            lblTVQ.Visibility = Visibility.Hidden;
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

            lblSousTotal.Visibility = Visibility.Visible;
            lblTPS.Visibility = Visibility.Visible;
            lblTotal.Visibility = Visibility.Visible;
            lblTVQ.Visibility = Visibility.Visible;
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
            foreach (Recette recette in lstCommandes[lstViewHistoriqueCommandes.SelectedIndex].listRecettes)
            {
                lstViewRecetteDeCommande.Items.Add(recette);
            }
        }

        private void lstViewRecetteDeCommande_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void retour_Click(object sender, RoutedEventArgs e)
        {
            PageAccueil frmAccueil = new PageAccueil();

            this.NavigationService.Navigate(frmAccueil);
        }
    }
}
