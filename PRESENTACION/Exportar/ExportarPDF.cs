using Microsoft.Reporting.WinForms;
using System;
using System.IO;
using System.Windows.Forms;

namespace PRESENTACION.Exportar
{
    public class ExportarPDF
    {
        public static void Save(LocalReport report, string path, string file, out string Mensaje)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var savefile = new SaveFileDialog();
                savefile.FileName = path + file;
                savefile.DefaultExt = ".pdf";

                if (File.Exists(savefile.FileName))
                {
                    if (MessageBox.Show("Ya Existe, Deseas Reemplazar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        Mensaje = "1";
                        return;
                    }
                    else
                    {
                        File.Delete(savefile.FileName);
                    }
                }
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {

                    Byte[] bytes = Mbytes(report);
                    stream.Write(bytes, 0, bytes.Length);
                    stream.Close();
                    Mensaje = "1";
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message + " El error es en Clase Exportar";
            }

        }
        private static Byte[] Mbytes(LocalReport report)
        {
            string deviceInfo =
      "<DeviceInfo>" +
      "  <OutputFormat>EMF</OutputFormat>" +
      "  <PageWidth>8.5in</PageWidth>" +//ancho
      "  <PageHeight>11in</PageHeight>" +//Altura
      "  <MarginTop>0.2in</MarginTop>" +//Margin Alto
      "  <MarginLeft>0.2in</MarginLeft>" +//Margin Izq
      "  <MarginRight>0.2in</MarginRight>" +//Margin Der
      "  <MarginBottom>0.2in</MarginBottom>" +//Margin Bajo
      "</DeviceInfo>";

            string reportType = "PDF";
            string mimeType = "application/pdf";
            string encoding = "utf-8";
            string fileNameExtension = "pdf";
            Warning[] warnings = new Warning[1];
            string[] streams = new string[1];

            return report.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
        }
    }
}
