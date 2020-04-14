using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Addition
{
    class Program
    {
        static void Main(string[] args)
        {
            Test3();
            return;


            var limit = 100000;

            Parallel.For(1, limit, a =>
            {
                long total = a;
                total += a * Places(total);
                total += a * Places(total);
                if ((a * 3).ToString().EndsWith(a.ToString()))
                {
                    long numA = a;
                    Parallel.For(1, limit, b =>
                    {
                        if (a != b)
                        {
                            var numB = numA + b * Places(numA);
                            Parallel.For(1, limit, c =>
                            {
                                if (a != b && b != c && a != c)
                                {
                                    var numC = numB + c * Places(numB);
                                    if (numC * 3 == total)
                                    {
                                        Console.WriteLine($"Found one {c} {b} {a}");
                                    }
                                }
                            });
                        }
                    });
                }
            });
        }

        public static long Places(long num)
        {
            if (num < 10) return 10;
            if (num < 100) return 100;
            if (num < 1000) return 1000;
            if (num < 10000) return 10000;
            if (num < 100000) return 100000;
            if (num < 1000000) return 1000000;
            if (num < 10000000) return 10000000;
            if (num < 100000000) return 100000000;
            if (num < 1000000000) return 1000000000;
            if (num < 10000000000) return 10000000000;
            if (num < 100000000000) return 100000000000;
            throw new Exception("Can't figure out number length");
        }


        public static void Test()
        {
            var limit = 10000000000;
            for (int x = 5; x < limit; x = x + 5)
            {
                var total = x + x + x;
                var sX = x.ToString();
                var sTotal = total.ToString();
                for (int pos = 2; pos <= sX.Length - 1; pos++)
                {
                    var sKey = sX.Substring(pos, sX.Length - pos);
                    if (sTotal.EndsWith(sKey))
                    {
                        var targetTotal = decimal.Parse((sKey + sKey + sKey));
                        if (total == targetTotal)
                        {
                            Console.WriteLine(sX);
                            break;
                        }
                    }
                }
            }
        }

        public static void Test2()
        {
            var limit = 10000000000;
            for (int total = 102; total < limit; total = total + 3)
            {
                int x = total / 3;
                var sX = x.ToString();
                var sTotal = total.ToString();
                for (int pos = 2; pos <= sX.Length - 1; pos++)
                {
                    var sKey = sX.Substring(pos, sX.Length - pos);
                    if (sTotal.EndsWith(sKey))
                    {
                        var targetTotal = decimal.Parse((sKey + sKey + sKey));
                        if (total == targetTotal)
                        {
                            Console.WriteLine(sX);
                            break;
                        }
                    }
                }
            }
        }

        public static void Test3()
        {
            var start = DateTime.Now;
            var limit = 1000000;
            for (int red = 5; red < limit; red = red + 5)
            {
                var sRed = red.ToString();
                var sTotal = sRed + sRed + sRed;
                var total = long.Parse(sTotal);
                var blueGrayRed = (long)(total / 3); // This always divides evenly
                string sBlueGrayRed = blueGrayRed.ToString();
                if (sBlueGrayRed.EndsWith(sRed))
                {
                    Console.WriteLine($"{sBlueGrayRed} * 3 = {sTotal}");
                }
            }
            Console.WriteLine($"Completed in: {(DateTime.Now - start).TotalMilliseconds}ms");
        }
    }
}
