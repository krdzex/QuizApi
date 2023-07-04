using Entities.Models;
using Shared.DTOs.Quiz;

namespace Contracts;
public interface IQuizRepository
{
    Task<IEnumerable<QuizNameDTO>> GetAllQuizNamesAsync(CancellationToken cancellationToken);
    Task<QuizWithQuestionsDTO> GetQuizWithQuestionsAsync(int quizId, CancellationToken cancellationToken);
    Task<Quiz> GetQuizById(int quizId);
    Task<bool> QuizExists(int quizId, CancellationToken cancellation);
    Task<bool> RemoveQuestionFromQuiz(int quizId, int questionId, CancellationToken cancellationToken);
    Task<QuizWithQuestionTextDTO> GetQuizForExport(int quizId, CancellationToken cancellationToken);
    void Create(Quiz quiz);
    void Delete(Quiz quiz);
}
