using System.Diagnostics;

namespace project2
{
    public class Menu
    {
        private Task[] _tasks;
        private bool _isRunning;
        private int _currentTask;
        private bool _firstRun = true;
        public Reviews Reviews { get; set; }
        
        private const ConsoleColor Background = ConsoleColor.Black;
        private const ConsoleColor Foreground = ConsoleColor.Magenta;

        public Menu()
        {
            _tasks = [new SwitchFileTask(this)];
        }

        private Menu(Task[] tasks, bool firstRun)
        {
            _tasks = tasks;
            _firstRun = firstRun;
        }
        
        public void RunMenu()
        {
            _isRunning = true;
            ShowMenu();
            while (_isRunning)
            {
                if (_firstRun)
                {
                    _firstRun = false;
                    _tasks[0].Run();
                    _tasks = [new SwitchFileTask(this), new BestRatingTask(this, Reviews), new StatsTask(this, Reviews)];
                }
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        _currentTask = _currentTask == 0 ? _currentTask : --_currentTask;
                        ShowMenu();
                        break;
                    case ConsoleKey.DownArrow:
                        _currentTask = _currentTask ==  _tasks.Length - 1 ? _currentTask : ++_currentTask;
                        ShowMenu();
                        break;
                    case ConsoleKey.Enter:
                        _tasks[_currentTask].Run();
                        break;
                    default:
                        Guide();
                        break;
                }
            }
        }

        public void Message(string message)
        {
            SetNormalColor();
            Console.Clear();
            Console.WriteLine(message);
        }
        
        public void MessageRow(string message)
        {
            SetNormalColor();
            Console.WriteLine(message);
        }
        
        /*
        public void Message(string[] message)
        {
            SetNormalColor();
            Console.Clear();
            foreach (string s in message)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine(message);
        } */

        /*public bool AskMessage(string message)
        {
            SetNormalColor();
            Console.Clear();
            Console.WriteLine(message);
            Menu continueMenu = new Menu([new ContinueTask(continueMenu), new BreakTask()], false);
            continueMenu.RunMenu();
        }*/

        private void Guide()
        {
            SetNormalColor();
            Console.Clear();
            Console.WriteLine("Навигация в меню происходит при помощи стрелочек и кнопки enter." +
                              "\nНажмите любую кнопку для продолжения: ");
            Console.ReadKey();
            ShowMenu();
        }
            
        private void ShowMenu()
        {
            SetNormalColor();
            Console.Clear();
            
            for (int i = 0; i < _tasks.Length; i++)
            {
                if (i == _currentTask)
                {
                    SetInvertedColor();
                }
                else
                {
                    SetNormalColor();
                }
                Console.WriteLine(_tasks[i].Name);
            }
            SetNormalColor();
        }

        private static void SetNormalColor()
        {
            Console.ForegroundColor = Foreground;
            Console.BackgroundColor = Background;
        }
        
        private static void SetInvertedColor()
        {
            Console.ForegroundColor = Background;
            Console.BackgroundColor = Foreground;
        }
    }
}