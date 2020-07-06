using System;

namespace ExceptionHandlingDebugging
{
    // REMINDER: Commit after writing each method and testing.

    class Program
    {
        /* Methods needed
         * >> Main method
         * >> StartSequence method
         * >> Populate method
         * >> GetSum method
         * >> GetProduct method
         * >> GetQuotient method
         */
        
        static void Main(string[] args)
        {
            // Outputs all generic exceptions
            // Specific exceptions only defined once
            // NO GLOBAL VARIABLES
            
            try
            {
                StartSequence();
            }
            catch(Exception)
            {
                Console.WriteLine("Exception thrown!");
            }
        }

        static void StartSequence()
        {
            /* prompt the user to “Enter a number greater than zero”.
                Utilize the Convert.ToInt32() method to convert the user’s input to an integer.
                Instantiate a new integer array that is the size the user just inputted.

                Call the Populate method.
                    arguments: integer array

                Capture the sum by calling the GetSum method.
                    arguments: integer array

                Capture the product by calling the GetProduct method.
                    integer array and integer sum

                Capture the quotient by calling the GetQuotient method.
                    arguments: integer product

                To complete the method, output to the console the details of all these values. Make sure that your output 
                contains the same information presented in the example below. Pay attention to line breaks!

                EXCEPTIONS EXPECTED
                Format Exception
                    Output the message to the console
                Overflow Exception
                    output the message to the console
            */

            try
            {
                Console.WriteLine("Enter a number greater than zero.");

                int length = Convert.ToInt32(Console.ReadLine());
                int[] array = new int[length];

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
            /*  LOGIC
                >> Iterate through the array and prompt the user to enter a specific number. Example: “Please enter a number 1/6” (indicate to the user what number they are inputting)
                >> Utilize the Convert.ToInt32 method to convert the user’s input to an integer (Remember not to directly manipulate the user’s input. Store the response into a string first).
                >> Add the number just inputted into the array.
                >> Repeat this process until all numbers have been requested and the array is filled.
                >> Return the populated array
            */

            int num = 0;

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
            /*  LOGIC
                >> Declare an integer variable named sum
                >> Iterate through the array and populate the sum variable with the sum of all the numbers together.
                >> Add the capability to throw a custom exception if the sum is less than 20, with the message “Value of {sum} is too low”. (replace {sum} with the actual sum of the variable).
                >> Return the sum.
            */

            int sum = 0;

            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    sum += array[i];
                }

                if (sum < 20) throw new Exception();
                Console.WriteLine($"Sum is {sum}.");
            }
            catch(Exception)
            {
                Console.WriteLine($"Value of {sum} is too low.");
            }

            return sum;
        }

        static int GetProduct(int[] array, int sum)
        {
            /*  LOGIC
                >> Ask the user the select a random number between 1 and the length of the integer array.
                >> Declare a new variable named product
                >> Multiply sum by the random number index that the user selected from the array (example: array[randomNumber]). Set this value to the product variable.
                >> Return the product variable.

                EXCEPTIONS
                IndexOutOfRange
                >> Output the message to the console.
                >> Throw it back down the callstack so that it displays within Main
            */

            int product = 1;

            try
            {
                Console.WriteLine($"Enter a number between 1 and {array.Length}.");
                int index = Convert.ToInt32(Console.ReadLine()) - 1;

                product = sum * array[index];
                Console.WriteLine($"Product is {product}.");
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("Index out of range!");
                throw new IndexOutOfRangeException();
            }

            return product;
        }

        static decimal GetQuotient(int product)
        {
            /*  LOGIC
                >> Prompt the user to enter a number to divide the product by. Display the current product to the user during this prompt.
                >> Retrieve the input and divide the inputted number by the product.
                >> Utilize the decimal.Divide() method to divide the product by the dividend to receive the quotient.
                >> Return the quotient

                EXCEPTIONS
                Divide by Zero Exception
                >> Output the message to the console
                >> Do not throw it back to Main
                >> Return 0 if the catch gets called
            */

            decimal quotient = 0;

            try
            {
                Console.WriteLine($"Enter a number to divide the product {product} by.");
                int num = Convert.ToInt32(Console.ReadLine());

                quotient = decimal.Divide(num, product);
                Console.WriteLine($"Quotient is {quotient}.");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("ERROR: Divided by zero!");
                return 0;
            }

            return quotient;
        }

    }
}
