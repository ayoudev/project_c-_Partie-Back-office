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
    /// Logique d'interaction pour GestionRes.xaml
    /// </summary>
    public partial class GestionRes : Window
    {
        public List<Reservation> data { get; set; }
        public List<String> AdherentsName { get; set; }
        public List<String> titreLivre { get; set; }

        public GestionRes()
        {
            InitializeComponent();
            DataContext = this;
            GetAdherent_Name();
            Gettitre_Livre();
            read();
        }
        public void read()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                data = db.Reservation.ToList();
                DATA.ItemsSource = data;
            }
        }
        public void GetAdherent_Name()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                AdherentsName = db.Adherents.Select(c => c.Nom).ToList();
            }
        }
        public void Gettitre_Livre()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                titreLivre = db.Livres.Select(c => c.titre).ToList();
            }
        }

        private void DATA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DATA.SelectedItem != null)
            {
                Reservation selectedRes = (Reservation)DATA.SelectedItem;
                string selectedEmp = selectedRes.EstEmprunte;

                // Check the value of Disponible and set the radio button accordingly
                if (selectedEmp == "oui")
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
                int selectedAD = selectedRes.AdherentID;
                int selectedLV = selectedRes.LivreID;
                using (ApplicationDBContext context = new ApplicationDBContext())
                {
                    var ca = context.Adherents.FirstOrDefault(a => a.AdherentID == selectedAD);
                    cmb_nomA.Text = ca.Nom;

                    var li= context.Livres.FirstOrDefault(a => a.LivreID == selectedLV);
                    cmb_titreLivre.Text = li.titre;
                }
                DatePicker_Res.SelectedDate = selectedRes.DateReservation;

                DatePicker_retour.SelectedDate = selectedRes.DateRetourPrevu;

            }
        }

        public void delete()
        {
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                Reservation selectedRES = (Reservation)DATA.SelectedItem;

                if (selectedRES != null)
                {
                    context.Remove(selectedRES);
                    context.SaveChanges();
                    DatePicker_Res.Text = "";
                    DatePicker_retour.Text = "";

                    if (rd_non.IsChecked == true)
                    {
                        rd_non.IsChecked = false;
                    }
                    else
                    {
                        rd_oui.IsChecked = false;
                    }
                    cmb_nomA.Text = "";
                    cmb_titreLivre.Text = "";
                    data.Clear();
                    read();
                    MessageBox.Show("La suppression avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void btn_Supprimer_Click(object sender, RoutedEventArgs e)
        {
            Reservation selectedRES = (Reservation)DATA.SelectedItem;

            if (selectedRES == null)
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
    }
}
