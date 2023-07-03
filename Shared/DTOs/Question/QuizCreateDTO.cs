namespace Shared.DTOs.Question;
public class QuizCreateDTO
{
    public string Name { get; set; }
    public List<QuestionDTO> NewQuestions { get; set; }
    public List<int> ExistingQuestionIds { get; set; }
}