using System.Globalization;
using System.Text.RegularExpressions;

namespace project2
{
    public class Review
    {
        private const string Day = "[0-9][0-9]?";
        private const string Month = @"(?<= )[A-Za-z]+\.*";
        private const string Year = "[0-9]{4}";
        private string _name;
        public DateTime Date {get;set;}
        private string _location;
        public int Rating { get; private set; }
        private string _text;
        private string _images;
        private string _csvLine;
        
        public Review(string[] parsedLine)
        {
            _name = parsedLine[0];
            _location = parsedLine[1];
            Date = ParseDate(parsedLine[2]);
            Rating = ParsedRating(parsedLine[3]);
            _text = parsedLine[4];
            _images = parsedLine[5];
        }

        private int ParsedRating(string rating)
        {
            return rating == "N/A" ? 0 : int.Parse(rating);
        }

        private DateTime ParseDate(string date)
        {
            string day = GetMatch(Day, date).Length == 2
                ? GetMatch(Day, date)
                : "0" + GetMatch(Day, date);
            string month = GetMatch(Month, date) switch
            {
                "January" or "Jan." => "01",
                "February" or "Feb." => "02",
                "March" or "Mar." => "03",
                "April" or "Apr." => "04",
                "May" => "05",
                "June" or "Jun." => "06",
                "July" or "Jul." => "07",
                "August" or "Aug." => "08",
                "September" or "Sept." => "09",
                "October" or "Oct." => "10",
                "November" or "Nov." => "11",
                "December" or "Dec." => "12",
                _ =>  ""
            };
            string year = GetMatch(Year, date);
            string dateString = $"{day}/{month}/{year}";
            return DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.CurrentCulture);
        }
        private static string GetMatch(string pattern, string input)
        {
            Match match = Regex.Match(input, pattern);
            return match.Success ? match.Value : string.Empty;
        }
        
        public override string ToString()
        {
            return $"{_name}\n{_location}\n{Rating}\n{Date}\n{_text}\n{_images}\n";
        }
    }
}