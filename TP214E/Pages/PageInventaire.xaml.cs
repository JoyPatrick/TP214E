using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TP214E.Data;

namespace TP214E
{
    /// <summary>
    /// Logique d'interaction pour Inventaire.xaml
    /// </summary>
    public partial class PageInventaire : Page
    {
        // Faire d'envoyer les données dans la BD aux points clés
        private List<TypeAliment> typeAliments;
        private int nbrKitUstensile;
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
            lblAjoutModifierUnAliment.Content = "Modifier un aliment";
            TypeAliment alimentAModifier = (TypeAliment)lstViewInventaireAliment.SelectedItem;
            txtNomAliment.Text = alimentAModifier.Nom;
            txtUniteAliment.Text = alimentAModifier.Unite;
            txtQuantite.Text = alimentAModifier.Quantite.ToString();
            btnModifierType.IsEnabled = true;
            Refresh();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
                TypeAliment unNouvAliment = new TypeAliment(txtNomAliment.Text, txtUniteAliment.Text, Convert.ToInt32(txtQuantite.Text));
                dal2.insertAliment(unNouvAliment);
                typeAliments.Add(unNouvAliment);
                Refresh();
            //}
            //catch (System.Exception uneException)
            //{

            //    MessageBox.Show(uneException.Message, "Erreur");
            //    switch (uneException.Message)
            //    {
            //        case "Le nom de l'aliment est vide":
            //            txtNomAliment.Focus();
            //            break;
            //        case "L'unite de l'aliment est vide":
            //            txtUniteAliment.Focus();
            //            break;
            //        case "La quantite n'est pas supérieur a zéros":
            //            txtQuantite.Focus();
            //            break;
            //        case "Le format entrée est incorrecte":
            //            txtQuantite.Focus();
            //            break;
            //        default:
            //            break;
            //    }

            //}


        }

        private void btnModifierType_Click(object sender, RoutedEventArgs e)
        {
            TypeAliment alimentAModifier = (TypeAliment)lstViewInventaireAliment.SelectedItem;
            lstViewInventaireAliment.Items.Remove(alimentAModifier);

            typeAliments.Remove(alimentAModifier);
            TypeAliment alimentModifie = new TypeAliment(txtNomAliment.Text.Trim(), txtUniteAliment.Text.Trim(), Convert.ToInt32(txtQuantite.Text));

            typeAliments.Add(alimentModifie);

            lblAjoutModifierUnAliment.Content = "Ajouter un aliment";
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
