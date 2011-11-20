using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DevDomMobile.Models;
using Microsoft.Phone.Tasks;

namespace DevDomMobile
{
    public partial class tutoriales : PhoneApplicationPage
    {
        public tutoriales()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            var catId = Convert.ToInt32(NavigationContext.QueryString["catId"]);

            var respuesta = (respuesta)PhoneApplicationService.Current.State["respuesta"];
            DataContext = respuesta.categorias.FirstOrDefault(x => x.id == catId);

            base.OnNavigatedTo(e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var boton = (Button)sender;

            var cat = (categoria)DataContext;

            WebBrowserTask webbrowser = new WebBrowserTask();

            var url = new Uri(cat.tutorials.FirstOrDefault(x => x.id == Convert.ToInt32(boton.CommandParameter)).tutorialUrl);

            webbrowser.Uri = url;
            webbrowser.Show();



        }


    }
}