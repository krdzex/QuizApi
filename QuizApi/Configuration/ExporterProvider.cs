using Contracts;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace QuizApi.Configuration;
public class ExporterProvider
{
    [ImportMany]
    public IEnumerable<IExporter> Exporters { get; set; }

    public ExporterProvider()
    {
        var catalog = new AggregateCatalog();
        catalog.Catalogs.Add(new DirectoryCatalog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "exporters")));
        var container = new CompositionContainer(catalog);
        container.ComposeParts(this);
    }

    public IExporter GetExporter(string format)
    {
        return Exporters.FirstOrDefault(e => e.Format == format);
    }
}