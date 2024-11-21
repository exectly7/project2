namespace project2
{
    public class Reviews
    {
        public Review[] AllReviews { get; set; }
        public readonly int MaxRating;
        public Dictionary<int, int> ReviewPerYear { get; set; }
        public int Amount { get; set; }
        public Dictionary<int, int> Rating { get; set; }
        
        
        
        public Reviews(Review[] reviews)
        {
            AllReviews = reviews;
            MaxRating = 0;
            ReviewPerYear = new Dictionary<int, int>();
            Rating = new Dictionary<int, int>();
            foreach (Review review in reviews)
            {
                Amount = review.Rating == 0 ? Amount : ++Amount;
                if (review.Rating != 0)
                {
                    if (Rating.ContainsKey(review.Rating))
                    {
                        Rating[review.Rating]++;
                    }
                    else
                    {
                        Rating.Add(review.Rating, 1);
                    }
                }
                if (ReviewPerYear.ContainsKey(review.Date.Year))
                {
                    ReviewPerYear[review.Date.Year]++;
                }
                else
                {
                    ReviewPerYear.Add(review.Date.Year, 1);
                }
                MaxRating = Math.Max(MaxRating, review.Rating);
            }
            
        }
    }
}