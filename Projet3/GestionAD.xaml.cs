using Microsoft.Win32;
using Projet3.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Xml.Linq;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;


namespace Projet3
{
    /// <summary>
    /// Logique d'interaction pour GestionAD.xaml
    /// </summary>
    public partial class GestionAD : Window
    {
        public List<Adherents> data { get; set; }

        public GestionAD()
        {
            InitializeComponent();
            DataContext = this; 
            read();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txt_nom.Text != "" && txt_prenom.Text != "" && txt_tele.Text != "" && txt_email.Text != "" && txt_adr.Text != "")
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
                var prenom = txt_prenom.Text;
                var telephone = txt_tele.Text;
                var adresse = txt_adr.Text;
                var email = txt_email.Text;

              
                    Boolean res = RechercherAdherent();
                    if(res == false)
                    {
                        context.Adherents.Add(new Adherents()
                        {
                            Nom = nom,
                            Prenom = prenom,
                            telephone = telephone,
                            adresse = adresse,
                            Email = email
                        });
                        context.SaveChanges();
                        data.Clear();
                        read();
                        txt_nom.Text = "";
                        txt_prenom.Text = "";
                        txt_tele.Text = "";
                        txt_adr.Text = "";
                        txt_email.Text = "";
                        MessageBox.Show("L'enregistrement avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    {
                        MessageBox.Show("L'Adherent existe déja");
                    } 
               
            }
        }
        public void read()
        {
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                data = context.Adherents.ToList();
                DATA.ItemsSource = data;
            }
        }

        public void delete()    
        {
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                var Nom = txt_nom.Text;
                var Prenom = txt_prenom.Text;



                var ad = context.Adherents.FirstOrDefault(a => a.Nom == Nom && a.Prenom == Prenom);
                if (ad != null)
                {
                    context.Remove(ad);
                    context.SaveChanges();

                    data.Clear();
                    read();
                    MessageBox.Show("La suppression avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    data.Clear();
                    read();
                    MessageBox.Show("L'adherents n'existe pas.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                } 
            }
        }


        public void update()
        {
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                Adherents selectedAD = DATA.SelectedItem as Adherents;
                var nom = txt_nom.Text;
                var prenom = txt_prenom.Text;
                var telephone = txt_tele.Text;
                var adresse = txt_adr.Text;
                var email = txt_email.Text;
                if (nom != null && prenom != null && telephone != null && adresse != null && email != null)
                {
                    Adherents ad = context.Adherents.Single(x => x.AdherentID == selectedAD.AdherentID);
                    ad.Nom = nom;
                    ad.Prenom = prenom;
                    ad.telephone = telephone;
                    ad.adresse = adresse;
                    ad.Email = email;

                    context.SaveChanges();
                    data.Clear();
                    read();
                    MessageBox.Show("La modification avec succès", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        public Boolean RechercherAdherent()
        {
            using (ApplicationDBContext context = new ApplicationDBContext())
            {
                Boolean b = false;
                var Nom = txt_nom.Text;
                var Prenom = txt_prenom.Text;
                var adherent = context.Adherents.FirstOrDefault(a => a.Nom == Nom && a.Prenom == Prenom);
                if (adherent != null)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (txt_nom.Text != "" && txt_prenom.Text != "")
            {
                delete();
            }
            else
            {
                MessageBox.Show("Remplir tous les informations.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var res = RechercherAdherent();
            if (res == true)
            {
                MessageBox.Show("L'Adherent existe");
            }
            else
            {
                data.Clear();
                read();
                MessageBox.Show("L'adherents n'existe pas.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (txt_nom.Text != "" && txt_prenom.Text != "" && txt_tele.Text != "" && txt_email.Text != "" && txt_adr.Text != "")
            {
                update();
            }
            else
            {
                MessageBox.Show("Remplir tous les informations.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void btn_Export_Click(object sender, RoutedEventArgs e)
        {
            ExportExel ex = new ExportExel(DATA,DateTime.Now);
        }

        private string GetExcelFilePath()
        {
            string filePath = null;

            // Configure et affiche la boîte de dialogue de sélection de fichier
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Fichiers Excel (*.xlsx, *.xls)|*.xlsx;*.xls|Tous les fichiers (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            bool? result = openFileDialog.ShowDialog();

            // Vérifie si l'utilisateur a sélectionné un fichier
            if (result == true)
            {
                filePath = openFileDialog.FileName;
            }

            return filePath;
        }

        private void ReadCsvFile(string filePath)
        {
            DataTable dt = new DataTable();

            // Configure les colonnes dans le DataTable
            dt.Columns.Add("AdherentID", typeof(int));
            dt.Columns.Add("Nom", typeof(string));
            dt.Columns.Add("Prenom", typeof(string));
            dt.Columns.Add("Telephone", typeof(string));
            dt.Columns.Add("Adresse", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            // Ajoutez d'autres colonnes selon le nombre de colonnes dans votre fichier CSV

            // Utilise TextFieldParser pour lire le fichier CSV
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                // Ignore la première ligne si elle contient des en-têtes
                if (!parser.EndOfData)
                {
                    string[] headers = parser.ReadFields();
                }

                // Lecture des lignes du fichier CSV et ajout dans le DataTable
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    DataRow row = dt.NewRow();
                    for (int i = 0; i < fields.Length; i++)
                    {
                        row[i] = fields[i];
                    }

                    dt.Rows.Add(row);
                }
            }

            // Associe le DataTable au DataGrid
            DATA.ItemsSource = dt.DefaultView;
        }



        private void btn_import_Click(object sender, RoutedEventArgs e)
        {
            ReadCsvFile(GetExcelFilePath());
        }
    }
}
