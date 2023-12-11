
using Tools;

class Program
{
    static void Main(string[] args)
    {
        var lines = FileReaderClass.ReadFromFile("d1pc.txt");
        var listOfDigits = lines.Select(l => GetAllDigits(l)).ToArray();
        var listOfNum = listOfDigits.Select(l => int.Parse(l)).ToArray();
        Console.WriteLine(listOfNum.Sum());
    }

    public static string GetAllDigits(string word)
    {
        var digits = "0123456789";
        var wordDigits = new List<string>()
            { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        var result = "";
        for (int i = 0; i < word.Length; i++)
        {
            var subString = word.Substring(i);
            var firstChar = subString[0];
            if (digits.Contains(firstChar))
            {
                result += firstChar;
            }
            else
            {
                foreach (var wd in wordDigits)
                {
                    var length = wd.Length;
                    if (subString.Length < length) continue;
                    var subWord = subString.Substring(0, length);
                    if (wd == subWord)
                    {
                        var indexOfWord = wordDigits.IndexOf(wd).ToString();
                        result += indexOfWord;
                    }
                }
            }

        }

        return result[0].ToString() + result[result.Length - 1].ToString();
    }
}