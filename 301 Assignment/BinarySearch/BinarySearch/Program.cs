using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch {
    class Program {

        public static int[] listTest;
        public static int Key;

        public static void Main(string[] args) {

            ElapsedTimeTestIndividual(100);

            Console.ReadKey(); //Stops Window from closing
        }

        /// <summary>
        /// Searches the given array for the given key
        /// </summary>
        /// <param name="A">The array to be searched</param>
        /// <param name="Key">The key to be searched for</param>
        /// <returns>the position of the found key or a -1 if the key could not be found</returns>
        public static int BinarySearch(int[] A, int Key) {
            int basicOperations = 0;

            int l = 0;
            double r = A.Length - 1;

            //Prints the Key to be searched for.
            //Console.WriteLine("Key: " + Key);

            while (l <= r) {
                int m = Convert.ToInt32(Math.Floor((l + r) / 2));

                basicOperations++;
                if (Key == A[m]) {
                    return m; //Make "BasicOperations" to test for basic operations
                } else if (Key < A[m]) {
                    r = m - 1;
                } else {
                    l = m + 1;
                }
            }
            return -1; //Make "BasicOperations" to test for basic operations
        }

        /// <summary>
        /// Creates a desired length array with random intergers.
        /// </summary>
        /// <param name="length">length of the array you wish to have</param>
        /// <returns></returns>
        public static int[] randomArrayLength(int length) {
            Random rnd = new Random();

            int[] ListTest = new int[length];
            for (int i = 0; i < ListTest.Length; i++) {
                int randomNumber = rnd.Next(1, 100000);
                ListTest[i] = randomNumber;
            }
            Array.Sort(ListTest);
            return ListTest;
        }

        /// <summary>
        /// Generates a random length array (Between 1 and 20)
        /// and Adds Random Numbers between (0 - 50)
        /// Returns an ordered List
        /// </summary>
        /// <returns>ordered int[] array</returns>
        public static int[] randomArray() {
            Random rnd = new Random();
            Random rndLength = new Random();
            int arrayLength = rndLength.Next(3, 20);

            int[] ListTest = new int[arrayLength];
            for (int i = 0; i < arrayLength; i++) {
                int randomNumber = rnd.Next(1, 50);
                ListTest[i] = randomNumber;
            }
            Array.Sort(ListTest);
            return ListTest;
        }

        /// <summary>
        /// Test to see the total elapsed time of several binarySearches
        /// </summary>
        /// <param name="numberOfTests"></param>
        public static void elapsedTimeTestGroup(int numberOfTests) {
            Random rnd = new Random();
            long elapsedMS = 0;

            for (int i = 0; i < numberOfTests; i++) {
                listTest = randomArrayLength(1000000); //Change to test different array sizes.
                var watch = System.Diagnostics.Stopwatch.StartNew();
                Console.WriteLine(BinarySearch(listTest, rnd.Next(1, 100000)));
                watch.Stop();
                elapsedMS += watch.ElapsedMilliseconds;
            }
            elapsedMS = elapsedMS / numberOfTests;
            Console.WriteLine("Time elapsed " + elapsedMS + "ms");
        }

        /// <summary>
        /// Test to see the individual run times of each binary search.
        /// </summary>
        /// <param name="numberOFTests"></param>
        public static void ElapsedTimeTestIndividual(int numberOFTests) {
            Random rnd = new Random();

            for (int i = 0; i < numberOFTests; i++) {
                listTest = randomArrayLength(500); //Change to test different array sizes.
                var watch = System.Diagnostics.Stopwatch.StartNew();
                Console.WriteLine(BinarySearch(listTest, rnd.Next(1, 100000)));
                watch.Stop();
                Console.WriteLine("Time elapsed " + watch.ElapsedMilliseconds + "ms");               
            }
        }

        /// <summary>
        /// Tests to see the average amount of basic operations
        /// </summary>
        /// <param name="numberOfTests"></param>
        public static void basicOperationsTest(int numberOfTests) {
            Random rnd = new Random();
            int basic = 0;

            for (int i = 0; i < numberOfTests; i++) {
                listTest = randomArrayLength(3); //Change to test different array sizes.
                basic += BinarySearch(listTest, rnd.Next(1, 1000000));
            }
            basic = basic / numberOfTests;
            Console.WriteLine(basic);
        }

        /// <summary>
        /// Tests the Functional Correctness of the Binary Search
        /// </summary>
        public static void functionalTest() {
            int[] list = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14};
            int Key = 14;
            string listString = "";

            foreach (int number in list) {
                listString += " " + "[" + number + "]";
            }
            Console.WriteLine("The Array is " + listString);
            Console.WriteLine("The Key is " + Key);
            Console.WriteLine("Result " + BinarySearch(list, Key));
        }
    }
}
