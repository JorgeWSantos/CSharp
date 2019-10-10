using System;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using IronPdf;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Diagnostics;

namespace web_api.src
{
    public class PrintingExample 
    {
        List<String> Printers = new List<String>(); 
    
        public PrintingExample() 
        {
            listAllPrinters();
            SetPrinter();
            PrinterSettings settings = new PrinterSettings();
        }

        private void listAllPrinters()
        {
            foreach (var item in PrinterSettings.InstalledPrinters)
            {    
                Printers.Add(item.ToString());
            }
        }

        private void SetPrinter()
        {
            string pname = Printers[0].ToString();
            myPrinters.SetDefaultPrinter(pname);
        }

    }

    public static class myPrinters
    {
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Name);
    }
}