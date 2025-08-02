using System;
using System.Text;

namespace ExcelSheet
{
    public class Program
    {
        private static readonly char[] alphabet = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K',
            'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'];

        public static void TitleToNumber()
        {
            Console.WriteLine("Input a column title");

            char[] columnTItleArray = Console.ReadLine().ToArray();
            int columnNumber = 0;

            for (int i = 0; i < columnTItleArray.Length; i++)
            {
                int alphabetIndex = alphabet.Select((s, id) => new { s, id }).Where(x => x.s.Equals(columnTItleArray[i])).Select(x => x.id + 1).Single();
                if (i < columnTItleArray.Length - 1)
                {
                    columnNumber += (26 * alphabetIndex);
                }
                else
                {

                    columnNumber += alphabet.Select((s, id) => new { s, id }).Where(x => x.s.Equals(columnTItleArray[i])).Select(x => x.id + 1).Single();
                }
         
            }

            Console.WriteLine(columnNumber);
            Console.WriteLine("Press X to close app");
        }

        public static void Main(string[] args)
        {
            ConsoleKeyInfo keyinfo;
            do
            {
                TitleToNumber();
                keyinfo = Console.ReadKey();
            }
            while (keyinfo.Key != ConsoleKey.X);
        }
    }
}