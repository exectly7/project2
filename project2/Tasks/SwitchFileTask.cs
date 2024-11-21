namespace project2
{
    public class SwitchFileTask : Task
    {
        public override string Name { get; set; } = "Поменять файл";
        private Menu _menu;

        public SwitchFileTask(Menu menu)
        {
            _menu = menu;
        }

        public override void Run()
        {
            FileHandler file = new(SetPath());
            try
            {
                string[] data = file.Import();
                CsvProcessing csv = new(data);
                Reviews reviews = new(csv.Parse());
                _menu.Reviews = reviews;
                _menu.Message("Файл успешно импортирован!");
            }
            catch (Exception e)
            {
                _menu.MessageRow(e.Message);
            }
        }

        private string SetPath()
        {
            _menu.Message("Введите путь к файлу: \n");
            string path = Console.ReadLine() ?? string.Empty;
            while (!File.Exists(path))
            {
                _menu.Message("Файл не найден!");
                path = Console.ReadLine() ?? string.Empty;
            }

            return path;
        }
    }
}