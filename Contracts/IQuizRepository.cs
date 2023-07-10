using Entities.Models;
using Shared.DTOs.Quiz;
using Shared.RequestFeatures;

namespace Contracts;
public interface IQuizRepository
{
    Task<PagedList<QuizNameDTO>> GetAllQuizNamesAsync(QuizParameters quizParameters, CancellationToken cancellationToken);
    Task<QuizWithQuestionsDTO> GetQuizWithQuestionsAsync(int quizId, CancellationToken cancellationToken);
    Task<Quiz> GetQuizById(int quizId);
    QuizQuestion GetQuizQuestion(Quiz quiz, int questionId);
    Task<QuizWithQuestionTextDTO> GetQuizForExport(int quizId, CancellationToken cancellationToken);
    Task Create(Quiz quiz, CancellationToken cancellationToken);
    void Delete(Quiz quiz);
    bool QuestionExistInQuiz(Quiz quiz, int questionId);
    Task<Quiz> GetQuizByIdWithQuestions(int quizId, CancellationToken cancellationToken);
}
