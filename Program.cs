using System.Diagnostics;

namespace SortingAlgorithms
{


    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = { 90, 3, 2, 56, 32, 34, 65, 68, 76, 1, 0, 100, 8 };
            int[] arr2 = { 90, 3, 2, 56, 32, 34, 65, 68, 76, 1, 0, 100, 8 };
            int[] arr3 = { 90, 3, 2, 56, 32, 34, 65, 68, 76, 1, 0, 100, 8 };
            int[] arrSorted1 = { 0, 1, 2, 3, 8, 32, 34, 56, 65, 68, 76, 90, 100 };
            int[] arrSorted2 = { 0, 1, 2, 3, 8, 32, 34, 56, 65, 68, 76, 90, 100 };
            int[] arrSorted3 = { 0, 1, 2, 3, 8, 32, 34, 56, 65, 68, 76, 90, 100 };


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            BubbleSort(arr1);
            stopwatch.Stop();
            PrintArray(arr1);
            Console.WriteLine("Elapsed time for BubbleSort: " + stopwatch.Elapsed);
            Console.WriteLine();

            stopwatch.Restart();
            SelectionSort(arr2);
            stopwatch.Stop();
            PrintArray(arr2);
            Console.WriteLine("Elapsed time for SelectionSort: " + stopwatch.Elapsed);
            Console.WriteLine();

            stopwatch.Restart();
            InsertionSort(arr3);
            stopwatch.Stop();
            PrintArray(arr3);
            Console.WriteLine("Elapsed time for InsertionSort: " + stopwatch.Elapsed);
            Console.WriteLine();

            Console.WriteLine("Please select a sorting algorithm");
            Console.WriteLine("1: Bubble Sort");
            Console.WriteLine("2: Selection Sort");
            Console.WriteLine("3: Insertion Sort");

            string? userSelection = Console.ReadLine();

            Student student1 = new Student("Melissa", 4.0);
            Student student2 = new Student("Rich", 3.0);
            Student student3 = new Student("Adam", 3.8);

            Student[] students = { student1, student2, student3 };


            switch (userSelection)
            {
                case "1":
                    BubbleSort(students);
                    // Call bubble sort method
                    break;
                case "2":

                    // Call selection sort method
                    break;
                case "3":
                    // Call insertion sort method
                    break;
                default:
                    break;
            }
            PrintArray(students);

            int[] mergeArray = { 0, 1, 2, 3, 8, 32, 34, 56, 65, 68, 76, 90, 100 };
            MergeSort(mergeArray);
        }



        // Responsible for splitting the array up and eventually merging it together
        // Calls itself recursively
        public static void MergeSort(int[] arr)
        {
            if (arr.Length <= 1) return; // example of an early return

            int mid = arr.Length / 2;
            int[] leftSubArray = new int[mid];
            int[] rightSubArray = new int[arr.Length - mid];

            for(int i = 0; i < mid; i ++)
            {
                leftSubArray[i] = arr[i];
            }

            for(int i = mid; i < arr.Length; i++)
            {
                rightSubArray[i- mid] = arr[i];
            }

            MergeSort(leftSubArray);
            MergeSort(rightSubArray);
        }

        public static void PrintArray(Student[] arr)
        {

            foreach (var item in arr)

            {

                Console.Write($"{item.name}: {item.gpa}");

            }

            Console.WriteLine();

        }


        public static int BubbleSort(int[] arrToSort) //good if low on system memory 
        {
            int totalOuterIterations = 0;
            int temp;
            // Overall O(n^2) runtime
            // Big Omega - O(n^2)

            for (int i = 0; i < arrToSort.Length; i++)
            {
                ++totalOuterIterations;
                int swaps = 0;
                for (int j = 0; j < arrToSort.Length - 1 - i; j++) //O(n)
                {
                    //swap places if j is greater than j + 1
                    if (arrToSort[j] > arrToSort[j + 1]) //change to < to reverse array
                    {
                        swaps++;
                        temp = arrToSort[j];
                        arrToSort[j] = arrToSort[j + 1];
                        arrToSort[j + 1] = temp;
                    }
                }
                if (swaps == 0) break;
            }
            return totalOuterIterations;
        }

        public static void SelectionSort(int[] arrToSort)
        {
            // minIndex keeps track of smallest index in each iteration
            // temp stores the value being swapped
            int minIndex, temp;

            for (int i = 0; i < arrToSort.Length - 1; i++) // iterate through unsorted elements O(n)
            {
                minIndex = i; // set minIndex to current index

                for (int j = i + 1; j < arrToSort.Length; j++) // iterate through the remaining elements O(n)
                {
                    // update minIndex if the current element is smaller than the element at minIndex
                    if (arrToSort[j] < arrToSort[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // swap the elements if minIndex is not the current index
                if (minIndex != i)
                {
                    temp = arrToSort[i];
                    arrToSort[i] = arrToSort[minIndex];
                    arrToSort[minIndex] = temp;
                }
            }

        }

        public static void InsertionSort(int[] arrToSort)
        {

            for (int i = 1; i < arrToSort.Length; i++)
            {
                int temp = arrToSort[i];  // store element as it might be overwritten
                int priorIndex = i - 1;  //start comparing with element before the current element

                // if prior element is greater than stored element
                // and we have not reached the end of the array
                while (priorIndex >= 0 && arrToSort[priorIndex] > temp)
                {
                    arrToSort[priorIndex + 1] = arrToSort[priorIndex];
                    priorIndex--;
                }

                arrToSort[priorIndex + 1] = temp; // sets prior index to saved variable
            }
        }

        public static void BubbleSort(Student[] arrToSort)
        {

            Student temp;


            for (int i = 0; i < arrToSort.Length; i++)
            {
                for (int j = 0; j < arrToSort.Length - 1 - i; j++)

                {
                    // we need to swap
                    if (arrToSort[j].gpa > arrToSort[j + 1].gpa)
                    {

                        temp = arrToSort[j];
                        arrToSort[j] = arrToSort[j + 1];
                        arrToSort[j + 1] = temp;
                    }
                }

            }

        }
        public static void PrintArray(int[] arr)
        {

            foreach (var item in arr)

            {

                Console.Write($"{item}");

            }

            Console.WriteLine();

        }


    }
}