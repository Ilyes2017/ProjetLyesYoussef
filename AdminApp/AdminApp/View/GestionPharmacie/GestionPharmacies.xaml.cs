using AdminApp.Model;
using AdminApp.View.GestionMedicament;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AdminApp.View.GestionPharmacie
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GestionPharmacies : Page
    {
        private MobileServiceCollection<Pharmacie, Pharmacie> pharmacies;
        private IMobileServiceTable<Pharmacie> pharmacietable = App.MobileService.GetTable<Pharmacie>();
        Pharmacie selectedpharmacie = new Pharmacie();
        public GestionPharmacies()
        {
            this.InitializeComponent();
            index();
            txtDisponibilite.Items.Add("jour");
            txtDisponibilite.Items.Add("nuit");
        }

        private async void index()
        {
            pharmacies = await pharmacietable.ToCollectionAsync();
            listv.ItemsSource = pharmacies;
        }

        private void txtNom_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtNom.Text.Length>1|| txtNom.Text.All(Char.IsLetter))
            {
                txtNom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
            }
            else
            {
                txtNom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            }
        }

        private void txtAdresse_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtAdresse.Text.Length > 1 )
            {
               txtAdresse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
            }
            else
            {
                txtAdresse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            }
        }

        private void txtLatitude_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtLatitude.Text.Length > 1 || txtLatitude.Text.All(Char.IsDigit))
            {
                txtLatitude.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green); }
            else
            {
                txtLatitude.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            }
        }

        private void txtLongetude_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtLongetude.Text.Length > 1 || txtLongetude.Text.All(Char.IsDigit))
            {
                txtLongetude.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
            }
            else
            {
                txtLongetude.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            }

        }

        private void listv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedpharmacie = listv.SelectedItem as Pharmacie;
            txtNom.Text = selectedpharmacie.nom;
            txtAdresse.Text = selectedpharmacie.adresse;
            txtDisponibilite.PlaceholderText = selectedpharmacie.disponibilite;
            txtLongetude.Text = selectedpharmacie.longitude.ToString();
            txtLatitude.Text = selectedpharmacie.latitude.ToString();
            btnmedicament.Visibility = Visibility.Visible;
        }

        private async void btnajout_Click(object sender, RoutedEventArgs e)
        {
            Pharmacie ph = new Pharmacie { nom = txtNom.Text, adresse = txtAdresse.Text, disponibilite = txtDisponibilite.SelectedValue.ToString(), latitude = Double.Parse(txtLatitude.Text), longitude = Double.Parse(txtLongetude.Text) };
            await pharmacietable.InsertAsync(ph);
            Frame.Navigate(typeof(GestionPharmacies));
        }

        private async void btnmodif_Click(object sender, RoutedEventArgs e)
        {
            Pharmacie ph = new Pharmacie {Id=selectedpharmacie.Id, nom = txtNom.Text, adresse = txtAdresse.Text, disponibilite = txtDisponibilite.SelectedItem.ToString(), latitude = Double.Parse(txtLatitude.Text), longitude = Double.Parse(txtLongetude.Text) };
            await pharmacietable.UpdateAsync(ph);
            Frame.Navigate(typeof(GestionPharmacies));
        }

        private async void btndel_Click(object sender, RoutedEventArgs e)
        {
            await pharmacietable.DeleteAsync(selectedpharmacie);
            Frame.Navigate(typeof(GestionPharmacies));
        }

        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            modal.Visibility = Visibility.Visible;
            stackmaj.Visibility = Visibility.Collapsed;
        }

        private void btndetail_Click(object sender, RoutedEventArgs e)
        {
            modal.Visibility = Visibility.Visible;
            btnajout.Visibility = Visibility.Collapsed;
        }

        private void testplace_Click(object sender, RoutedEventArgs e)
        {
            // Specify a known location.
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = Double.Parse(txtLatitude.Text), Longitude = Double.Parse(txtLongetude.Text) };
            Geopoint cityCenter = new Geopoint(cityPosition);

            // Set the map location.
            MapControl1.Center = cityCenter;
            MapControl1.ZoomLevel = 12;
            MapControl1.LandmarksVisible = true;
        }

        private void btnmedicament_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(IndexMedicament));
        }

        private void txtNom_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
