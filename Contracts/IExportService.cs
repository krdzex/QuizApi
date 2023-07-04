namespace Contracts;
public interface IExportService
{
    string Format { get; }
    string Export(string path);
}