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
    [DataContract]
    public class respuesta
    {
        [DataMember(Name="categorias")]
        public List<categoria> categorias;

        [DataMember(Name="comunidades")]
        public List<comunidad> comunidades;

        [DataMember(Name = "eventos")]
        public List<evento> eventos;
    }
}
