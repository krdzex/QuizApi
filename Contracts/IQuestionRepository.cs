using Entities.Models;
using Shared.DTOs.Question;
using Shared.RequestFeatures;

namespace Contracts;
public interface IQuestionRepository
{
    Task<Question> GetQuestionById(int questionId);
    Task<PagedList<QuestionDTO>> GetQuestions(QuestionParameters questionParameters, CancellationToken cancellationToken);
    Task<bool> QuestionExists(int questionId, CancellationToken cancellationToken);
}
