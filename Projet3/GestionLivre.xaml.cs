using Microsoft.Win32;
using Projet3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;



namespace Projet3
{
    /// <summary>
    /// Logique d'interaction pour GestionLivre.xaml
    /// </summary>
    public partial class GestionLivre : Window
    {
        public string imagePath;
        public List<Livres> data { get; set; }
        public List<String> CategoryNames { get; set; }
        public GestionLivre()
        {
            InitializeComponent();
            DataContext = this;
            read();
            GetCategoryNames();
        }
        public void read()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
             {
                 data = db.Livres.ToList();
                 datagrid_livre.ItemsSource = data;
            }
        }

        public void GetCategoryNames()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                CategoryNames = db.Categorie.Select(c => c.Nom).ToList();
            }
        }

        private void btn_Apload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images files|*.bmp;*.jpg;*.png";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == true)
            {
                pictureBox.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                imagePath = openFileDialog.FileName; // Utilisez imagePath au lieu de image
            }
        }
        private BitmapImage LoadImage(string filePath)
         {
             BitmapImage bitmap = new BitmapImage();
             bitmap.BeginInit();
             bitmap.UriSource = new Uri(filePath);
             bitmap.EndInit();
             return bitmap;
         }

         private byte[] ConvertImageToByteArray(BitmapImage bitmapImage)
         {
             JpegBitmapEncoder encoder = new JpegBitmapEncoder();
             encoder.Frames.Add(BitmapFrame.Create(bitmapImage));

             using (MemoryStream stream = new MemoryStream())
             {
                 encoder.Save(stream);
                 return stream.ToArray();
             }
         }

       


        public void Ajouter()
        {
            try
            {
                using (ApplicationDBContext context = new ApplicationDBContext())
                {
                    var titre = txt_titre.Text;
                    var auteur = txt_auteur.Text;
                    var prix = float.Parse(txt_prix.Text);
                    var quantite = int.Parse(txt_quantité.Text);
                    var disponible = "";
                    if (prix < 0)
                    {
                        MessageBox.Show("Le prix invalid.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    if (quantite < 0)
                    {
                        MessageBox.Show("Le quantite invalid.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    if (rd_non.IsChecked == true)
                    {
                        disponible = "non";
                    }
                    else if (rd_oui.IsChecked == true)
                    {
                        disponible = "oui";
                    }
                    else
                    {
                        MessageBox.Show("Please select the availability.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    var Categorienom = cmb_nomCat.SelectedItem as string;
                    if (string.IsNullOrEmpty(Categorienom))
                    {
                        MessageBox.Show("Please select a category.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    var ca = context.Categorie.FirstOrDefault(a => a.Nom == Categorienom);
                    if (ca == null)
                    {
                        MessageBox.Show("Selected category not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    var CategorieID = ca.CategorieID;

                    var i = imagePath;

                    if (string.IsNullOrEmpty(i))
                    {
                        MessageBox.Show("Image path is empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    Boolean res = RechercheLivre();
                    if (res == true)
                    {
                        MessageBox.Show("Le Livre existe déjà", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        
                        try
                        {
                            // Chargez l'image à partir du chemin stocké dans 'imagePath'
                            byte[] imageBytes = File.ReadAllBytes(imagePath);

                            context.Livres.Add(new Livres()
                            {
                                titre = titre,
                                Auteur = auteur,
                                Disponible = disponible,
                                Prix = prix,
                                quantite = quantite,
                                CategorieID = CategorieID,
                                URLimage = i,
                                Img = imageBytes
                            });

                            context.SaveChanges();
                            txt_titre.Text = "";
                            txt_image.Text = "";
                            txt_auteur.Text = "";
                            if (rd_non.IsChecked == true)
                            {
                                rd_non.IsChecked = false;
                            }
                            else
                            {
                                rd_oui.IsChecked = false;
                            }
                            cmb_nomCat.Text = "";
                            txt_quantité.Text = "";
                            txt_prix.Text = "";
                            pictureBox.Source = null;
                            data.Clear();
                            read();
                            MessageBox.Show("L'enregistrement avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Une erreur s'est produite lors de la gestion de l'image : {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btn_Ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (pictureBox.Source != null &&
                !string.IsNullOrEmpty(txt_titre.Text) &&
                !string.IsNullOrEmpty(txt_auteur.Text) &&
                (rd_non.IsChecked == true || rd_oui.IsChecked == true) &&
                !string.IsNullOrEmpty(cmb_nomCat.Text) &&
                !string.IsNullOrEmpty(txt_prix.Text) &&
                !string.IsNullOrEmpty(txt_quantité.Text))
            {
                Ajouter();
            }
            else
            {
                MessageBox.Show("Remplir tous les informations, y compris l'image", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public Boolean RechercheLivre()
        {
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                Boolean b = false;
                var tite = txt_titre.Text;
                var li = context.Livres.FirstOrDefault(l => l.titre== tite);
                if (li != null)
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

        private void datagrid_livre_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (datagrid_livre.SelectedItem != null)
            {
                Livres selectedLivre = (Livres)datagrid_livre.SelectedItem;
                string selectedDispo = selectedLivre.Disponible;
                txt_prix.Text = selectedLivre.Prix.ToString();
                // Check the value of Disponible and set the radio button accordingly
                if (selectedDispo == "oui")
                {
                    rd_oui.IsChecked = true;
                    rd_non.IsChecked = false;  // You may want to uncheck rd_non
                }
                else
                {
                    rd_oui.IsChecked = false;
                    rd_non.IsChecked = true;  // You may want to uncheck rd_oui
                }

                // Rest of your code...
                int selectedCAT = selectedLivre.CategorieID;
                using (ApplicationDBContext context = new ApplicationDBContext())
                {
                    var ca = context.Categorie.FirstOrDefault(a => a.CategorieID == selectedCAT);
                    var nomCAT = ca.Nom;
                    cmb_nomCat.Text = nomCAT;

                    // Afficher l'image dans pictureBox
                    string imagePath = selectedLivre.URLimage;
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(imagePath);
                    bitmap.EndInit();
                    pictureBox.Source = bitmap;
                }
            }

        }

        public void delete()
        {
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                Livres selectedLivre = (Livres)datagrid_livre.SelectedItem;

                if (selectedLivre != null)
                {
                    context.Remove(selectedLivre);
                    context.SaveChanges();
                    txt_titre.Text = "";
                    txt_image.Text = "";
                    txt_auteur.Text = "";
                    if (rd_non.IsChecked == true)
                    {
                        rd_non.IsChecked = false;
                    }
                    else
                    {
                        rd_oui.IsChecked = false;
                    }
                    cmb_nomCat.Text = "";
                    data.Clear();
                    read();
                    MessageBox.Show("La suppression avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void Btn_Supprimer_Click(object sender, RoutedEventArgs e)
        {
            Livres selectedLivre = (Livres)datagrid_livre.SelectedItem;
            if (selectedLivre == null)
            {
                // Handle the case where no category is selected
                MessageBox.Show("Please select Livre.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                delete();
            }
        }

        private void btn_Chercher_Click(object sender, RoutedEventArgs e)
        {
            if (txt_titre.Text == "")
            {
                MessageBox.Show("Please give the title of the book you can search for.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Boolean res = RechercheLivre();
                if (res == true)
                {
                    MessageBox.Show("Le Livre exite  déja", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    data.Clear();
                    read();
                    MessageBox.Show("Le Livre n'exite pas déja", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
        }

        public void Update()
        {
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                Livres selectedLivre = (Livres)datagrid_livre.SelectedItem;

                var titre = txt_titre.Text;
                var auteur = txt_auteur.Text;
                var prix = float.Parse(txt_prix.Text);
                var quantite = int.Parse(txt_quantité.Text);
                var disponible = "";

                if (prix < 0)
                {
                    MessageBox.Show("Le prix invalid.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (quantite < 0)
                {
                    MessageBox.Show("Le quantite invalid.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (rd_non.IsChecked == true)
                {
                    disponible = "non";
                }
                else if (rd_oui.IsChecked == true)
                {
                    disponible = "oui";
                }
                else
                {
                    // Handle the case where neither radio button is checked
                    MessageBox.Show("Please select the availability.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var Categorienom = cmb_nomCat.SelectedItem as string;
                if (string.IsNullOrEmpty(Categorienom))
                {
                    // Handle the case where no category is selected
                    MessageBox.Show("Please select a category.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var ca = context.Categorie.FirstOrDefault(a => a.Nom == Categorienom);
                if (ca == null)
                {
                    // Handle the case where the selected category is not found
                    MessageBox.Show("Selected category not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var CategorieID = ca.CategorieID;

                // Assurez-vous que la variable imagePath est définie avec le chemin de l'image
               // Remplacez ceci par le chemin réel

                byte[] imageBytes = File.ReadAllBytes(txt_image.Text);
                Livres livreToUpdate = context.Livres.Single(x => x.LivreID == selectedLivre.LivreID);

                livreToUpdate.titre = titre;
                livreToUpdate.Auteur = auteur;
                livreToUpdate.Disponible = disponible;
                livreToUpdate.CategorieID = CategorieID;
                livreToUpdate.URLimage = imagePath;
                livreToUpdate.Img = imageBytes;
                livreToUpdate.Prix = prix;
                livreToUpdate.quantite=quantite;


                context.SaveChanges();

                txt_titre.Text = "";
                txt_image.Text = "";
                txt_auteur.Text = "";
                if (rd_non.IsChecked == true)
                {
                    rd_non.IsChecked = false;
                }
                else
                {
                    rd_oui.IsChecked = false;
                }
                cmb_nomCat.Text = "";
                txt_quantité.Text = "";
                txt_prix.Text = "";
                pictureBox.Source = null;
                data.Clear();
                read();
                MessageBox.Show("La modification avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }



        private void btn_Modifier_Click(object sender, RoutedEventArgs e)
        {
            Livres selectedLivre = (Livres)datagrid_livre.SelectedItem;
            if (selectedLivre == null)
            {
                MessageBox.Show("Please select Livre.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                if (txt_titre.Text != "" && txt_auteur.Text != "" && txt_image.Text != "" && (rd_non.IsChecked == true || rd_oui.IsChecked == true) && cmb_nomCat.Text != "" && txt_prix.Text !="" && txt_quantité.Text!="" && pictureBox.Source != null)
                {
                    Update();
                }
                else
                {
                    MessageBox.Show("Remplir tous les informations", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

      
    }
}
