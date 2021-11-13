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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TP214E.Data;
using TP214E.Pages;

namespace TP214E
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class PageHistoriqueCommande : Page
    {
        List<Commandes> lstCommandes = new List<Commandes>();
        private DAL dal2;
        public PageHistoriqueCommande(DAL dal)
        {
            InitializeComponent();
            dal2 = dal;
            lstCommandes = dal.getHistoriqueCommandes();
            foreach (Commandes commandes in lstCommandes)
            {
                lstViewHistoriqueCommandes.Items.Add(commandes);
            }
        }

        private void lstViewHistoriqueCommandes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstViewRecetteDeCommande.Items.Clear();
            foreach (Recette recette in lstCommandes[lstViewHistoriqueCommandes.SelectedIndex].getRecettesCommande())
            {
                lstViewRecetteDeCommande.Items.Add(recette);
            }
        }
    }
}
