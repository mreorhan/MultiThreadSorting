using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MultiThreadSorting
{
    public class Sort
    {
        public static int[] Bubble(int[] myArray)
        {
            int i = 1, j, value;
            int arrayCount = myArray.Length;
            while (i < arrayCount)
            {
                j = arrayCount - 1;
                while (j >= 1)
                {
                    if (myArray[j - 1] > myArray[j])
                    {
                        value = myArray[j];
                        myArray[j] = myArray[j - 1];
                        myArray[j - 1] = value;
                    }
                    j--;
                }
                i++;
            }
            return myArray;
        }

        public static int[] SortThreeArray(int[] arr1, int[] arr2, int[] arr3)
        {
            int[] myArray = arr1.Concat(arr2).Concat(arr3).ToArray();
            int i = 1, j, value;
            int arrayCount = myArray.Length;
            while (i < arrayCount)
            {
                j = arrayCount - 1;
                while (j >= 1)
                {
                    if (myArray[j - 1] > myArray[j])
                    {
                        value = myArray[j];
                        myArray[j] = myArray[j - 1];
                        myArray[j - 1] = value;
                    }
                    j--;
                }
                i++;
            }
            return myArray;
        }
    }
}
