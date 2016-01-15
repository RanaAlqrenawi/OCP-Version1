using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace XamlResponsiveTechniques
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += TestView_BackRequested;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            //UIViewSettings.GetForCurrentView().UserInteractionMode;
        }
        private void SplitViewButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        

    private void HomeButton_Click(object sender, RoutedEventArgs e)
    {

        //MyFrame.Navigate(typeof(HomePage));

    }

    private void FriendsButton_Click(object sender, RoutedEventArgs e)
    {

        // MyFrame.Navigate(typeof(MainPage));

    }

    private void Measurments_Click(object sender, RoutedEventArgs e)
    {
        // MyFrame.Navigate(typeof(MainPage));

    }



        private async void btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TxtTTL.Text = await AutoPredictionAzureMLClient.InvokeRequestResponseService(EquipmentID.Text, GroupID.Text,
                    SliderCycle.Value, SliderSequence.Value, SliderVP1.Value, SliderVP2.Value, SliderVP3.Value,
                    SliderVAP1.Value, SliderVAP2.Value, SliderVAP3.Value, SliderVAP4.Value, SliderVAP5.Value, SliderVAP6.Value, SliderVAP7.Value, SliderVAP8.Value, SliderVAP9.Value, SliderVAP10.Value,
                    SliderVHP1.Value, SliderVHP2.Value, SliderVHP3.Value, SliderVHP4.Value, SliderVHP5.Value, SliderVHP6.Value, SliderVHP7.Value, SliderVHP8.Value, SliderVHP9.Value, SliderVHP10.Value,
                    SliderVVP1.Value, SliderVVP2.Value, SliderVVP3.Value, SliderVVP4.Value, SliderVVP5.Value, SliderVVP6.Value, SliderVVP7.Value, SliderVVP8.Value, SliderVVP9.Value, SliderVVP10.Value,
                    SliderTP1.Value, SliderTP2.Value, SliderTP3.Value, SliderTP4.Value, SliderTP5.Value, SliderTP6.Value, SliderTP7.Value, SliderTP8.Value, SliderTP9.Value, SliderTP10.Value,
                    SliderTTL.Value

                    );

            }
            catch (Exception ex)
            {
                Windows.UI.Popups.MessageDialog md = new Windows.UI.Popups.MessageDialog(ex.Message);
                md.ShowAsync();
            }
        }
    }
}
