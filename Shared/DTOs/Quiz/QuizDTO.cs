using Shared.DTOs.Question;

namespace Shared.DTOs.Quiz;
public class QuizDTO
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<QuestionDTO> Questions { get; set; }
}