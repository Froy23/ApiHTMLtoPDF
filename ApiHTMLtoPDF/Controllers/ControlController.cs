using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using SelectPdf;
using System.IO;

namespace ApiHTMLtoPDF.Controllers
{
    public class ControlController : ApiController
    {
        [HttpPost]
        [Route("html/{code_html}")]
        public IHttpActionResult ConvertHTML_PDF(String code_html)
        {
            try
            {
                string pagezise = "A4";
                string orientation = "Portrait";
                int width = 1024;
                int heigtn = 100;

                ApiHTMLtoPDF.Layout.PDF pdf = new Layout.PDF();
                pdf._CodeHTML = code_html;
                pdf._PageZise = pagezise;
                pdf._Orientation = orientation;
                pdf._Width = width;
                pdf._Height = heigtn;

                PdfPageSize pagZise = (PdfPageSize)Enum.Parse(typeof(PdfPageSize), pagezise, true);
                PdfPageOrientation Orientation = (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation), orientation, true);
                int webPageWidth = Convert.ToInt32(width);
                int webPageHeight = Convert.ToInt32(heigtn);

                HtmlToPdf converter = new HtmlToPdf();

                converter.Options.PdfPageSize = pagZise;
                converter.Options.PdfPageOrientation = Orientation;
                converter.Options.WebPageWidth = webPageWidth;
                converter.Options.WebPageHeight = webPageHeight;

                PdfDocument doc = converter.ConvertHtmlString(code_html, "");
                HttpResponse httpResponse = new HttpResponse(new StreamWriter(new MemoryStream()));
                doc.Save(httpResponse, false, "Sample.pdf");
                doc.Close();
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
