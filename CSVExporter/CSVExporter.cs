using Contracts;
using System.ComponentModel.Composition;

namespace CSVExporter
{
    [Export(typeof(IExportService))]
    public class DocFormatReader : IExportService
    {
        public string Format => ".csv";

        public string Export(string path)
        {
            //var dc = DocumentCore.Load(path);
            //var runList = dc.GetChildElements(true, ElementType.Run).Select(x => x.Content.ToString());
            return "";
        }
    }
}