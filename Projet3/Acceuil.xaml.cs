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
using System.Windows.Threading;

namespace Projet3
{
    /// <summary>
    /// Logique d'interaction pour Acceuil.xaml
    /// </summary>
    public partial class Acceuil : Window
    {
        DispatcherTimer timer;
        double panelWith;
        bool hidden;
        public Acceuil()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += Timer_Tick;

            panelWith = sidePanel.Width;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (hidden)
            {
                sidePanel.Width += 1;
                if (sidePanel.Width >= panelWith)
                {
                    timer.Stop();
                    hidden = false;
                }
            }
            else
            {
                sidePanel.Width -= 1;
                if (sidePanel.Width <= 30)
                {
                    timer.Stop();
                    hidden = true;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void panelHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed )
            {

            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
           GestionAD ad = new GestionAD();
            ad.Show();
        }

        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            GestionEmploye em = new GestionEmploye();
            em.Show();
        }

        private void TextBlock_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            GestionLivre l = new GestionLivre();
            l.Show();
        }

        private void TextBlock_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            GestionRes r = new GestionRes();
            r.Show();
        }
    }
}
