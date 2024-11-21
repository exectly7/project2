namespace project2
{
    public class BestRatingTask : Task
    {
        public override string Name { get; set; } = "Вывести лучшие отзывы за 20-21 год";
        private Menu _menu;
        private Reviews _reviews;

        public BestRatingTask(Menu menu, Reviews reviews)
        {
            _menu = menu;
            _reviews = reviews;
        }

        public override void Run()
        {
            Console.Clear();
            foreach (Review review in _reviews.AllReviews)
            {
                if (review.Rating == _reviews.MaxRating && (review.Date.Year == 2020 || review.Date.Year == 2021))
                {
                    _menu.MessageRow(review.ToString());
                }
            }
        }
    }
}