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
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RadnikPodaciViewModel radnikPodaciViewModel = e.Parameter as RadnikPodaciViewModel;
            radnikPodaciViewModel.Camera = new CameraHelper(PreviewControl);
            DataContext = radnikPodaciViewModel;
        }
     }
}

