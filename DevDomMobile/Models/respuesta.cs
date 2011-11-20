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
using DevDomMobile.Models;

namespace DevDomMobile.Models
{

    public class respuesta
    {
        public ObservableCollection<categoria> categorias { get; set; }
        public ObservableCollection<comunidad> comunidades { get; set; }
        public ObservableCollection<evento> eventos { get; set; }

        public ObservableCollection<podcast> podcasts { get; set; }

        public respuesta() { 
        
            categorias = new ObservableCollection<categoria>();
            comunidades = new ObservableCollection<comunidad>();
            eventos = new ObservableCollection<evento>();
        
        }
    }
}
