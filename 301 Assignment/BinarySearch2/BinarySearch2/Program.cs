using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch2 {
    class Program {

        public static int[] listTest;
        public static int Key = 14;

        public static void Main(string[] args) {

            testFunction(50000);

            //Stops the CMD from closing.
            Console.ReadKey();
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
            double r = listTest.Length - 1;

            //Prints the Key to be searched for.
            //Console.WriteLine("Key: " + Key);

            while (l <= r) {
                int m = Convert.ToInt32(Math.Floor((l + r) / 2));

                basicOperations++;
                if (Key == A[m]) {
                    return basicOperations;
                } else if (Key < A[m]) {
                    r = m - 1;
                } else {
                    l = m + 1;
                }
            }
            return basicOperations;
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
                int randomNumber = rnd.Next(1, 50);
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
        /// This runes the BinarySearch function the amount of times specified
        /// and prints out the results;
        /// </summary>
        /// <param name="numberOfTests">Number of tests you wish to perform</param>
        public static void testFunction(int numberOfTests) {
            Random rnd = new Random();
            string arraytext = "";

            int basic = 0;

            long elapsedMS = 0;

            for (int i = 0; i < numberOfTests; i++) {
                listTest = randomArray();


                foreach (int number in listTest) {
                    arraytext += number + " ";
                }
                //Prints the array being searched.
                //Console.WriteLine("Array: " + arraytext);

                var watch = System.Diagnostics.Stopwatch.StartNew();

                //Runs the Binary Search
                //Console.WriteLine(BinarySearch(listTest, rnd.Next(1, 50)));

                basic += BinarySearch(listTest, rnd.Next(1, 50));

                watch.Stop();
                elapsedMS += watch.ElapsedMilliseconds;


            }

            basic = basic / numberOfTests;

            Console.WriteLine("Basic Operations (average)");
            //Console.WriteLine("Time elapsed " + elapsedMS + "ms");
        }
    }
}