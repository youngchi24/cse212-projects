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

        /// Plan for MultiplesOf ///
        // The function receives: number: The starting number.
        // length: How many multiples to generate.

        // Steps//
        // 1. Create an array with length spaces.
        // 2. Use a for loop to go through the array.
        // 3. Multiply the starting number by the current position plus one.
        // 4. Store the result in the array.
        // 5. Return the completed array.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
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

        // Plan //
        // I can solve this using GetRange(), RemoveRange(), and InsertRange().
        
        // steps //
        // First find the position where the last amount elements begin.
        // Use GetRange() to copy those last elements into a temporary list.
        // Use RemoveRange() to remove those elements from the original list.
        // Use InsertRange() to insert the copied elements at the beginning.
        // The original list is now rotated to the right.

        // 1. Calculate the starting index of the elements to move.
        // 2. Use GetRange() to copy the last elements into a temporary list.
        // 3. Use RemoveRange() to remove those elements from the original list.
        // 4. Use InsertRange() to put the copied elements at the beginning.
        // 5. The list is now rotated to the right.

        int startIndex = data.Count - amount;

        List<int> lastElements = data.GetRange(startIndex, amount);

        data.RemoveRange(startIndex, amount);

        data.InsertRange(0, lastElements);

        }
    }
