namespace Shared.RequestFeatures;
public class QuizParameters : RequestParameters
{
    public QuizParameters() => OrderBy = "name";

    public string? SearchTerm { get; set; }
}