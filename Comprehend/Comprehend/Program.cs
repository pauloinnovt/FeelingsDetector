namespace Comprehend
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            string text1 = "You're so stupid, no one likes you.";
            string text2 = "You're such a good guy, thanks for exist.";

            var validate = new ReviewValidate(Amazon.RegionEndpoint.USEast1);

            var result = await validate.Validate(text1);
            var result2 = await validate.Validate(text2);

            Console.WriteLine("Is toxic: " + result.IsToxic);
            Console.WriteLine("Sentiment: " + result.Sentiment);
            Console.WriteLine("\n");
            Console.WriteLine("Is toxic: " + result2.IsToxic);
            Console.WriteLine("Sentiment: " + result2.Sentiment);
        }
    }
}