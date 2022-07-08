namespace RomanToInteger
{
    internal class Program
    {
        static Dictionary<char, int> romanDictionary = new Dictionary<char, int>();
        static readonly HashSet<char> specialSymbols = new HashSet<char>() { 'I', 'X', 'C' };

        static int ConvertRomanToInteger(string s)
        {
            int result = 0;
            int compareSum = 0;
            int firstBinaryLength = 0;
            int secondBinaryLength = 0;

            for (int i = 1; i <= s.Length; i++)
            {
                if (i == s.Length)
                {
                    result += romanDictionary[s[i - 1]];
                    break;
                }

                if (specialSymbols.Contains(s[i - 1]) && !s[i - 1].Equals(s[i]))
                {
                    firstBinaryLength = Convert.ToString(romanDictionary[s[i - 1]], 2).Length;
                    secondBinaryLength = Convert.ToString(romanDictionary[s[i]], 2).Length;
                    compareSum = secondBinaryLength - firstBinaryLength;
                    switch (compareSum <= 3 && compareSum > 0)
                    {
                        case true:
                            result += romanDictionary[s[i]] - romanDictionary[s[i - 1]];
                            i++;
                            continue;
                        case false:
                            result += romanDictionary[s[i - 1]];
                            break;
                    }
                }
                else
                    result += romanDictionary[s[i - 1]];
            }
            return result;
        }

        static void Main(string[] args)
        {
            romanDictionary.Add('I', 1);
            romanDictionary.Add('V', 5);
            romanDictionary.Add('X', 10);
            romanDictionary.Add('L', 50);
            romanDictionary.Add('C', 100);
            romanDictionary.Add('D', 500);
            romanDictionary.Add('M', 1000);

            string romanString = "DCXXI";

            int number = ConvertRomanToInteger(romanString);

            Console.WriteLine($"Roman string - {romanString}. Integer number - {number}");
            Console.ReadKey();
        }
    }
}
