using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    public abstract class IProblem
    {
        public void Solve()
        {
            Console.WriteLine(Problem());
            Console.WriteLine(Answer());
        }
        protected virtual string Problem() { return "\n\n*************************\n\nPROBLEM: NOT IMPLEMENTED\n\n*************************\n\n"; }
        protected virtual string Answer() { return "\n\n*************************\n\nANSWER: NOT IMPLEMENTED\n\n*************************\n\n"; }
    }
    
    public static class ClassHelper
    {
        //Instantiate a new Problem Object and Return it
        public static T FetchProblem<T>() where T : IProblem, new()
        {
            return new T();
        }

        public class Problem_50 : IProblem
        {
            protected override string Problem()
            {
                return @"PROBLEM:

The prime 41, can be written as the sum of six consecutive primes:

41 = 2 + 3 + 5 + 7 + 11 + 13
This is the longest sum of consecutive primes that adds to a prime below one-hundred.

The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.

Which prime, below one-million, can be written as the sum of the most consecutive primes?";
            }

            protected override string Answer()
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

        public class Problem_51 : IProblem
        {
            protected override string Problem()
            {
                return @"By replacing the 1st digit of the 2-digit number *3, it turns out that six of the nine possible values: 13, 23, 43, 53, 73, and 83, are all prime.

By replacing the 3rd and 4th digits of 56**3 with the same digit, this 5-digit number is the first example having seven primes among the ten generated numbers, yielding the family: 56003, 56113, 56333, 56443, 56663, 56773, and 56993. Consequently 56003, being the first member of this family, is the smallest prime with this property.

Find the smallest prime which, by replacing part of the number (not necessarily adjacent digits) with the same digit, is part of an eight prime value family.";
            }

            protected override string Answer()
            {
                var returnString = new StringBuilder();
                returnString.AppendLine();
                returnString.AppendLine("EXAMPLE 1:");

                //example logic
                var maxNum = 10;
                var prime_list = new HashSet<int>(); //using hashset to check for dupes - no dupes!!
                for(int i = 1; i < maxNum; i++)
                {
                    var num = Int32.Parse(i + "3");
                    if (MathHelper.IsPrime(num))
                        prime_list.Add(num);
                }
                
                returnString.AppendLine(MiscHelper.FromListToString(prime_list.ToList().OrderBy(a => a).ToList()));
                returnString.AppendLine($"Family of {prime_list.Count()} primes.");

                //second example
                prime_list = new HashSet<int>();
                for (int i = 0; i < maxNum; i++)
                {
                    var num = Int32.Parse($"56{i}{i}3");
                    if (MathHelper.IsPrime(num))
                        prime_list.Add(num);
                }
                returnString.AppendLine();
                returnString.AppendLine("EXAMPLE 2:");
                returnString.AppendLine(MiscHelper.FromListToString(prime_list.ToList().OrderBy(a => a).ToList()));
                returnString.AppendLine($"Family of {prime_list.Count()} primes.");
                returnString.AppendLine($"Smallest prime is:  {prime_list.OrderBy(a => a).First()}.");


                //answer
                prime_list = new HashSet<int>();
                var number_family = new char[8]; //going to loop through the indexes and replace

                //contain logic within our 8 digit number iterator
                var counter = 100;

                //we will break out of the loop when we break out with count OR when we've busted our limit
                while (prime_list.Count() == 0 && counter < 100000000) 
                {
                    for (int n = 0; n < maxNum; n++) //using n for number - i and j for index
                    {
                        if (!MathHelper.IsPrime(counter))
                            continue;
                        //outer loop to run through number_family indexes
                        for (int i = 0; i < number_family.Count(); i++)
                        {
                            if (i == 0)
                                continue;

                            //inner loop to run through number_family indexes
                            for (int j = 0; j < number_family.Count(); j++)
                            {
                                if (j == 0)
                                    continue;

                                if (i == j) //can't be same index
                                    continue;

                                //reset number_family
                                number_family = counter.ToString().ToCharArray();

                                //replace indexes with n
                                number_family[i] = n.ToString()[0];
                                number_family[j] = n.ToString()[0];
                                var num = Int32.Parse(new string(number_family));
                                if (MathHelper.IsPrime(num))
                                    prime_list.Add(num);
                            }
                        }
                        //before we go to next number - let's see if this prime family equals what we're searching for...
                        if (prime_list.Count() == 8) 
                            break; //found it!

                        //if(prime_list.Count() > 3)
                        //    Console.WriteLine($"Found Prime Count of {prime_list.Count()} for counter {counter}");
                        prime_list.Clear();
                    }

                    counter++;
                }

                
                returnString.AppendLine();
                returnString.AppendLine("ANSWER:");
                returnString.AppendLine(MiscHelper.FromListToString(prime_list.ToList().OrderBy(a => a).ToList()));
                returnString.AppendLine($"Family of {prime_list.Count()} primes.");
                returnString.AppendLine($"Smallest prime is:  {prime_list.OrderBy(a => a).First()}.");


                return returnString.ToString();
            }
        }
    }
}
