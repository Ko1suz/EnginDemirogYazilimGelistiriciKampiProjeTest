namespace Business.CrossCuttingConcernsTest
{
    public class DataBaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Dosya Loglandı");
        }
    }
}
