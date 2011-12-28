using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Linq;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DevDomMobile.Models
{

    public class categoria
    {

        public int id { get; set; }
        public string categoryName { get; set; }
        public string description { get; set; }
        public string imageUrl { get; set; }
        public ObservableCollection<tutorial> tutorials { get; set; }

        public int tutorialCount
        {
            get
            {
                return this.tutorials.Count;
            }
        }

        public string tutorialCountDesc
        {
            get
            {
                if (this.tutorialCount == 1)
                {
                    return " tutorial disponible";
                }
                else
                {
                    return " tutoriales disponibles";
                }

            }
        }

        public string tutorialCountDescCompleto
        {
            get
            {
                return this.tutorials.Count + " " + this.tutorialCountDesc;
            }
        }

        public string randomImageUrl
        {
            get
            {
                try
                {
                    Random rnd = new Random();
                    var i = rnd.Next(0, this.tutorials.Count);

                    System.Diagnostics.Debug.WriteLine("i: " + i);
                    System.Diagnostics.Debug.WriteLine("url: " + this.tutorials[i].imageUrl);

                    return this.tutorials[i].imageUrl;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("ex: " + ex.ToString());
                    //throw ex;
                    return "";
                }
            }
        }

    }
}
