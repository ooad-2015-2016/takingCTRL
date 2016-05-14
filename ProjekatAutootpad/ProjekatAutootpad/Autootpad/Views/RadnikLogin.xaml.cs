﻿using ProjekatAutootpad.Autootpad.ViewModels;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjekatAutootpad.Autootpad.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RadnikLogin : Page
    {
        public RadnikLogin()
        {
            this.InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Treba li ovo?
            //var currentView = SystemNavigationManager.GetForCurrentView();
            //currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;

            PocetnaViewModel pocetnaViewModel = e.Parameter as PocetnaViewModel;
            DataContext = pocetnaViewModel;

        }

    }
}
