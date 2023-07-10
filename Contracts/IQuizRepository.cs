using Entities.Models;
using Shared.DTOs.Quiz;
using Shared.RequestFeatures;

namespace Contracts;
public interface IQuizRepository
{
    Task<PagedList<QuizNameDTO>> GetAllQuizNamesAsync(QuizParameters quizParameters, CancellationToken cancellationToken);
    Task<QuizWithQuestionsDTO> GetQuizWithQuestionsAsync(int quizId, CancellationToken cancellationToken);
    Task<Quiz> GetQuizById(int quizId);
    Task<bool> QuizExists(int quizId, CancellationToken cancellation);
    Task<bool> RemoveQuestionFromQuiz(int quizId, int questionId, CancellationToken cancellationToken);
    Task<QuizWithQuestionTextDTO> GetQuizForExport(int quizId, CancellationToken cancellationToken);
    Task Create(Quiz quiz, CancellationToken cancellationToken);
    void Delete(Quiz quiz);
}
