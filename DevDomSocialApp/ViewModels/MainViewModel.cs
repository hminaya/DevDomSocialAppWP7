using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Net;
using System.IO;
using DevDomSocialApp.ViewModels;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Windows.Threading;



namespace DevDomSocialApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
            this.Comunidades = new ObservableCollection<ItemViewModel>();
            this.Eventos = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; set; }

        public ObservableCollection<ItemViewModel> Comunidades { get; set; }

        public ObservableCollection<ItemViewModel> Eventos { get; set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {

            string Url = "http://js.developers.do/js/devdom.js?h=" + DateTime.Now.TimeOfDay.ToString();

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Url);
            req.Method = "GET";

            //call async
            req.BeginGetResponse(new AsyncCallback(jsonGetRequestStreamCallback), req);

        }

        void jsonGetRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            WebResponse response = ((HttpWebRequest)asynchronousResult.AsyncState).EndGetResponse(asynchronousResult);
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                string responseString = reader.ReadToEnd();
                reader.Close();

                respuesta obj = (respuesta)JsonConvert.DeserializeObject(responseString, typeof(respuesta));

                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    /// Cargar los tutoriales
                    foreach (var cat in obj.categorias)
                    {
                        this.Items.Add(new ItemViewModel() { LineOne = cat.categoryName, LineTwo = cat.description, LineThree = cat.imageUrl });
                    }

                    /// Cargar las comunidades
                    foreach (var com in obj.comunidades)
                    {
                        this.Comunidades.Add(new ItemViewModel() { LineOne = com.name, LineTwo = com.url + "  |  " + com.twitter, LineThree = com.description });
                    }

                    /// Cargar los eventos
                    foreach (var eve in obj.eventos)
                    {
                        this.Eventos.Add(new ItemViewModel() { LineOne = eve.name, LineTwo = eve.when + "  |  " + eve.where, LineThree = eve.what });
                    }

                    this.IsDataLoaded = true;
                });

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}