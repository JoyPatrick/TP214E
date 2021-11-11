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
        public PageInventaire(DAL dal)
        {
            InitializeComponent();
            typeAliments = dal.ALiments();
            nbrKitUstensile = dal.NbrKitUstensiles();
            foreach (TypeAliment aliment in typeAliments)
            {
                lstViewInventaireAliment.Items.Add(aliment);
                cbTypeAliment.Items.Add("Nom: " + aliment.Nom);
            }

            lstViewInventaireAutre.Items.Add("Nombre kit d'ustensiles: " + nbrKitUstensile);
        }

        private void btnSupprimerAliment_Click(object sender, RoutedEventArgs e)
        {
            if (lstViewInventaireAliment.SelectedIndex != -1)
            {
                typeAliments.RemoveAt(lstViewInventaireAliment.SelectedIndex);
            }
        }

        private void btnModifierAliment_Click(object sender, RoutedEventArgs e)
        {
            lblAjoutModifierUnAliment.Content = "Modifier un aliment";
            TypeAliment alimentAModifier = (TypeAliment) lstViewInventaireAliment.SelectedItem;
            txtNomAliment.Text = alimentAModifier.Nom;
            txtUniteAliment.Text = alimentAModifier.Unite;
            btnModifierType.IsEnabled = true;
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            typeAliments.Add(new TypeAliment(txtNomAliment.Text, txtUniteAliment.Text));

        }

        private void btnModifierType_Click(object sender, RoutedEventArgs e)
        {
            TypeAliment alimentAModifier = (TypeAliment)lstViewInventaireAliment.SelectedItem;
            lstViewInventaireAliment.Items.Remove(alimentAModifier);
            typeAliments.Remove(alimentAModifier);
            TypeAliment alimentModifie = new TypeAliment(txtNomAliment.Text.Trim(), txtUniteAliment.Text.Trim());

            typeAliments.Add(alimentModifie);

            lblAjoutModifierUnAliment.Content = "Ajouter un aliment";
            btnModifierType.IsEnabled = false;

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
            
        }
    }
}
