using System.Security;

namespace project2
{
    public class FileHandler
    {
        private string _path;

        public FileHandler(string path)
        {
            _path = path;
        }
        
        public string[] Import()
        {
            try
            {
                string[] data = File.ReadAllLines(_path);
                return data;
            }
            catch (Exception e) when (e is SecurityException or IOException or PathTooLongException
                                          or DirectoryNotFoundException or UnauthorizedAccessException
                                          or NotSupportedException or FileNotFoundException)
            {
                string messageToUser = e switch
                {
                    PathTooLongException => "Путь к файлу слишком длинный",
                    FileNotFoundException or DirectoryNotFoundException => "Файл не найден",
                    SecurityException or UnauthorizedAccessException => "Нет прав доступа к файлу",
                    NotSupportedException => "Файл не поддерживается",
                    IOException => "Произошла ошибка при чтении файла",
                    _ => e.Message
                };
                
                IOException error = new(messageToUser, e);
                throw error; 
                
            }
        }
    }
    
}