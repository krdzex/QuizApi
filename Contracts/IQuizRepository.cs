using Shared.DTOs.Quiz;

namespace Contracts;
public interface IQuizRepository
{
    Task<IEnumerable<QuizNameDTO>> GetAllQuizNamesAsync(CancellationToken cancellationToken);
    Task<QuizDTO> GetQuizWithQuestionsAsync(int quizId, CancellationToken cancellationToken);
}
