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
using System.Runtime.Serialization;

namespace DevDomMobile.Models
{

    public class evento
    {
        public int id { get; set; }
        public string name { get; set; }
        public string what { get; set; }
        public string when { get; set; }
        public string where { get; set; }
        public string url { get; set; }

    }
}
