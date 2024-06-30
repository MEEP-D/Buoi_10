using System;
using System.Text.RegularExpressions;

public class ValidateData
{
    public double InputNumber(string prompt)
    {
        double number;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (double.TryParse(input, out number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }

    public bool InputString(string input)
    {
        // Regular expression to check if the string contains no digits
        string pattern = @"^\D*$";
        Regex regex = new Regex(pattern);

        return regex.IsMatch(input);
    }
}
