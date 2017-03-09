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
using ColourLibrary;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ColourTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IShowColour colourShower;
        public MainPage()
        {
            this.InitializeComponent();
            colourShower = new ShowColourHue();
        }

        private async void InitButton_Click(object sender, RoutedEventArgs e)
        {
            await colourShower.Initialize();
        }

        private async void OnButton_Click(object sender, RoutedEventArgs e)
        {
            await colourShower.TurnOn();
        }
        private async void OffButton_Click(object sender, RoutedEventArgs e)
        {
            await colourShower.TurnOff();
        }
        private async void GreenButton_Click(object sender, RoutedEventArgs e)
        {
            await colourShower.ShowColour(HueColour.Green);
        }
        private async void CycleButton_Click(object sender, RoutedEventArgs e)
        {
            await colourShower.Cycle();
        }
    }
}
