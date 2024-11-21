using System.Buffers;
using System.Data.Common;
using System.Text;
using System.Text.RegularExpressions;

namespace project2
{
    public class CsvProcessing
    {
        private string[] _data;

        public CsvProcessing(string[] data)
        {
            _data = data;
        }
        
        public Review[] Parse()
        {
            List<Review> reviews = [];
            foreach (string row in _data[1..])
            {
                reviews.Add(new Review(CsvLineParse(row)));
            }
            return reviews.ToArray();
        }

        private string[] CsvLineParse(string input)
        {
            string[] result = new string[6];
            for (int i = 0; i < 6; i++)
            {
                if (input[0] == '"')
                {
                    result[i] = input[(input.IndexOf('"') + 1)..(input[1..].IndexOf('"') + 1)];
                    if (input[1..].IndexOf('"') + 1 != input.Length - 1)
                    {
                        Console.WriteLine(input[1..].IndexOf('"'));
                        Console.WriteLine(input.Length);
                        Console.WriteLine(input);
                        input = input[(input[1..].IndexOf('"') + 3)..];
                    }
                }
                else if (input.IndexOf(',') != -1)
                {
                    result[i] = input[..(input[1..].IndexOf(',') + 1)];
                    input = input[(input.IndexOf(',') + 1)..];
                }
                else
                {
                    result[i] = input;
                }
            }

            return result;
        }
    }
}