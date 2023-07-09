using Contracts;
using iTextSharp.text;
using Shared.DTOs.Quiz;
using System.ComponentModel.Composition;

namespace PDFExporter;

[Export(typeof(IExporter))]
public class PDFExporter : IExporter
{
    public string Format => "pdf";
    public string ContentType => "application/pdf";
    public byte[] Export(QuizWithQuestionTextDTO quiz)
    {
        using (var stream = new MemoryStream())
        {
            var document = new Document();
            var pdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(document, stream);
            document.Open();

            var header = new Paragraph(quiz.Name, new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD));
            header.Alignment = Element.ALIGN_CENTER;
            document.Add(header);

            var list = new List(List.ORDERED);
            foreach (var question in quiz.Questions)
            {
                list.Add(new ListItem(question.Text));
            }

            document.Add(list);
            document.Close();
            return stream.ToArray();
        }
    }
}