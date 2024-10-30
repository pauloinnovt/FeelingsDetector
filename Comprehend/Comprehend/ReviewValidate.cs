using Amazon;
using Amazon.Comprehend;
using Amazon.Comprehend.Model;

namespace Comprehend
{
    public class ReviewValidate(RegionEndpoint region)
    {
        private readonly AmazonComprehendClient client = new(region);

        public async Task<ReviewResult> Validate(string text)
        {
            ArgumentNullException.ThrowIfNull(text);

            var request = new DetectToxicContentRequest()
            {
                TextSegments = [new() { Text = text }],
                LanguageCode = "en"
            };

            var result = await client.DetectToxicContentAsync(request);

            return new ReviewResult(result.ResultList[0].Toxicity > 0.8, await GetSentiment(text));
        }

        private async Task<string> GetSentiment(string text)
        {
            ArgumentNullException.ThrowIfNull(text);

            var request = new DetectSentimentRequest()
            {
                Text = text,
                LanguageCode = "en"
            };

            var result = await client.DetectSentimentAsync(request);

            return result?.Sentiment;
        }
    }
}
