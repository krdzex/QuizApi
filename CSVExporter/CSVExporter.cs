using Contracts;
using CsvHelper;
using Shared.DTOs.Quiz;
using System.ComponentModel.Composition;
using System.Globalization;

namespace CSVExporter;

[Export(typeof(IExporter))]
public class CSVExporter : IExporter
{
    public string Format => "csv";

    public string ExportAsync(QuizWithQuestionTextDTO quiz)
    {
        using (var writer = new StringWriter())
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteField(quiz.Name);
            csv.NextRecord();

            foreach (var question in quiz.Questions)
            {
                csv.WriteField(question.Text);
                csv.NextRecord();
            }

            return writer.ToString();
        }
    }
}