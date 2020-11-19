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
    /// Logique d'interaction pour frmNewEmploye.xaml
    /// </summary>
    public partial class frmNewEmploye : Window
    {
        GestionnaireBdd gstBdd;
        public frmNewEmploye(GestionnaireBdd unGst)
        {
            InitializeComponent();
            gstBdd = unGst;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtNumero.Text = gstBdd.GetLastNumEmploye().ToString();
            lstEmployes.ItemsSource = gstBdd.GetAllEmployes();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            if(txtNom.Text == "")
            {
                MessageBox.Show("Insérer un nom", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                gstBdd.InsererEmploye(Convert.ToInt16(txtNumero.Text), txtNom.Text);
                lstEmployes.ItemsSource = null;
                lstEmployes.ItemsSource = gstBdd.GetAllEmployes();
                txtNumero.Text = gstBdd.GetLastNumEmploye().ToString();
                txtNom.Text = "";
            }
        }
    }
}
