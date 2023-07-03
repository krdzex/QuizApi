using Entities.Models;

namespace Contracts;
public interface IQuestionRepository
{
    Task<Question> GetQuestionById(int questionId);
}
