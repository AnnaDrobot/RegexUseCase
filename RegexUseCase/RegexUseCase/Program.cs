using System.Text.RegularExpressions;

namespace RegexUseCase
{
    public static class Program
    {
        public static void Main(string[] args) { }

        public static bool IsMatch(uint maxLength, string input)
        {
            var pattern = @"^(?=.{1," + maxLength + @"}$)(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!\x22#\$%&'\(\)\*\+,-\./:;<=>\?@\[\\\]\^_`{\|}~])([A-Za-z\d]|[!\x22#\$%&'\(\)\*\+,-\./:;<=>\?@\[\\\]\^_`{\|}~])*$";
            var regex = new Regex(pattern);
            return regex.IsMatch(input);
        }
    }
}