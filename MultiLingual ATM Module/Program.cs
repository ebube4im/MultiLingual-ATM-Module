namespace MultiLingual_ATM_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ATMMachine aTMMachine = new ATMMachine();
            aTMMachine.AtmBegin();
        }


    }

    public class Global
    {
        public static int PreferredLanguage { get; set; }
        public static string  TargetLanguageCode { get; set; }
    }
}