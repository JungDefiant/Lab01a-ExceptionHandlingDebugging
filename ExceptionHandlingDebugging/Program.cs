using System;

namespace ExceptionHandlingDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            // Runs StartSequence and catches all generic exceptions
            
            try
            {
                StartSequence();
            }
            catch(Exception)
            {
                Console.WriteLine("Exception thrown!");
            }
            finally
            {
                Console.WriteLine("Program completed!");
            }
        }

        static void StartSequence()
        {
            try
            {
                // Prompts user to enter a number greater than zero
                Console.WriteLine("Enter a number greater than zero.");

                // Takes user input and creates a new array with the specified number
                int length = Convert.ToInt32(Console.ReadLine());
                int[] array = new int[length];

                // Populates array, then generates a sum, a product, and a quotient
                array = Populate(array);
                int sum = GetSum(array);
                int product = GetProduct(array, sum);
                decimal quotient = GetQuotient(product);
            }
            catch(FormatException)
            {
                Console.WriteLine("Wrong format! Format exception.");
            }
            catch(OverflowException)
            {
                Console.WriteLine("Number entered is too large! Overflow exception.");
            }
            
        }

        static int[] Populate(int[] array)
        {
            int num = 0;

            // Iterates through array, asking for number input each time, then populates array with the input
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Enter each number {i + 1}/{array.Length}.");
                num = Convert.ToInt32(Console.ReadLine());
                array[i] = num;
            }
            
            return array;
        }

        static int GetSum(int[] array)
        {
            int sum = 0;

            try
            {
                // Iterates through array and adds each number to sum
                for (int i = 0; i < array.Length; i++)
                {
                    sum += array[i];
                }

                // If sum is less than 20, throws generic exception
                if (sum < 20) throw new Exception();
                Console.WriteLine($"Sum is {sum}.");
            }
            catch(Exception)
            {
                // Message sent to console when sum is less than 20
                Console.WriteLine($"Value of {sum} is too low.");
            }

            return sum;
        }

        static int GetProduct(int[] array, int sum)
        {
            int product = 1;

            try
            {
                // Asks for number between 1 and length of array
                Console.WriteLine($"Enter a number between 1 and {array.Length}.");
                int index = Convert.ToInt32(Console.ReadLine()) - 1;

                // Multiplies sum by number at index chosen
                product = sum * array[index];
                Console.WriteLine($"Product is {product}.");
            }
            catch(IndexOutOfRangeException)
            {
                // Message sent to console when index specified is out of range
                Console.WriteLine("Index out of range!");
                throw new IndexOutOfRangeException();
            }

            return product;
        }

        static decimal GetQuotient(int product)
        {
            decimal quotient = 0;

            try
            {
                // Asks for number to divide product by
                Console.WriteLine($"Enter a number to divide the product {product} by.");
                int num = Convert.ToInt32(Console.ReadLine());

                // Divides product by given number and returns it as quotient
                quotient = decimal.Divide(product, num);
                Console.WriteLine($"Quotient is {quotient}.");
            }
            catch (DivideByZeroException)
            {
                // Message sent when user attempts to divide by zero
                Console.WriteLine("ERROR: Divided by zero!");
                return 0;
            }

            return quotient;
        }

    }
}
