using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toilet_Seat
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var currentPosition = input[0];
            var counter = 0;

            var policy1 = 'U';
            var policy2 = 'D';

            #region Policy 1
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] != currentPosition)
                {
                    counter++;

                    if (input[i] != policy1)
                        counter++;
                }
                else
                {
                    if (input[i] != policy1)
                        counter++;
                }

                currentPosition = policy1;
            }
            Console.WriteLine(counter);
            counter = 0;
            #endregion

            #region Policy 2
            currentPosition = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] != currentPosition)
                {
                    counter++;

                    if (input[i] != policy2)
                        counter++;
                }
                else
                {
                    if (input[i] != policy2)
                        counter++;
                }

                currentPosition = policy2;
            }
            Console.WriteLine(counter);
            counter = 0;
            #endregion

            #region Policy 3
            currentPosition = input[0];
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] != currentPosition)
                    counter++;

                currentPosition = input[i];
            }
            Console.WriteLine(counter);
            #endregion
        }
    }
}
