using PGR_FUND_LABS_CS.CourseProject.GeneratorsLab1;
using PGR_FUND_LABS_CS.CourseProject.BiDirQueueLab4;
using PGR_FUND_LABS_CS.CourseProject.Memo_Lab3_;
using System;

namespace PGR_FUND_LABS_CS.CourseProject
{
    class MainClass
    {
        static void Main()
        {
            Console.WriteLine("Main class");
            Console.WriteLine("Demo Lab1 Run; Generators");
            DemoLab1.Run();
            Console.WriteLine("Demo Lab3 Run; Memoization"); 
            CacheLab3.Run();
            Console.WriteLine("Demo Lab4 Run; BiDirectionalQueue");
            DemoLab4.Run();
        }
    }
}
