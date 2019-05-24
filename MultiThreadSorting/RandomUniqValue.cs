using System;
using System.Collections.Generic;
using System.Text;

namespace MultiThreadSorting
{
    public static class RandomUniqValue
    {
        private static List<int> NumberList = new List<int>();
        private static int value;
        public static int[] GetRandomUniqueValue(int arraySize)
        {
            while (NumberList.Count < arraySize)
            {
                Random rnd = new Random();
                value = rnd.Next(1, 91);
                if (!NumberList.Contains(value))
                    NumberList.Add(value);
            }
            return NumberList.ToArray();
        }
    }
}
