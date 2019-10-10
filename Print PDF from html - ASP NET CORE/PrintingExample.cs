using System;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Win32;
using IronPdf;

namespace web_api.src
{
    public class PrintingExample 
    {
        private List<String> Printers = new List<String>();
        public PrintingExample(){
            
            PdfPrintOptions printer = new PdfPrintOptions();
            printer.SetCustomPaperSizeinMilimeters(76,200);
            printer.MarginLeft = 0;
            printer.MarginRight = 5;
            printer.MarginTop=5;
            HtmlToPdf Renderer = new HtmlToPdf(printer);

            // // Renderer.RenderHtmlAsPdf("<h1>Hello World</h1>").SaveAs("html-string.pdf");

            var PDF = Renderer.RenderHTMLFileAsPdf("index.html");
            PDF.SaveAs("Invoice.pdf");

            PrintPDFs(OutputPath);
            FindAndKillProcess("AcroRd32");
        }

        //pega local path do acrobat e executa a impressao
        public static Boolean PrintPDFs(string pdfFileName)
        {
            try
             {
                Process proc = new Process();
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.Verb = "print";

                //Define location of adobe reader/command line
                //switches to launch adobe in "print" mode
                proc.StartInfo.FileName =  @"C:\Program Files (x86)\Adobe\Acrobat Reader DC\Reader\AcroRd32.exe";
                proc.StartInfo.Arguments = String.Format(@"/p /h {0}", pdfFileName);
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.CreateNoWindow = true;

                proc.Start();
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                if (proc.HasExited == false)
                {
                    proc.WaitForExit(10000);
                }

                proc.EnableRaisingEvents = true;

                proc.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }


        //mata o processo do acrobat
        public bool FindAndKillProcess(string name)
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    clsProcess.Kill();
                    return true;
                }
            }
            //process not found, return false
            return false;
        }
    }
}