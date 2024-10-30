namespace Comprehend
{
    public record ReviewResult(bool IsToxic, string Sentiment = null!);
}
