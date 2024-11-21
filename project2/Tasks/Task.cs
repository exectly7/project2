namespace project2
{
    public abstract class Task
    {
        public abstract string Name { get; set; }
        private Menu _menu;
        
        public abstract void Run();
    }
}