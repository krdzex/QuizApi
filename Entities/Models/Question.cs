namespace Entities.Models;
public class Question : EntityBase
{
    public string Text { get; set; }
    public string Answer { get; set; }
    public ICollection<QuizQuestion> QuizQuestions { get; set; }
}
