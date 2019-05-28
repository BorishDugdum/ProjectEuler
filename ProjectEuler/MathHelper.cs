using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public static class MathHelper
    {
        public static bool IsPrime(long num)
        {
            //now check to see if another number less than i is divisble
            for (int j = 2; j <= num; j++)
            {
                //not by itself
                if (num == j)
                {
                    //found a prime - we didn't break yet
                    return true;
                }

                if (num % j == 0)
                {
                    //found a divisor - not a prime
                    return false;
                }
            }

            throw new Exception("Error in CheckIfPrime method in MathHelper - Bad Logic");
        }

        public static int[] GetNonPrimeNumbers(int num)
        {
            //no dupes
            var primes = new HashSet<int>();
            for(int i = 0; i < num; i++)
            {
                //now check to see if another number less than i is divisble
                for(int j = 0; j < i; j++)
                {
                    //not by itself
                    if (i == j)
                        continue;

                    if(i % j == 0)
                    {
                        //not a prime
                        primes.Add(i);
                        break;
                    }
                }
            }
            return primes.ToList().OrderBy(a => a).ToArray();
        }

        public static long[] GetPrimeNumbers(int num)
        {
            //no dupes
            var primes = new HashSet<long>();
            for (int i = 2; i <= num; i++)
            {
                //now check to see if another number less than i is divisble
                for (int j = 2; j <= i; j++)
                {
                    //not by itself
                    if (i == j)
                    {
                        //found a prime - we didn't break yet
                        primes.Add(i);
                        continue;
                    }

                    if (i % j == 0)
                    {
                        //found a divisor - not a prime
                        break;
                    }
                }
            }
            return primes.ToList().OrderBy(a => a).ToArray();
        }

        public static long[] GetSumConsecutivePrimes(int numberOfConsecutivePrimes, int maxNumber)
        {
            var primes = GetPrimeNumbers(maxNumber);

            var primesResult = primes.Take(numberOfConsecutivePrimes);
            long result = 0;
            for (int i = 0; i < primes.Count(); i++)
            {
                var consecutivePrimes = primes.Skip(i).Take(numberOfConsecutivePrimes);
                var tempResult = consecutivePrimes.Sum();
                if (tempResult < maxNumber)
                {
                    result = tempResult;
                    primesResult = consecutivePrimes;
                }
                else
                    break;
            }
            Console.WriteLine($"Sum of consecutive primes is: {result}");
            return primesResult.OrderBy(a => a).ToArray();
        }

        /// <summary>
        /// Grabs all prime numbers under maxNumber and then finds a sum of prime numbers that is less than maxNumber
        /// </summary>
        /// <param name="maxNumber"></param>
        /// <returns></returns>
        public static long[] GetSumConsecutivePrimesBelowMax(int maxNumber)
        {
            //let's get the lowest factorial that sums to maxNumber or less...
            //Console.WriteLine("USING HACK FOR THIS");
            //if (maxNumber > 41)
            //    maxNumber = (int)Math.Round(maxNumber * .75);

            //first grab all primes under maxNumber
            long[] primes = GetPrimeNumbers(maxNumber);

            //to make this faster - let's do a binary check..
            var startIndex = 0;
            var primeCount = primes.Count();
            Console.WriteLine($"Found {primeCount} prime numbers");
            while(primeCount > maxNumber)
            {
                //let's cut out as much as possible on the checks - i'm impatient
                if (primes.Take(primeCount / 2).Sum() >= maxNumber)
                {
                    primeCount /= 2;
                    startIndex = primes.Count() - primeCount; //increase the startIndex
                }
                else
                    break; //this is as low as we're gonna get
            }

            var primesResult = primes as IEnumerable<long>;
            long result = 0;
            for (int i = startIndex; i < primes.Count(); i++)
            {
                var consecutivePrimes = primes.Take(primes.Count() - i);
                var tempResult = consecutivePrimes.Sum();
                if (tempResult < maxNumber)
                {
                    result = tempResult;
                    primesResult = consecutivePrimes;
                    break;
                }
            }
            Console.WriteLine($"Sum of consecutive primes is: {result}");

            primesResult = SumOfListMustBePrime(primesResult.OrderBy(a => a).ToArray());

            Console.WriteLine($"Sum of consecutive primes after prime sum check is: {primesResult.Sum()}");
            return primesResult.OrderBy(a => a).ToArray();
        }

        public static long[] SumOfListMustBePrime(long[] primeList)
        {
            while(!IsPrime(primeList.Sum()))
            {
                if (primeList.Count() > 0)
                    primeList = primeList.Take(primeList.Count() - 1).ToArray();
                else
                    break; //no prime sum!
            }
            return primeList;
        }
    }
}
