using System.Text.RegularExpressions;

namespace RegexUseCase
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var input = @"Ab!1bc";
            var maxLength = 10U;
            var result = IsMatch(maxLength, input);
            Console.WriteLine($"input: {input}");
            Console.WriteLine($"maxLength: {maxLength}");
            Console.WriteLine($"result: {result}");
        }

        public static bool IsMatch(uint maxLength, string input)
        {
            var pattern = @"^(?=.{1," + maxLength + @"}$)(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!\x22#\$%&'\(\)\*\+,-\./:;<=>\?@\[\\\]\^_`{\|}~])([A-Za-z\d]|[!\x22#\$%&'\(\)\*\+,-\./:;<=>\?@\[\\\]\^_`{\|}~])*$";
            var regex = new Regex(pattern);
            return regex.IsMatch(input);
        }
    }
}