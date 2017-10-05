using System;
using System.Linq;
using Tasks.Algorithms.GraphTheory;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            "started".Wl();

            try
            {
                var jttm = new JourneyToTheMoon();
                jttm.ConsoleReadInput();
                jttm.WaysCount.ToString().Wl();
            }
            catch (Exception ex)
            {
                "Exception catched.".Wl();
                "{0}".Wl(ex.ToStr());
            }
            finally
            {
                "finished. press any key.".Wl();
                Console.ReadKey();
            }
        }
    }
}
