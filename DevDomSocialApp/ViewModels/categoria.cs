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

namespace DevDomSocialApp.ViewModels
{
    [CollectionDataContract]
    public class categoria
    {
        [DataMember]
        public int id;
        [DataMember]
        public string categoryName;
        [DataMember]
        public string description;
        [DataMember]
        public string imageUrl;

        [DataMember]
        public List<tutorial> tutorials;


    }
}
