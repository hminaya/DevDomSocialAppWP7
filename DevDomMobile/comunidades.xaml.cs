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
using DevDomMobile.Models;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace DevDomMobile
{
    public partial class comunidades : PhoneApplicationPage
    {
        public comunidades()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            var comId = Convert.ToInt32(NavigationContext.QueryString["comId"]);

            var respuesta = (respuesta)PhoneApplicationService.Current.State["respuesta"];
            DataContext = respuesta.comunidades.FirstOrDefault(x => x.id == comId);

            base.OnNavigatedTo(e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var boton = (Button)sender;

            var com = (comunidad)DataContext;

            WebBrowserTask webbrowser = new WebBrowserTask();

            var url = new Uri(com.url);

            webbrowser.Uri = url;
            webbrowser.Show();
        }
    }
}