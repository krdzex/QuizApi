using Shared.DTOs.Quiz;

namespace Contracts;
public interface IExporter
{
    string Format { get; }
    string ExportAsync(QuizWithQuestionTextDTO quiz);
}