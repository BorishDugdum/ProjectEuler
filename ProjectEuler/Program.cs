using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            //the purpose of this is to make my way through the first 60 problems from
            //https://projecteuler.net/archives

            ClassHelper.FetchProblem<ClassHelper.Problem_51>().Solve();

            Console.ReadKey();
        }
    }
}
