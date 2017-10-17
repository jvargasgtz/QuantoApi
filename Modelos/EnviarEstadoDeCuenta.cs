using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Modelos;
using System.Web;
using System.Data;
using Newtonsoft.Json;
using System.Net;
using MailChimp.Types;
using MailChimp;

namespace Modelos
{
    public class EnviarEstadoDeCuenta : IEnvioEstadoCuenta
    {
        public EnviarEstadoDeCuenta() { }

        public void EnviarEstadoCuentaPorCliente(EntidadCreditoBase entidad)
        {
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            iTextSharp.text.Font _FontHead = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL, BaseColor.WHITE);

            Document doc = new Document(PageSize.LETTER);
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(HttpContext.Current.Server.MapPath(@"~\Temp\Estadodecuenta.pdf"), FileMode.Create));
            doc.Open();

            PdfPTable tabla1 = new PdfPTable(3);
            PdfPTable tabla2 = new PdfPTable(1);
            PdfPTable tabla3 = new PdfPTable(1);
            PdfPTable tablacliente = new PdfPTable(2);

            tabla1.WidthPercentage = 100;

            iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(@"~\Image\Credimon-01.jpg"));
            imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_LEFT;
            float percentage = 0.0f;
            percentage = 150 / imagen.Width;
            imagen.ScalePercent(percentage * 100);

            PdfPCell columna1 = new PdfPCell(imagen);
            columna1.Right = Element.ALIGN_RIGHT;
            columna1.BorderWidth = 0;
            columna1.BorderWidthTop = 0;
            columna1.BorderWidthRight = 0;
            columna1.BorderWidthLeft = 0;
            tabla1.AddCell(columna1);

            columna1 = new PdfPCell(new Phrase("\nZONA INDUSTRIAL SN COL.CENTRO\nRFC:\nTEL 6391326740 CD DELICIAS, CHIH.", _standardFont));
            columna1.Right = Element.ALIGN_CENTER;
            columna1.BorderWidth = 0;
            columna1.BorderWidthTop = 0;
            columna1.BorderWidthRight = 0;
            columna1.BorderWidthLeft = 0;
            tabla1.AddCell(columna1);

            columna1 = new PdfPCell(new Phrase("                     Estado De Cuenta\n                 No.Pagina: \n                  Fecha: ", _standardFont));
            columna1.Right = Element.ALIGN_CENTER;
            columna1.BorderWidth = 0;
            columna1.BorderWidthTop = 0;
            columna1.BorderWidthRight = 0;
            columna1.BorderWidthLeft = 0;
            tabla1.AddCell(columna1);

            doc.Add(tabla1);
            doc.Add(new Paragraph(" "));

            tabla2.WidthPercentage = 100;

            PdfPCell columnat2 = new PdfPCell(new Phrase("Datos del Cliente", _FontHead));
            columnat2.BackgroundColor = BaseColor.BLACK;
            tabla2.AddCell(columnat2);

            doc.Add(tabla2);

            tablacliente.WidthPercentage = 100;

            PdfPCell columnacliente = new PdfPCell(new Phrase("Cliente", _standardFont));
            columnacliente.Right = Element.ALIGN_LEFT;
            columnacliente.BorderWidth = 0;
            columnacliente.BorderWidthTop = 0;
            columnacliente.BorderWidthRight = 0;
            columnacliente.BorderWidthLeft = 0;
            tablacliente.AddCell(columnacliente);

            columnacliente = new PdfPCell(new Phrase("" + entidad.Idcliente.ToString(), _standardFont));
            columnacliente.Right = Element.ALIGN_LEFT;
            columnacliente.BorderWidth = 0;
            columnacliente.BorderWidthTop = 0;
            columnacliente.BorderWidthRight = 0;
            columnacliente.BorderWidthLeft = 0;
            tablacliente.AddCell(columnacliente);

            columnacliente = new PdfPCell(new Phrase("Nombre", _standardFont));
            columnacliente.Right = Element.ALIGN_LEFT;
            columnacliente.BorderWidth = 0;
            columnacliente.BorderWidthTop = 0;
            columnacliente.BorderWidthRight = 0;
            columnacliente.BorderWidthLeft = 0;
            tablacliente.AddCell(columnacliente);

            columnacliente = new PdfPCell(new Phrase("" + entidad.Nombre, _standardFont));
            columnacliente.Right = Element.ALIGN_LEFT;
            columnacliente.BorderWidth = 0;
            columnacliente.BorderWidthTop = 0;
            columnacliente.BorderWidthRight = 0;
            columnacliente.BorderWidthLeft = 0;
            tablacliente.AddCell(columnacliente);

            columnacliente = new PdfPCell(new Phrase("Identificacion", _standardFont));
            columnacliente.Right = Element.ALIGN_LEFT;
            columnacliente.BorderWidth = 0;
            columnacliente.BorderWidthTop = 0;
            columnacliente.BorderWidthRight = 0;
            columnacliente.BorderWidthLeft = 0;
            tablacliente.AddCell(columnacliente);

            columnacliente = new PdfPCell(new Phrase("--", _standardFont));
            columnacliente.Right = Element.ALIGN_LEFT;
            columnacliente.BorderWidth = 0;
            columnacliente.BorderWidthTop = 0;
            columnacliente.BorderWidthRight = 0;
            columnacliente.BorderWidthLeft = 0;
            tablacliente.AddCell(columnacliente);

            columnacliente = new PdfPCell(new Phrase("Domicilio", _standardFont));
            columnacliente.Right = Element.ALIGN_LEFT;
            columnacliente.BorderWidth = 0;
            columnacliente.BorderWidthTop = 0;
            columnacliente.BorderWidthRight = 0;
            columnacliente.BorderWidthLeft = 0;
            tablacliente.AddCell(columnacliente);

            columnacliente = new PdfPCell(new Phrase("--", _standardFont));
            columnacliente.Right = Element.ALIGN_LEFT;
            columnacliente.BorderWidth = 0;
            columnacliente.BorderWidthTop = 0;
            columnacliente.BorderWidthRight = 0;
            columnacliente.BorderWidthLeft = 0;
            tablacliente.AddCell(columnacliente);

            doc.Add(tablacliente);

            doc.Add(new Paragraph(" "));
            tabla3.WidthPercentage = 100;
            PdfPCell encabezadoscreditos = new PdfPCell(new Phrase("Datos de Creditos", _FontHead));
            encabezadoscreditos.BackgroundColor = BaseColor.BLACK;
            tabla3.AddCell(encabezadoscreditos);

            doc.Add(tabla3);

            PdfPTable tablacreditos = new PdfPTable(entidad.dtcreditos.Columns.Count);
            tablacreditos.WidthPercentage = 100;
            foreach (DataColumn columnas in entidad.dtcreditos.Columns)
            {
                PdfPCell cell = new PdfPCell();
                cell.AddElement(new Chunk(columnas.ColumnName.ToString(), _standardFont));
                tablacreditos.AddCell(cell);
            }
            int i = 0, j = 0;
            foreach (DataRow filas in entidad.dtcreditos.Rows)
            {
                foreach (DataColumn columnas in entidad.dtcreditos.Columns)
                {
                    tablacreditos.AddCell(entidad.dtcreditos.Rows[i][j].ToString());
                    j++;
                }
                i++;
                j = 0;
            }
            doc.Add(tablacreditos);

            doc.Close();

            //MandrillApi api = new MandrillApi("GStybO25JJ5Krbv5icpXoA");
            //var mensaje = new Mandrill.Messages.Message();
            //var recipients = new List<Mandrill.Messages.Recipient>();
            //var name = string.Format("{0} {1}", "Jobert", "Enamno");
            //recipients.Add
            //(
            //    new Mandrill.Messages.Recipient("jvargas@syseti.com", "jesus vargas")
            //);

            //var message = new Mandrill.Messages.Message()
            //{
            //    To = recipients.ToArray(),
            //    FromEmail = "no-reply@syseti01.com",
            //    Subject = "Estado De Cuenta",
            //};

            //var ruta = new Mandrill.Messages.Attachment[]
            //{ new Mandrill.Messages.Attachment("application/pdf", "EstadoCuenta.pdf", true, Convert.ToBase64String(File.ReadAllBytes(HttpContext.Current.Server.MapPath(@"~\Temp\Estadodecuenta.pdf")))) };
            //var attachs = new Opt<Mandrill.Messages.Attachment[]>(ruta);
            //mensaje.Attachments = attachs;
            //api.Send(mensaje);
        }
    }
}
