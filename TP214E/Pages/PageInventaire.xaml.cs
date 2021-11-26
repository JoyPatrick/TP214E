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
        private List<(TypeAliment, int)> listeAlimentQuantiteAjoutDeRecette;
        public PageInventaire(DAL dal)
        {
            dal2 = dal;
            listeAlimentQuantiteAjoutDeRecette = new List<(TypeAliment, int)>();
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
            if (txtNomAliment.Text != "" && txtUniteAliment.Text != "" && txtQuantite.Text != "")
            {
                TypeAliment unNouvAliment = new TypeAliment(txtNomAliment.Text, txtUniteAliment.Text, Convert.ToInt32(txtQuantite.Text));
                dal2.insertAliment(unNouvAliment);
                typeAliments.Add(unNouvAliment);
                Refresh();
            }
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
        public void EnleverPageInventaire()
        {
            lstViewInventaireAliment.Visibility = Visibility.Hidden;
            lstViewInventaireAutre.Visibility = Visibility.Hidden;
            lblTitrePage.Visibility = Visibility.Hidden;
            lblAutre.Visibility = Visibility.Hidden;
            lblAliment.Visibility = Visibility.Hidden;
            btnAjouter.Visibility = Visibility.Hidden;
            btnModifierAliment.Visibility = Visibility.Hidden;
            btnModifierType.Visibility = Visibility.Hidden;
            btnSupprimerAliment.Visibility = Visibility.Hidden;
            lblNomAliment.Visibility = Visibility.Hidden;
            lblQte.Visibility = Visibility.Hidden;
            lblUnite.Visibility = Visibility.Hidden;
            txtNomAliment.Visibility = Visibility.Hidden;
            txtNombreUstensile.Visibility = Visibility.Hidden;
            txtQuantite.Visibility = Visibility.Hidden;
            txtUniteAliment.Visibility = Visibility.Hidden;
            btnAjouterUsentile.Visibility = Visibility.Hidden;
            btnAfficherCreationRecette.Visibility = Visibility.Hidden;
        }

        public void AfficherPageInventaire()
        {
            lstViewInventaireAliment.Visibility = Visibility.Visible;
            lstViewInventaireAutre.Visibility = Visibility.Visible;
            lblTitrePage.Visibility = Visibility.Visible;
            lblAutre.Visibility = Visibility.Visible;
            lblAliment.Visibility = Visibility.Visible;
            btnAjouter.Visibility = Visibility.Visible;
            btnModifierAliment.Visibility = Visibility.Visible;
            btnModifierType.Visibility = Visibility.Visible;
            btnSupprimerAliment.Visibility = Visibility.Visible;
            lblNomAliment.Visibility = Visibility.Visible;
            lblQte.Visibility = Visibility.Visible;
            lblUnite.Visibility = Visibility.Visible;
            txtNomAliment.Visibility = Visibility.Visible;
            txtNombreUstensile.Visibility = Visibility.Visible;
            txtQuantite.Visibility = Visibility.Visible;
            txtUniteAliment.Visibility = Visibility.Visible;
            btnAjouterUsentile.Visibility = Visibility.Visible;
            btnAfficherCreationRecette.Visibility = Visibility.Visible;
            
        }

        public void EnleverPageCreationRecette()
        {

        }

        public void AfficherPageCreationRecette()
        {
            txtTempsMoyen.Visibility = Visibility.Visible;
            txtDescription.Visibility = Visibility.Visible;
            txtNomRecette.Visibility = Visibility.Visible;
            txtCout.Visibility = Visibility.Visible;
            btnAjouterRecette.Visibility = Visibility.Visible;
            

            foreach (TypeAliment aliment in typeAliments)
            {
                lstViewAlimentAjoutRecette.Items.Add((aliment, 1));
            }
        }

        private void btnAfficherCreationRecette_Click(object sender, RoutedEventArgs e)
        {
            EnleverPageInventaire();
            AfficherPageCreationRecette();
        }


        private void btnAjouterAlimentDansRecette_Click(object sender, RoutedEventArgs e)
        {
            
            if (lstViewAlimentAjoutRecette.SelectedIndex != -1)
            {

                (TypeAliment, int) alimentSelectionne = ((TypeAliment, int))lstViewAlimentAjoutRecette.SelectedItem;
                bool estDejaDansListe = false;
                for (int i = 0; i < listeAlimentQuantiteAjoutDeRecette.Count; i++)
                {
                    if (listeAlimentQuantiteAjoutDeRecette[i].Item1 == alimentSelectionne.Item1)
                    {
                        estDejaDansListe = true;
                        lstViewAlimentDansRecette.Items.Add((alimentSelectionne.Item1, listeAlimentQuantiteAjoutDeRecette[i].Item2 + 1));
                        lstViewAlimentDansRecette.Items.RemoveAt(i);
                        listeAlimentQuantiteAjoutDeRecette.Add((alimentSelectionne.Item1, listeAlimentQuantiteAjoutDeRecette[i].Item2 + 1));
                        listeAlimentQuantiteAjoutDeRecette.RemoveAt(i);
                    }
                }
                if (!estDejaDansListe)
                {
                    lstViewAlimentDansRecette.Items.Add((alimentSelectionne.Item1, 1));
                    listeAlimentQuantiteAjoutDeRecette.Add((alimentSelectionne.Item1, 1));
                }
            }
        }

        private void btnCreationRecetteDansBD_Click(object sender, RoutedEventArgs e)
        {
            //Faire validation int/string
            List<(TypeAliment, int)> alimentDansLaRecette = new List<(TypeAliment, int)>();
            for (int i = 0; i < lstViewAlimentDansRecette.Items.Count; i++)
            {
                (TypeAliment, int) alimentDansListeView = ((TypeAliment, int))lstViewAlimentDansRecette.Items[i];
                alimentDansLaRecette.Add(alimentDansListeView);
            }
            Recette recette_nouvelle = new Recette(txtNomRecette.Text, txtDescription.Text,
                alimentDansLaRecette, Convert.ToInt32(txtTempsMoyen.Text), Convert.ToDecimal(txtCout.Text));

            dal2.insertRecette(recette_nouvelle);

        }
    }
}
