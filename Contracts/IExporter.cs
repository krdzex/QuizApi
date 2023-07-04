namespace Contracts;
public interface IExporter
{
    string Format { get; }
    string ExportAsync(string test);
}