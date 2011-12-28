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
using System.IO;
using System.Runtime.Serialization.Json;
using DevDomMobile.Models;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System.Net.NetworkInformation;


namespace DevDomMobile
{
    public partial class MainPage : PhoneApplicationPage
    {
        public Uri uri;

        public MainPage()
        {

            InitializeComponent();

            this.DataContext = new respuesta();


            if (!isInternetAvailable())
            {
                MessageBox.Show("Usted no tiene acceso a Internet, favor verificar su conexion e intentar mas tarde...");
                NavigationService.GoBack();
            }
            else
            {

                Loaded += delegate
                {
                    
                    uri = new Uri("http://js.developers.do/js/devdom.js");
                    
                    var request = (HttpWebRequest)WebRequest.Create(uri);
                    request.Method = "GET";

                    request.BeginGetResponse(HandleResponse, request);

                };
            }

        }

        public bool isInternetAvailable()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }

        void HandleResponse(IAsyncResult ar)
        {
            try
            {
                WebResponse response = ((HttpWebRequest)ar.AsyncState).EndGetResponse(ar);


                var serializer = new DataContractJsonSerializer(typeof(respuesta));

                var resp = (respuesta)serializer.ReadObject(response.GetResponseStream());

                Dispatcher.BeginInvoke(() =>
                {

                    this.DataContext = resp;
                    PhoneApplicationService.Current.State["respuesta"] = resp;

                });
            }
            catch (Exception ex)
            {
                Dispatcher.BeginInvoke(() => {
                    MessageBox.Show("Tuvimos problema accediendo al internet (" + uri + "), favor verificar.");
                    NavigationService.GoBack();
                });
                
            }
            
        }

        private void Categoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var listbox = (ListBox)sender;
            var cat = (categoria)listbox.SelectedItem;

            if (cat != null)
            {
                NavigationService.Navigate(new Uri("/tutoriales.xaml?catId=" + cat.id, UriKind.Relative));
            }

        }

        private void Podcast_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = (ListBox)sender;
            var pod = (podcast)listbox.SelectedItem;

            if (pod != null)
            {
                NavigationService.Navigate(new Uri("/podcasts.xaml?podId=" + pod.id, UriKind.Relative));
            }

        }

        private void Comunidad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = (ListBox)sender;
            var com = (comunidad)listbox.SelectedItem;

            if (com != null)
            {
                NavigationService.Navigate(new Uri("/comunidades.xaml?comId=" + com.id, UriKind.Relative));
            }
        }

        private void Colaboradores_Tap(object sender, GestureEventArgs e)
        {
            WebBrowserTask webbrowser = new WebBrowserTask();

            var url = new Uri("http://developers.do/post/12739647995/developers-dominicanos-quienes-somos");

            webbrowser.Uri = url;
            webbrowser.Show();
        }
    }
}