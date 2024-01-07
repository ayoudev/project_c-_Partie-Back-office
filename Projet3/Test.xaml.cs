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
    /// Logique d'interaction pour Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        public List<test> data { get; set; }
        public Test()
        {
            InitializeComponent();
            DataContext = this;
            read();
        }
        public void read()
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                data = db.test.ToList();
                DG.ItemsSource = data;
            }
        }
    }
}
