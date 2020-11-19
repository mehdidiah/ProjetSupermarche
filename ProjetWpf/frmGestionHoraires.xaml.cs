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
    /// Logique d'interaction pour frmGestionHoraires.xaml
    /// </summary>
    public partial class frmGestionHoraires : Window
    {
        GestionnaireBdd gstBdd;
        public frmGestionHoraires(GestionnaireBdd unGst)
        {
            InitializeComponent();
            gstBdd = unGst;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboEmployes.ItemsSource = gstBdd.GetAllEmployes();
            cboRayons.ItemsSource = gstBdd.GetAllRayons();

        }

        private void cboEmployes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            lstHoraireEmploye.ItemsSource = gstBdd.GetTravaillerEmploye((cboEmployes.SelectedItem as Employe).NumE);
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            if(cboEmployes.SelectedItem == null)
            {
                MessageBox.Show("Choisir un employe", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if(cboRayons.SelectedItem == null)
                {
                    MessageBox.Show("Choisir un rayon", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    string date = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                    gstBdd.InsererUnHoraire((cboEmployes.SelectedItem as Employe).NumE, (cboRayons.SelectedItem as Rayon).NumR , date, Convert.ToInt16(sldTempsPasse.Value));
                    lstHoraireEmploye.ItemsSource = null;
                    lstHoraireEmploye.ItemsSource = gstBdd.GetTravaillerEmploye((cboEmployes.SelectedItem as Employe).NumE);

                }
            }
        }

        
    }
}
