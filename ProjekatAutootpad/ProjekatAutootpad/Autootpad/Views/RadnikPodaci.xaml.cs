using ProjekatAutootpad.Autootpad.Helper;
using ProjekatAutootpad.Autootpad.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjekatAutootpad.Autootpad.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RadnikPodaci : Page
    {
        public RadnikPodaci()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += ThisPage_BackRequested;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            /*DodavanjeDijelaRadnikViewModel dodavanjeDijelaRadnik = e.Parameter as DodavanjeDijelaRadnikViewModel;
            DataContext = dodavanjeDijelaRadnik;*/

            RadnikPodaciViewModel radnikPodaciViewModel = e.Parameter as RadnikPodaciViewModel;
            radnikPodaciViewModel.Camera = new CameraHelper(PreviewControl);
            DataContext = radnikPodaciViewModel;
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }
        private void ThisPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }
    }
}

