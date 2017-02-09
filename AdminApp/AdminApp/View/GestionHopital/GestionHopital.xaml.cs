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

namespace AdminApp.View.GestionHopital
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
        }

        private void TextBlock_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void txtnom_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtnom.Text.Length>1 || txtnom.Text.All(char.IsLetter))
                { txtnom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green); }
            else
            {
                txtnom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            }
        }

        private void txtadresse_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtadresse.Text.Length>1 )
            { txtadresse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green); }
            else
             { txtadresse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red); } 
        }

        private void txtattitude_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtattitude.Text.Length > 1 || txtnom.Text.All(char.IsDigit))
            { txtadresse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green); }
            else
            { txtattitude.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red); }
        }

        private void txtlangitude_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtlangitude.Text.Length > 1 || txtnom.Text.All(char.IsDigit))
            { txtadresse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green); }
            else
            { txtlangitude.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red); }

        }
    }
}
