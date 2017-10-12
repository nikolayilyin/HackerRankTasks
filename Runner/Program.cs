using System;
using System.Linq;
using Tasks;
using Tasks.Algorithms.GraphTheory;
using XUnitTestProject.Algorithms.GraphTheory;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            "started".Wl();

            try
            {

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
