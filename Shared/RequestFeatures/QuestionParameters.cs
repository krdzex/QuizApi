namespace Shared.RequestFeatures;
public class QuestionParameters : RequestParameters
{
    public QuestionParameters() => OrderBy = "text";

    public string? SearchTerm { get; set; }
}