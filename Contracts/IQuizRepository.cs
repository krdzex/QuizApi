using Entities.Models;
using Shared.DTOs.Quiz;

namespace Contracts;
public interface IQuizRepository
{
    Task<IEnumerable<QuizNameDTO>> GetAllQuizNamesAsync(CancellationToken cancellationToken);
    Task<QuizWithQuestionsDTO> GetQuizWithQuestionsAsync(int quizId, CancellationToken cancellationToken);
    Task<Quiz> GetQuizById(int quizId);
    Task<bool> QuizExists(int quizId);
    void Create(Quiz quiz);
    void Delete(Quiz quiz);
}
