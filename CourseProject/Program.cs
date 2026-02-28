

using PGR_FUND_LABS_CS.CourseProject.AsyncArray_Lab5_;
using PGR_FUND_LABS_CS.CourseProject.BiDirQueueLab4;
using PGR_FUND_LABS_CS.CourseProject.GeneratorsLab1;
using PGR_FUND_LABS_CS.CourseProject.Memo_Lab3_;
using System;

namespace PGR_FUND_LABS_CS.CourseProject
{
    class MainClass
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Select lab:");
                Console.WriteLine("1 - Lab1");
                Console.WriteLine("3 - Lab3");
                Console.WriteLine("4 - Lab4");
                Console.WriteLine("0 - Exit");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DemoLab1.Run();
                        break;
                    case "3":
                        CacheLab3.Run();
                        break;
                    case "4":
                        Lab4Demo.Run();
                        break;
                    case "5":
                        _ = AsyncArrayDemo.Run();
                        break;
                    case "0":
                        return;
                }

                Console.WriteLine();
            }
        }
    }
}
