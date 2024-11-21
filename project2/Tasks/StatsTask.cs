namespace project2
{
    public class StatsTask : Task
    {
        public override string Name { get; set; } = "Вывести статистику по отзывам";
        private Menu _menu;
        private Reviews _reviews;

        public StatsTask(Menu menu, Reviews reviews)
        {
            _menu = menu;
            _reviews = reviews;
        }

        public override void Run()
        {
            foreach (KeyValuePair<int,int> keyValuePair in _reviews.ReviewPerYear)
            {
                _menu.MessageRow($"{keyValuePair.Key}: {keyValuePair.Value}");
            }
            
            for (int i = 1; i < 6; i++)
            {
                _menu.MessageRow($"{i} {((double)_reviews.Rating[i] / _reviews.Amount ).ToString("P")}");
            }
        }
    }
}