using System;
using System.Windows;
using System.Windows.Controls;
using TP214E.Data;

namespace TP214E
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class PageAccueil : Page
    {
        private DAL accesAuxDonner;
        public PageAccueil()
        {
            InitializeComponent();
            accesAuxDonner = new DAL();
        }

        private void BoutonInventaire_Click(object sender, RoutedEventArgs e)
        {
            PageInventaire frmInventaire = new PageInventaire(accesAuxDonner);

            this.NavigationService.Navigate(frmInventaire);


        }
        private void BoutonCommandes_Click(object sender, RoutedEventArgs e)
        {
            //PageCommandes frmCommande = new PageCommandes(accesAuxDonner);

            //this.NavigationService.Navigate(frmCommande);
            this.NavigationService.Navigate(new Uri("Pages/PageCommandes.xaml", UriKind.Relative));
        }
    }
}
