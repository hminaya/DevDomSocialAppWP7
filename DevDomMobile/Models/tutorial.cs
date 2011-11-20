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

    public class tutorial
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tutorialUrl { get; set; }
        public string imageUrl { get; set; }

    }
}
