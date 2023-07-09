using Shared.DTOs.Quiz;

namespace Contracts;
public interface IExporter
{
    string Format { get; }
    byte[] Export(QuizWithQuestionTextDTO quiz);
    string ContentType { get; }
}