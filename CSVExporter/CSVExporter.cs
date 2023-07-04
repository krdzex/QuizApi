using Contracts;
using System.ComponentModel.Composition;

namespace CSVExporter
{
    [Export(typeof(IExporter))]
    public class CSVExporter : IExporter
    {
        public string Format => "csv";

        public string ExportAsync(string data)
        {

            return "";
        }
    }
}