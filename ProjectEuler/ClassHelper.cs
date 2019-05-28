using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public static class ClassHelper
    {
        public static class Problem_50
        {
            public static void Solve()
            {
                Console.WriteLine(Problem());
                Console.WriteLine(Answer());
            }

            private static string Problem()
            {
                return @"PROBLEM:

The prime 41, can be written as the sum of six consecutive primes:

41 = 2 + 3 + 5 + 7 + 11 + 13
This is the longest sum of consecutive primes that adds to a prime below one-hundred.

The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.

Which prime, below one-million, can be written as the sum of the most consecutive primes?";
            }

            private static string Answer()
            {
                //example
                Console.WriteLine();
                Console.WriteLine("Working...");
                var example = MathHelper.GetPrimeNumbers(41);
                var returnString = new StringBuilder();
                returnString.AppendLine();
                returnString.AppendLine("EXAMPLE:");

                foreach (var e in example)
                {
                    returnString.Append($"{e}, ");
                }
                if (returnString.Length > 2)
                    returnString.Length -= 2;

                returnString.AppendLine();
                returnString.AppendLine();

                //first question
                var first_question = MathHelper.GetSumConsecutivePrimes(21, 954);

                returnString.AppendLine("FIRST ANSWER:");
                foreach (var e in first_question)
                {
                    returnString.Append($"{e}, ");
                }
                if (returnString.Length > 2)
                    returnString.Length -= 2;


                returnString.AppendLine();
                returnString.AppendLine();

                //second question
                var second_question = MathHelper.GetSumConsecutivePrimesBelowMax(1000000);

                returnString.AppendLine("SECOND ANSWER:");
                foreach (var e in second_question)
                {
                    returnString.Append($"{e}, ");
                }
                if (returnString.Length > 2)
                    returnString.Length -= 2;

                returnString.AppendLine();
                returnString.AppendLine($"Prime sum under 1 million: {second_question.Sum()}");


                return returnString.ToString();
            }
        }
    }
}
