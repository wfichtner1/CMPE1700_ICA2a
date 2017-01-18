using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPE1700_ICA2a_WilliamFichtner
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = null;
            string repeat = null;
            byte value = 0;
            int bitPos = 0;
            byte bitState = 0;
            bool check = false;
            bool error = false;
            bool playAgain = false;
            do
            {
                playAgain = false;
                do
                {
                    check = false;
                    Console.Write("Enter an 8-bit binary value: ");
                    userInput = Console.ReadLine();
                    try
                    {
                        value = Convert.ToByte(userInput, 2);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid binary number was entered.");
                        check = true;
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Binary value is larger than 8-bit");
                        check = true;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Must enter a value.");
                        check = true;
                    }

                } while (check);

                do
                {
                    error = false;
                    Console.Write("Input the bit number to display: ");
                    try
                    {
                        bitPos = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Please enter a valid integer");
                        error = true;
                    }
                } while (error);

                error = false;

                while ((bitPos < 0) || (bitPos > 7))
                {
                    error = false;
                    Console.Write("Input the bit number to display (0-7): ");
                    do
                    {
                        try
                        {
                            bitPos = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Please enter a valid integer");
                            error = true;
                        }
                    } while (error);
                }

                bitState = (byte)((value & (1 << bitPos)) >> bitPos);

                Console.WriteLine("The bit is a {0}", bitState);

                Console.WriteLine("Run the program again? yes or no: ");
                repeat = Console.ReadLine().ToLower();
                if ((repeat == "yes") || (repeat == "y"))
                    playAgain = true;

            }while(playAgain);
            
        }
    }
}
