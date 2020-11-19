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
using System.Windows.Shapes;

namespace ProjetWpf
{
    /// <summary>
    /// Logique d'interaction pour frmRayonsSecteurs.xaml
    /// </summary>
    public partial class frmRayonsSecteurs : Window
    {
        GestionnaireBdd gstBdd;
        public frmRayonsSecteurs(GestionnaireBdd unGst)
        {
            InitializeComponent();
            gstBdd = unGst;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboSecteursRayons.ItemsSource = gstBdd.GetAllSecteurs();
        }

        private void cboSecteursRayons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cboSecteursRayons.SelectedItem != null)
            {
                lstSecteursRayons.ItemsSource = gstBdd.GetAllRayonsByNumS((cboSecteursRayons.SelectedItem as Secteur).NumSecteur);
            }
        }
                
    }
}
