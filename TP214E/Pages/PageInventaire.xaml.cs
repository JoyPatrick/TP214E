using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TP214E.Data;

namespace TP214E
{ 
    public partial class PageInventaire : Page
    { 
        private List<TypeAliment> typeAliments;
        private int nbrKitUstensile;
        private TypeAliment alimentAModifier;
        private DAL dal2;
        public PageInventaire(DAL dal)
        {
            dal2 = dal;
            InitializeComponent();
            typeAliments = dal2.ALiments();
            nbrKitUstensile = dal2.NbrKitUstensiles();
            Refresh();
        }
        public void Refresh()
        {
            lstViewInventaireAliment.Items.Clear();
            lstViewInventaireAutre.Items.Clear();
            foreach (TypeAliment aliment in typeAliments)
            {
                lstViewInventaireAliment.Items.Add(aliment);
            }

            lstViewInventaireAutre.Items.Add("Nombre kit d'ustensiles: " + nbrKitUstensile);
        }

        private void btnSupprimerAliment_Click(object sender, RoutedEventArgs e)
        {
            if (lstViewInventaireAliment.SelectedIndex != -1)
            {
                dal2.suppressionAliment(typeAliments[lstViewInventaireAliment.SelectedIndex]);
                typeAliments.RemoveAt(lstViewInventaireAliment.SelectedIndex);
            }

            Refresh();

        }

        private void btnModifierAliment_Click(object sender, RoutedEventArgs e)
        {
            alimentAModifier = (TypeAliment)lstViewInventaireAliment.SelectedItem;
            txtNomAliment.Text = alimentAModifier.Nom;
            txtUniteAliment.Text = alimentAModifier.Unite;
            txtQuantite.Text = alimentAModifier.Quantite.ToString();
            btnModifierType.IsEnabled = true;
            Refresh();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            TypeAliment unNouvAliment = new TypeAliment(txtNomAliment.Text, txtUniteAliment.Text, Convert.ToInt32(txtQuantite.Text));
            dal2.insertAliment(unNouvAliment);
            typeAliments.Add(unNouvAliment);
            Refresh();
        }

        private void btnModifierType_Click(object sender, RoutedEventArgs e)
        {
            lstViewInventaireAliment.Items.Remove(alimentAModifier);
            typeAliments.Remove(alimentAModifier);

            TypeAliment alimentModifie = new TypeAliment(txtNomAliment.Text.Trim(), txtUniteAliment.Text.Trim(), Convert.ToInt32(txtQuantite.Text));
            typeAliments.Add(alimentModifie);

            btnModifierType.IsEnabled = false;

            dal2.ModificationAliment(alimentModifie);

            Refresh();
        }

        private void btnAjouterUsentile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                nbrKitUstensile += Convert.ToInt32(txtNombreUstensile.Text);
            }
            catch (Exception)
            {
                nbrKitUstensile += 0;
                throw;
            }
            Refresh();
        }

        private void retour_Click(object sender, RoutedEventArgs e)
        {
            PageAccueil frmAccueil = new PageAccueil();

            this.NavigationService.Navigate(frmAccueil);
        }
    }
}
