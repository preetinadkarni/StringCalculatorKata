﻿using System;

public class StringCalculator
{
    public int Add(string input)
    {
        if (CheckInputHasDelimiters(input))
        {
            string[] delimiters = GetDelimiters(input);
            string numbers = input.Substring(input.IndexOf("\n") + 1);
            
            return Sum(numbers, delimiters);
        }
        else
        {
            int i = 0;
            bool isInt = int.TryParse(input, out i);
            int hasMultipleNumbers = input.IndexOf(",");

            if (!isInt && hasMultipleNumbers < 0) // if string return a number
                return 0;
            if (isInt)
                return i;

            string[] delimiterChars = { ",", "\n" };
            return Sum(input,delimiterChars);
        }

        
    }

    private int Sum(string numbersString, string[] delimiters)
    {
        int sum = 0;
        int[] numbers = Array.ConvertAll(numbersString.Split(delimiters, StringSplitOptions.None), int.Parse);
        if (!CheckInputHasNoNegativeNumbers(numbers))
        {

            foreach (int n in numbers)
            {
                if (n < 1000)
                    sum = sum + n;
            }
        }
        return sum;
    }

    private bool CheckInputHasDelimiters(string input)
    {
        return input.IndexOf("//") == 0;
    }

    private bool CheckInputHasNoNegativeNumbers(int[] numbers)
    {
        int[] negativeNumbers = Array.FindAll(numbers, e => e < 0);

        if (negativeNumbers.Length > 0)
            throw new ArgumentException("Negatives not allowed: " + string.Join(", ", negativeNumbers));

        return false;
    }

    private string[] GetDelimiters(string input)
    {

        string[] delimiters = new string[5];
        int startIndex = 0;
        int endIndex = 0;
        int arrIndex = 0;

        if (input.IndexOf("[") > 0) //Multiple characters delimiters
        {
            while (endIndex < input.IndexOf("\n") - 1)
            {
                startIndex = input.IndexOf("[", endIndex);
                endIndex = input.IndexOf("]", startIndex);
                delimiters[arrIndex] = input.Substring(startIndex + 1, endIndex - startIndex - 1);
                arrIndex++;

            }
        }
        else //single character delimiter
        {
            startIndex = input.IndexOf("//");
            endIndex = input.IndexOf("\n");
            Console.WriteLine(startIndex + "  " + endIndex);
            delimiters[0] = input.Substring( startIndex + 2, 1);
        }
        return delimiters;
    }

    public void main(string[] args){ }
}

