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

namespace DevDomSocialApp.ViewModels
{
    [CollectionDataContract]
    public class evento
    {
        [DataMember]
        public int id;
        [DataMember]
        public string name;
        [DataMember]
        public string what;
        [DataMember]
        public string when;
        [DataMember]
        public string where;
        [DataMember]
        public string url;

    }
}
