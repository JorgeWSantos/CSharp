
public class listprinters
{
  public string listprinters()
  {
    List<string> printers = new List<string>();

    foreach (var item in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
        printers.Add(item.ToString());

    return printers;
  }
}
