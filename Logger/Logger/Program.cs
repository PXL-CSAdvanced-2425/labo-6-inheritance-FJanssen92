using Logger.Models;
using System.Security.Cryptography.X509Certificates;

namespace Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Log log = new Log("log.txt");
            log.Write("Dit is een basis log.");

            ActivityLog activity = new ActivityLog("log.txt");
            activity.Write("Dit is een activity log");

            ErrorLog error = new ErrorLog("log.txt");
            error.Write("Dit is een error.");

            log.DisplayLog();
        }

       
    }
}
