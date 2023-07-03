namespace Entities.Models;
public class Quiz : EntityBase
{
    public string Name { get; set; }
    public ICollection<QuizQuestion> QuizQuestions { get; set; }
}