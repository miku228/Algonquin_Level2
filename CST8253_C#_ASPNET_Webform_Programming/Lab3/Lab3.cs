using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Lab3
    {
        static int[] intArray = {17,  166,  288,  324,  531,  792,  946,  157,  276,  441, 533, 355, 228, 879, 100, 421, 23, 490, 259, 227,
                                 216, 317, 161, 4, 352, 463, 420, 513, 194, 299, 25, 32, 11, 943, 748, 336, 973, 483, 897, 396,
                                 10, 42, 334, 744, 945, 97, 47, 835, 269, 480, 651, 725, 953, 677, 112, 265, 28, 358, 119, 784,
                                 220, 62, 216, 364, 256, 117, 867, 968, 749, 586, 371, 221, 437, 374, 575, 669, 354, 678, 314, 450,
                                 808, 182, 138, 360, 585, 970, 787, 3, 889, 418, 191, 36, 193, 629, 295, 840, 339, 181, 230, 150 };


        static void Main(string[] args)
        {
            //Add your code here to complete the steps given in the section 4 of the lab document

            // a. console original Array
            Console.Write("The initial unsorted array is :\n");
            PrintArray(intArray);

            // b. copy original array to new array
            int[] newIntArray = new int[intArray.Length];
            intArray.CopyTo(newIntArray, 0);
            //Array.Copy(intArray, 0, newIntArray, 0, intArray.Length);

            // c. Call BubbleSort
            int numOfSwaps = BubbleSort(newIntArray);
            Console.Write("\nBubble sort made {0} swaps to sort this array\n", numOfSwaps);
            //Console.Write(numOfSwaps);


            // d. console sorted array
            Console.Write("\nThe sorted array is :\n");
            PrintArray(newIntArray);

            while (true)
            {
                // e. prompt the user to enter an integer
                Console.Write("\nEnter an Integer to search: ");
                int inputNum = Convert.ToInt32(Console.ReadLine());

                // f. call the method LinearSearch to search the entered integer in the original unsorted array intArray
                int numOfComparison = 0;
                int[] linerSearchResults = LinearSearch(intArray, inputNum, out numOfComparison);
                if (linerSearchResults[0] == -1)
                {
                    Console.Write("\nLinear search made {0} comparison to find out that {1} is not in this unsorted array \n", linerSearchResults[1], inputNum);
                }
                else
                {
                    Console.Write("\nLinear search made {0} comparison to find out that {1} is at the index {2} in this unsorted array \n", linerSearchResults[1], inputNum, linerSearchResults[0]);
                }

                // g. call the method BinarySearch to search the entered integer in the sorted array
                int[] binarySearchResults = BinarySearch(newIntArray, inputNum, out numOfComparison);
                if (binarySearchResults[0] == -1)
                {
                    Console.Write("\nBinary search made {0} comparison to find out that {1} is not in this sorted array \n", binarySearchResults[1], inputNum);
                }
                else
                {
                    Console.Write("\nBinary search made {0} comparison to find out that {1} is at the index {2} in this sorted array \n", binarySearchResults[1], inputNum, binarySearchResults[0]);
                }

                // h. ask the user whether he/she wants to search another integer.
                Console.Write("\nDo you want search another integer?(Y/N)? ");
                string repeat = Console.ReadLine().ToLower();
                if (repeat == "n")
                {
                    Console.Write("\nBye");
                    break;
                }

            }
        

        }

        //This method returns the index of a given niddle (an int) in the haystack (an int array)
        //by using linear search. It also returns the value of the number of comparison used to 
        //find the given niddle through the reference parameter numOfComparison.
        static int[] LinearSearch(int[] haystack, int niddle, out int numOfComparison)
        {
            numOfComparison = 0;
            int niddleIndex = -1;
            int[] results = new int[2];

            //Add your code here searching for the niddle in the haystack.
            //niddleIndex = Array.IndexOf(haystack, niddle);
            int linerSearch(int[] arr, int nid)
            {
                for (int i = 0; i < haystack.Length; i++)
                {
        
                    if (arr[i] == nid)
                    {
                        return i;
                    }

                }
                return -1;
            }

            niddleIndex = linerSearch(haystack, niddle);

            if(niddleIndex != -1)
            {
                numOfComparison = niddleIndex + 1;
            }
            else
            {
                numOfComparison = haystack.Length;
            }
            results[0] = niddleIndex;
            results[1] = numOfComparison;

            //return niddleIndex;
            return results;
        }


        static int BubbleSort(int[] arr)
        {
            int numOfSwaps = 0;

            //Add your code here to implement the bubble sort to sort the integer array arr.
            int temp = 0;
            // repeat arr.length-1 times
            for(int l = 0; l<arr.Length-1; l++)
            {
                // check the value then sort one by one
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        // count up when swaps is happened
                        numOfSwaps += 1;
                        // swap items
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                    }
                }
            }
            
            return numOfSwaps;
        }

        //This method returns the index of a given niddle (an int) in the haystack (an int array)
        //by using binary search. It also returns the value of the number of comparison used to 
        //find the given niddle through the reference parameter numOfComparison.
        // reference:https://www.coursera.org/lecture/principles-of-computing-2/binary-search-zsXCG

        static int[] BinarySearch(int[] haystack, int niddle, out int numOfComparison)
        {
            numOfComparison = 0;
            int niddleIndex = -1;
            int count = 0;
            int[] results = new int[2];

            //Add your code here to implement the binary search to find the niddle in the haystack.
            int binarySearch(int[] arr, int nid, int l, int r)
            {
                if(l > r)
                {
                    // if the key is not in the array
                    return -1;
                }
                else {
                    int mid = l + (r - l) / 2;
                    count += 1;

                    if (arr[mid] == nid) return mid;

                    // a niddle is smaller than checking value, then check left
                    if (arr[mid] > nid)
                    {
                        return binarySearch(arr, nid, l, mid - 1);
                    }
                    //else if (arr[mid] < nid)
                    //{
                        // a niddle is bigger than checking value, then check right
                        return binarySearch(arr, nid, mid + 1, r);
                    //}
                }
                

                
                
            }

            niddleIndex = binarySearch(haystack, niddle, 0, haystack.Length - 1);
            numOfComparison = count;

            results[0] = niddleIndex;
            results[1] = numOfComparison;

            return results;
        }

        //This method has been fully implemented. Just use it to print an integer array to the console.
        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != arr.Length - 1)
                {
                    Console.Write("{0}, ", arr[i]);
                }
                else
                {
                    Console.Write("{0} ", arr[i]);
                }
            }
            Console.WriteLine();
        }

    }
}
