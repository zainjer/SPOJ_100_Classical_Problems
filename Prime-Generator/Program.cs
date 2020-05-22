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

            int min = 500; int max = 50000;

            var myRange = GenerateRange(min, max);
            var cleanRange = CleanRange(myRange);
            var primeNumbers = GetPrimeNumbers(cleanRange, max);

            Console.WriteLine("Clean Range: " + PrintRange(cleanRange));
            Console.WriteLine("\n\n\n\nPrime Range: " + PrintRange(primeNumbers));
            Console.ReadLine();
        }

        static List<int> GetPrimeNumbers(List<int> range, int max)
        {
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
            Console.WriteLine(maxIndex + " MaxValue:" + maxValue);

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


    }
}
