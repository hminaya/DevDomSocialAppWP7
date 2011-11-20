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

namespace DevDomMobile.Models
{
    public class podcast
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string descriptionShort
        {
            get
            {
                return Util.RecortarDescripcion(description, 40);
            }
        }
        public string url { get; set; }
        public string twitter { get; set; }
        public string logo { get; set; }
    }
}
