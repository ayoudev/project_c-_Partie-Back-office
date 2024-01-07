
using Microsoft.EntityFrameworkCore;
using Projet3.Model;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;


namespace Projet3
{
    /// <summary>
    /// Logique d'interaction pour Connecter.xaml
    /// </summary>
    public partial class Connecter : Window
    {
        public Connecter()
        {
            InitializeComponent();
            DataContext = this;

        }

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
           if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0 )
            {
                textEmail.Visibility = Visibility.Collapsed;

            }
            else
            {
                textEmail.Visibility = Visibility.Visible;
            }
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
           if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;

            }
            else
            {
                textPassword.Visibility = Visibility.Visible;
            }
        }

       


        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

       

        private void Image_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtEmail.Text =="" || txtPassword.Password == "")
            {
                MessageBox.Show("Remplir tous les informations.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                using (ApplicationDBContext context = new ApplicationDBContext())
                {
                    var email = txtEmail.Text;
                    var password = txtPassword.Password;

                    var ad = context.Admin.FirstOrDefault(a => a.email == email && a.password == password);

                    if (ad != null)
                    {
                        Acceuil a = new Acceuil();
                        a.Show();
                    }
                    else
                    {
                        MessageBox.Show("Échec de l'authentification. Veuillez vérifier vos identifiants.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
          
        }


    }
}
