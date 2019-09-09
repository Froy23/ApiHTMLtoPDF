using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiHTMLtoPDF.Layout
{
    public class PDF
    {
        public string _CodeHTML { set; get; }
        public string _PageZise { set; get; }
        public string _Orientation { set; get; }
        public int _Width { set; get; }
        public int _Height { set; get; }
    }
}