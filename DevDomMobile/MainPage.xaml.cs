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


namespace DevDomMobile
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            this.DataContext = new respuesta();

            Loaded += delegate
            {

                var uri = new Uri("http://js.developers.do/js/devdom.js?h=" + DateTime.Now.TimeOfDay.ToString());
                var request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "GET";

                request.BeginGetResponse(HandleResponse, request);

            };

        }

        void HandleResponse(IAsyncResult ar)
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

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var listbox = (ListBox)sender;
            var cat = (categoria)listbox.SelectedItem;

            if (cat != null)
            {
              NavigationService.Navigate(new Uri("/tutoriales.xaml?catId=" + cat.id, UriKind.Relative));  
            }
            
        }
    }
}