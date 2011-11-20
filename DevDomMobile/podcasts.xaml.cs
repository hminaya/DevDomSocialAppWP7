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
using Microsoft.Phone.Tasks;

namespace DevDomMobile.Models
{
    public partial class podcasts : PhoneApplicationPage
    {
        public podcasts()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            var podId = Convert.ToInt32(NavigationContext.QueryString["podId"]);

            var respuesta = (respuesta)PhoneApplicationService.Current.State["respuesta"];
            DataContext = respuesta.podcasts.FirstOrDefault(x => x.id == podId);

            base.OnNavigatedTo(e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var boton = (Button)sender;

            var pod = (podcast)DataContext;

            WebBrowserTask webbrowser = new WebBrowserTask();

            var url = new Uri(pod.url);

            webbrowser.Uri = url;
            webbrowser.Show();
        }
    }
}