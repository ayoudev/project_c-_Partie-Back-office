using Projet3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projet3
{
    /// <summary>
    /// Logique d'interaction pour GestionCAT.xaml
    /// </summary>
    public partial class GestionCAT : Window
    {
        public List<Categorie> data { get; set; }
        public GestionCAT()
        {
            InitializeComponent();
            DataContext = this;
            read();
        }

        private void btn_ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (txt_nom.Text != "")
            {
                Ajouter();
            }
            else
            {
                MessageBox.Show("Remplir tous les informations.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void Ajouter()
        {
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                var nom = txt_nom.Text;
                Boolean res = RechercherAdherent();
                if (res == false)
                {
                    context.Categorie.Add(new Categorie()
                    {
                        Nom = nom
                    });
                    context.SaveChanges();
                    data.Clear();
                    read();
                    txt_nom.Text = "";
                    MessageBox.Show("L'enregistrement avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("cette Categorie existe déja");
                }
            }
        }
        public Boolean RechercherAdherent()
        {
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                Boolean b = false;
                var Nom = txt_nom.Text;
                var ca = context.Categorie.FirstOrDefault(a => a.Nom == Nom);
                if (ca != null)
                {
                    b = true;
                }
                else
                {
                    b = false;
                }
                return b;
            }
        }
        public void read()
        {
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                data = context.Categorie.ToList();
                Data_Grid.ItemsSource = data;
            }
        }

        private void btn_supprimer_Click(object sender, RoutedEventArgs e)
        {
            if (txt_nom.Text != "")
            {
                delete();
            }
            else
            {
                MessageBox.Show("Remplir tous les informations.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void delete()
        {
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                Categorie selectedCA = Data_Grid.SelectedItem as Categorie;
                var Nom = txt_nom.Text;
                if (Nom != "")
                {
                    Categorie ca = context.Categorie.Single(x => x.CategorieID == selectedCA.CategorieID);
                    context.Remove(ca);
                    context.SaveChanges();

                    data.Clear();
                    read();
                    MessageBox.Show("La suppression avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    data.Clear();
                    read();
                    MessageBox.Show("Cette categorie n'existe pas.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public void update()
        {
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                Categorie selectedCA = Data_Grid.SelectedItem as Categorie;
                var nom = txt_nom.Text;
                if (nom != "")
                {
                    Categorie ca = context.Categorie.Single(x => x.CategorieID == selectedCA.CategorieID);
                    ca.Nom = nom;
                    context.SaveChanges();
                    data.Clear();
                    read();
                    MessageBox.Show("La modification avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        private void btn_chercher_Click(object sender, RoutedEventArgs e)
        {
            var res = RechercherAdherent();
            if (res == true)
            {
                MessageBox.Show("Categorie existe");
            }
            else
            {
                data.Clear();
                read();
                MessageBox.Show("Categorie n'existe pas.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_Modifier_Click(object sender, RoutedEventArgs e)
        {
            if (txt_nom.Text != "" )
            {
                update();
            }
            else
            {
                MessageBox.Show("Remplir tous les informations.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
