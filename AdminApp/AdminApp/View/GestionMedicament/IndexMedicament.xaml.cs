using AdminApp.Model;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace AdminApp.View.GestionMedicament
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class IndexMedicament : Page
    {
        private MobileServiceCollection<Medicament, Medicament> medicaments;
        private IMobileServiceTable<Medicament> medicamenttable = App.MobileService.GetTable<Medicament>();
        Medicament selectedmedicament = new Medicament();

        public IndexMedicament()
        {
            this.InitializeComponent();
        }

        private void TextBlock_LostFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void txtnom_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtnom.Text.Length > 1)
            {
                txtnom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                    }
            else {
                txtnom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                    }
                    
        }

        private void txtutilisation_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtutilisation.Text.Length > 1)
            {
                txtutilisation.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                    }
            else
            {
                txtutilisation.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                    }

        }

        private void txtprix_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtprix.Text.Length > 1 || txtprix.Text.All(char.IsDigit))
            {
                txtprix.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
            }
            else
            {
                txtprix.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            }
        }

        private void txtfabrication_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            if (txtfabrication.Date <= DateTime.Now.Date)
            {
                txtfabrication.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);

            }
            else
            {
                txtfabrication.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            }
        }

        private void txtexpiration_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            if (txtexpiration.Date > DateTime.Now.Date)
            {
                txtexpiration.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);

            }
            else
            {
                txtexpiration.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            }
        }

        private async void btnadd_Click(object sender, RoutedEventArgs e)
        {
            Medicament med = new Medicament { nom=txtnom.Text, utilisation=txtutilisation.Text, prix=Double.Parse(txtprix.Text), DateFabrication=txtfabrication.Date.DateTime, Dateexpiration=txtexpiration.Date.DateTime, idPharmcie=App.currentph.Id };
            await medicamenttable.InsertAsync(med);
            Frame.Navigate(typeof(IndexMedicament));
        }

        private async void btndel_Click(object sender, RoutedEventArgs e)
        {
            Medicament med = new Medicament {Id=selectedmedicament.Id, nom = txtnom.Text, utilisation = txtutilisation.Text, prix = Double.Parse(txtprix.Text), DateFabrication = txtfabrication.Date.DateTime, Dateexpiration = txtexpiration.Date.DateTime, idPharmcie = App.currentph.Id };
            await medicamenttable.InsertAsync(med);
            Frame.Navigate(typeof(IndexMedicament));
        }

        private async void btnup_Click(object sender, RoutedEventArgs e)
        {
            await medicamenttable.DeleteAsync(selectedmedicament);
            Frame.Navigate(typeof(IndexMedicament));
        }
    }
}
