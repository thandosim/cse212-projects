using System; 
using System.Linq; 
using System.Collections.Generic;
using System.Diagnostics;
public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        
        // Thought process
        // Given a number n, its multiples can be found by multiplying the number with integers starting with 1
        // thus to make a function that finds the multiples of n, we must write a function that multiplies n by intergers i from 1
        // up to the given ending point. 
        // 1. initialize an array of length length
        // 2. start a for loop that iterates from i =1 to i = length
        // 3. in the loop, multiply n by i
        // 4. append the result to the array
        // 5. return the resulting array 

        List<double> multiples = new();
        for (double i = 0; i < length; ++i)
        {
            multiples.Add(number * (i+1));
        }
        return multiples.ToArray(); // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // thought process
        // to rotate the list once, i need to create a new list in which all the indices except the ;ast one are shifted one step right. 
        // the ;ast one must be changed to 0. 
        // thia can be repeated as many times as the amount
        // 1. i will do this by creating a new empty list
        // 2. taking the last number from the old list and making ti the first number in the new list
        // 3. adding the rest of the numbers from the old list to the new
        // 4. replacing the old list with the new list

        int i = new();
        while (i < amount) 
        {
            List<int> newList = [];
            int lastIndex = data.Count() - 1;
            Debug.WriteLine("lastIndex " + lastIndex);
            Debug.WriteLine(data[lastIndex]);
            newList.Add(data[lastIndex]);

            for (int j=0; j < lastIndex; j++)
            {
                newList.Add(data[j]);
            }
            // foreach (int number in newList)
            // {
            //     Debug.WriteLine(number);
            // }
            data.Clear();
            data.AddRange(newList);

            Debug.WriteLine("at 0 " + data[0]);
            i++;
        }
    }
}
