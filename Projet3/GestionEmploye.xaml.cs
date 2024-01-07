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
    /// Logique d'interaction pour GestionEmploye.xaml
    /// </summary>
    public partial class GestionEmploye : Window
    {
        public List<Employe> data { get; set; }
        public List<String> type { get; set; }


        public GestionEmploye()
        {
            InitializeComponent();
            DataContext = this;
            read();
            GetPosteType();
        }
        public void GetPosteType()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                type = db.Poste.Select(c => c.type).ToList();
            }
        }
        public void read()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                data = db.Employe.ToList();
                DATA.ItemsSource = data;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        public bool RechercheEmploye()
        {
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                var mat = txt_matricule.Text;
                return context.Employe.Any(e => e.Matricule == mat);
            }
        }

        public void Ajouter()
        {
            try
            {
                using (ApplicationDBContext context = new ApplicationDBContext())
                {
                    var matricule = txt_matricule.Text;
                    var nom = txt_nom.Text;
                    var prenom = txt_prenom.Text;
                    var poste = cmb_poste.SelectedItem as string;

                    if (string.IsNullOrEmpty(poste))
                    {
                        MessageBox.Show("Veuillez sélectionner un poste.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    var p = context.Poste.FirstOrDefault(a => a.type == poste);

                    if (p == null)
                    {
                        MessageBox.Show("Le poste sélectionné n'a pas été trouvé.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    var postID = p.idPost;

                    if (DateTime.TryParse(txt_dateEM.Text, out var dateEmbauche))
                    {
                        if (int.TryParse(txt_salaire.Text, out var salaire))
                        {
                            var adresse = txt_adresse.Text;
                            var telephone = txt_telephone.Text;

                            if (!RechercheEmploye())
                            {
                                context.Employe.Add(new Employe()
                                {
                                    Matricule = matricule,
                                    Nom = nom,
                                    Prenom = prenom,
                                    idPost = postID, // Assuming Poste is an int field
                                    DateEmbauche = dateEmbauche,
                                    Salaire = salaire,
                                    Adresse = adresse,
                                    NumeroTelephone = telephone,
                                });

                                context.SaveChanges();

                                txt_matricule.Text = "";
                                txt_nom.Text = "";
                                txt_prenom.Text = "";
                                txt_salaire.Text = "";
                                txt_telephone.Text = "";
                                txt_dateEM.Text = "";
                                cmb_poste.Text = "";
                                data.Clear();
                                read();
                                MessageBox.Show("L'enregistrement a réussi", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else
                            {
                                MessageBox.Show("L'employé existe déjà", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Salaire invalide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Date d'embauche invalide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur s'est produite : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void btn_ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_matricule.Text) &&
                !string.IsNullOrWhiteSpace(txt_nom.Text) &&
                !string.IsNullOrWhiteSpace(txt_prenom.Text) &&
                !string.IsNullOrWhiteSpace(cmb_poste.Text) &&
                txt_dateEM.SelectedDate.HasValue &&
                !string.IsNullOrWhiteSpace(txt_salaire.Text) &&
                !string.IsNullOrWhiteSpace(txt_adresse.Text) &&
                !string.IsNullOrWhiteSpace(txt_telephone.Text))
            {
                Ajouter();
            }
            else
            {
                MessageBox.Show("Remplir tous les informations", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void delete()
        {
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                Employe selectedEMP = (Employe)DATA.SelectedItem;

                if (selectedEMP != null)
                {
                    context.Remove(selectedEMP);
                    context.SaveChanges();
                    txt_matricule.Text = "";
                    txt_nom.Text = "";
                    txt_prenom.Text = "";
                    txt_salaire.Text = "";
                    txt_telephone.Text = "";
                    txt_dateEM.Text = "";
                    cmb_poste.Text = "";
                    data.Clear();
                    read();
                    MessageBox.Show("La suppression avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void btn_supprimer_Click(object sender, RoutedEventArgs e)
        {
            Employe selectedEMP = (Employe)DATA.SelectedItem;

            if (selectedEMP == null)
            {
                // Handle the case where no employee is selected
                MessageBox.Show("Please select an employee to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                delete();
            }
        }

        private void DATA_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (DATA.SelectedItem != null)
            {
                Employe selectedEmploye = (Employe)DATA.SelectedItem;

                int posteID = selectedEmploye.idPost;
                using (ApplicationDBContext context = new ApplicationDBContext())
                {
                    var poste = context.Poste.FirstOrDefault(p => p.idPost == posteID);
                    if (poste != null)
                    {
                        cmb_poste.Text = poste.type;
                    }

                    // Set the DateEmbauche to the DatePicker
                    txt_dateEM.SelectedDate = selectedEmploye.DateEmbauche;
                }
            }

        }

        private void btn_chercher_Click(object sender, RoutedEventArgs e)
        {
            if (txt_matricule.Text == "")
            {
                MessageBox.Show("Please provide the matricule of the employee you want to search for.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                bool employeeExists = RechercheEmploye();
                string message = employeeExists ? "L'employé existe déjà." : "L'employé n'existe pas encore.";
                MessageBox.Show(message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                if (!employeeExists)
                {
                    data.Clear();
                    read();
                }
            }
        }

        public void update()
        {
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                Employe selectedEMP = (Employe)DATA.SelectedItem;
                if (selectedEMP == null)
                {
                    MessageBox.Show("Veuillez sélectionner un Employé.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    try
                    {
                        var matricule = txt_matricule.Text;
                        var nom = txt_nom.Text;
                        var prenom = txt_prenom.Text;
                        var poste = cmb_poste.SelectedItem as string;

                        if (string.IsNullOrEmpty(poste))
                        {
                            MessageBox.Show("Veuillez sélectionner un poste.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        var p = context.Poste.FirstOrDefault(a => a.type == poste);

                        if (p == null)
                        {
                            MessageBox.Show("Le poste sélectionné n'a pas été trouvé.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        var postID = p.idPost;
                        decimal salaire;

                        if (DateTime.TryParse(txt_dateEM.Text, out var dateEmbauche))
                        {
                            if (decimal.TryParse(txt_salaire.Text, out salaire) && salaire >= 0)
                            {
                                var adresse = txt_adresse.Text;
                                var telephone = txt_telephone.Text;

                                Employe E = context.Employe.Single(x => x.Matricule == selectedEMP.Matricule);
                                E.Matricule = matricule;
                                E.Nom = nom;
                                E.Prenom = prenom;
                                E.Adresse = adresse;
                                E.Salaire = salaire;
                                E.idPost = postID;
                                E.NumeroTelephone = telephone;
                                E.DateEmbauche = dateEmbauche;

                                context.SaveChanges();
                                data.Clear();
                                read();
                                txt_matricule.Text = "";
                                txt_nom.Text = "";
                                txt_prenom.Text = "";
                                txt_salaire.Text = "";
                                txt_telephone.Text = "";
                                txt_dateEM.Text = "";
                                cmb_poste.Text = "";

                                MessageBox.Show("La modification avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else
                            {
                                MessageBox.Show("Salaire invalide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Date d'embauche invalide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Une erreur s'est produite : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btn_modifier_Click(object sender, RoutedEventArgs e)
        {
            update();
        }

    }
}
