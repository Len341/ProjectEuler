using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMaxRouteOfTriangle
{
    class Program
    {
        protected string triangle { get; set; } = "75 95 64 17 47 82 18 35 87 10 20 04 82 47 65 19 01 23 75 03 34 88 02 77 73 07 63 67 "+
            "99 65 04 28 06 16 70 92 41 41 26 56 83 40 80 70 33 41 48 72 33 47 32 37 16 94 29 " +
            "53 71 44 65 25 43 91 52 97 51 14 70 11 33 28 77 73 17 78 39 68 17 57 91 71 52 38 17 14 91 43 58 50 27 " +
            "29 48 63 66 04 68 89 53 67 30 73 16 69 87 40 31 04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";

        static void Main(string[] args)
        {
            List<List<int>> triangle = new Program().createTriangle();

            int MaxPath = new Program().getMaxPath(triangle);
            Console.WriteLine(MaxPath.ToString());
            Console.ReadKey();
        }

        protected int getMaxPath(List<List<int>> triangle)
        {
            int previousMaxIndex = 0;
            int currentMaxIndex = 0;
            int maxSum = 0;
            bool firstRow = true;

            foreach(List<int> numbers in triangle)
            {
                var nums = numbers;
                if (firstRow)
                {
                    maxSum += numbers[0];
                    firstRow = false;
                }
                else
                {
                    int max = (new List<int>() { numbers[previousMaxIndex], numbers[previousMaxIndex + 1] }).Max();
                    maxSum += max;
                    currentMaxIndex = numbers.IndexOf(max);

                    int totalSkipped = 0;
                    while ((previousMaxIndex - currentMaxIndex) > 0)
                    {
                        //invalid
                        int initialSkip = nums.IndexOf(max);
                        nums = nums.Skip(nums.IndexOf(max)+1).ToList();
                        totalSkipped += nums.IndexOf(max)+1;
                        currentMaxIndex = totalSkipped + initialSkip;
                    }
                    previousMaxIndex = currentMaxIndex;
                }
            }
            return maxSum;
        }

        protected List<List<int>> createTriangle()
        {
            List<List<int>> nums = new List<List<int>>();
            var numbers = triangle.Split(' ');
            int i;
            for (int x = 1; x <= numbers.Count();)
            {
                List<int> nextRow = new List<int>();
                for (i = 0; i < x; i++)
                {
                    nextRow.Add(Convert.ToInt32(numbers[i]));
                }
                numbers = numbers.Skip(x).ToArray();
                nums.Add(nextRow);
                x++;
            }
            return nums;
        }
    }
}
