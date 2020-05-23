using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sieve of Eratosthenes

            var inputLines = GetInput();

            int[] min = new int[inputLines.Count];
            int[] max = new int[inputLines.Count];
            
            int index = 0;
            foreach(var l in inputLines)
            {
                var s = l.Trim();
                string[] myLine = s.Split(' ');
                min[index] = int.Parse(myLine[0]);
                if (myLine.Length > 1)
                {
                    max[index] = int.Parse(myLine[1]);
                }
                else
                {
                    max[index] = min[index];
                }
                index++;
            }


            var primeRanges = new List<List<int>>();

            for (int i = 0; i < min.Length; i++)
            {                
                var myRange = GenerateRange(min[i], max[i]);
                var cleanRange = CleanRange(myRange);
                var primeNumbers = GetPrimeNumbers(cleanRange, max[i]);
                primeRanges.Add(primeNumbers);
            }

            foreach(var r in primeRanges)
            {
                PrintRangeVertical(r);
                Console.WriteLine();
            }

            //int min = 500; int max = 50000;


            //Console.WriteLine("Clean Range: " + PrintRange(cleanRange));
            //Console.WriteLine("\n\n\n\nPrime Range: " + PrintRange(primeNumbers));
            Console.ReadLine();
        }

        static List<string> GetInput()
        {
            var s = "dummy";
            var inputList = new List<string>();
            while (true)
            {
                s = Console.ReadLine();
                
                if (string.IsNullOrWhiteSpace(s))
                    break;

                inputList.Add(s);
            }
            return inputList;
        }

        static List<int> GetPrimeNumbers(List<int> range, int max)
        {

            if (max == 0 || max == 1)
            {
                return new List<int>();
            }

            var maxValue = (int)Math.Ceiling(Math.Sqrt(max));
            
            //Find MaxIndex
            int maxIndex;
            int n = 0;
            while (true)
            {
                if (range[n] >= maxValue)
                {
                    maxIndex = n;
                    break;
                }
                n++;
            }
            //Console.WriteLine(maxIndex + " MaxValue:" + maxValue);

            //Creating seiveRange for finding out more Composites
            var seiveRange = CleanRange(GenerateRange(0, maxValue));

            //Initializing blank composite Range
            var compositeRange = new List<int>();


            //Performing seive Algo to generate Composites
            for (int i = 0; i < seiveRange.Count; i++)
            {
                for(int j=0; j<seiveRange.Count; j++)
                {
                    var x = seiveRange[i] * seiveRange[j];
                    if (!compositeRange.Contains(x))
                    {
                        compositeRange.Add(x);
                    }
                }
            }

            //Initializing blank primeRange
            var primeRange = new List<int>();

            //Remove Composites from primeRange
            foreach (var x in range)
            {
                if (compositeRange.Contains(x))
                    continue;

                primeRange.Add(x);
            }

           // Console.WriteLine("seiveRange: "+PrintRange(seiveRange));
           // Console.WriteLine("CompositeRange: " + PrintRange(compositeRange));
            return primeRange;
        }

        static List<int> GenerateRange(int min, int max)
        {
            var myRange = new List<int>();
            for (int i = min; i <= max; i++)
            {
                myRange.Add(i);
            }

            return myRange;
        }

        static List<int> CleanRange(List<int> range)
        {
            var newRange = new List<int>();

            for (int i = 0; i < range.Count; i++)
            {
                if (range[i] == 0)
                    continue;
                else if (range[i] == 1)
                    continue;
                else if(range[i] == 2)
                {
                    newRange.Add(range[i]);
                }
                else if (range[i] == 3)
                {
                    newRange.Add(range[i]);
                }
                else if (range[i] == 5)
                {
                    newRange.Add(range[i]);
                }
                else if (range[i] % 2 == 0)               
                    continue;
                else if (range[i] % 3 == 0)
                    continue;
                else if (range[i] % 5 == 0)
                    continue;
                else
                {
                    newRange.Add(range[i]);
                }
            }
            return newRange;
        }

        static List<int> FullCleanRange(List<int> range)
        {
            var newRange = new List<int>();

            for (int i = 0; i < range.Count; i++)
            {
                if (range[i] == 0)
                    continue;
                else if (range[i] == 1)
                    continue;                
                else if (range[i] % 2 == 0)
                    continue;
                else if (range[i] % 3 == 0)
                    continue;
                else if (range[i] % 5 == 0)
                    continue;
                else
                {
                    newRange.Add(range[i]);
                }
            }
            return newRange;
        }

        static string PrintRange(List<int> range)
        {
            string s = "[";
            foreach (var x in range)
            {
                s = s +" "+ x;
            }
            s = s + " ]";
            return s;
        }
        static void PrintRangeVertical(List<int> range)
        {
            foreach (var x in range)
            {
                Console.WriteLine(x);
            }
        }



    }
}
