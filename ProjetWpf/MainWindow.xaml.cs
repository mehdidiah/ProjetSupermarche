using ProjetMetier;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetWpf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GestionnaireBdd gstBdd;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gstBdd = new GestionnaireBdd();
        }

        private void btnRayonSecteur_Click(object sender, RoutedEventArgs e)
        {
            frmRayonsSecteurs frm = new frmRayonsSecteurs(gstBdd);
            frm.Show();
        }

        private void btnNewEmploye_Click(object sender, RoutedEventArgs e)
        {
            frmNewEmploye frm = new frmNewEmploye(gstBdd);
            frm.Show();
        }

        private void btnGestionHoraires_Click(object sender, RoutedEventArgs e)
        {
            frmGestionHoraires frm = new frmGestionHoraires(gstBdd);
            frm.Show();
        }
    }
}
