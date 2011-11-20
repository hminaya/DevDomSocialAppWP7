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

        public string tutorialCount
        {
            get
            {
                return this.tutorials.Count + " tutoriales disponibles";
            }
        }

        public string randomImageUrl
        {
            get
            {
                try
                {
                    Random rnd = new Random(0);
                    var i = rnd.Next(this.tutorials.Count);

                    return this.tutorials[i].imageUrl;
                }
                catch (Exception)
                {
                    return "";
                    
                }

            }
        }

    }
}
