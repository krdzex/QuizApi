using Contracts;
using CsvHelper;
using Shared.DTOs.Quiz;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Text;

namespace CSVExporter;

[Export(typeof(IExporter))]
public class CSVExporter : IExporter
{
    public string Format => "csv";
    public string ContentType => "text/csv";
    public byte[] Export(QuizWithQuestionTextDTO quiz)
    {
        using (var writer = new StringWriter())
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteField("Quiz Name");
            csv.WriteField(quiz.Name);
            csv.NextRecord();

            for (int i = 0; i < quiz.Questions.Count; i++)
            {
                csv.WriteField($"Question {i + 1}");
                csv.WriteField(quiz.Questions[i].Text);
                csv.NextRecord();
            }

            return Encoding.UTF8.GetBytes(writer.ToString());
        }
    }
}