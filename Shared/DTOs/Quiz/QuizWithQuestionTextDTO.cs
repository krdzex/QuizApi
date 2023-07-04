using Shared.DTOs.Question;

namespace Shared.DTOs.Quiz;
public class QuizWithQuestionTextDTO
{
    public string Name { get; set; }

    public List<QuestionTextDTO> Questions { get; set; }
}