using Shared.DTOs.Question;

namespace Shared.DTOs.Quiz;
public class QuizCreateDTO
{
    public string Name { get; set; }
    public List<QuestionDTO> NewQuestions { get; set; }
    public List<int> ExistingQuestionIds { get; set; }
}