using Entities.Models;
using Shared.DTOs.Question;

namespace Contracts;
public interface IQuestionRepository
{
    Task<Question> GetQuestionById(int questionId);
    Task<IEnumerable<QuestionDTO>> GetQuestions(string searchTearm, CancellationToken cancellationToken);
    Task<bool> QuestionExists(int questionId, CancellationToken cancellationToken);
}
