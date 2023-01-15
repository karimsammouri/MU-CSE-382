/* 1) Was there any substantive difference in computing time between them?
 * Answer: Running the methods five times each, the List was the fastest,
 * taking 0.23s. The HashSet was second and took double the time at 0.47s.
 * The SortedSet took the most time at 5.29s, which is 23 times more than
 * the List.
 */

/* 2) Was there a substantive time difference in any of the data structures?
 * Answer: Running the searches 1,000 times for each data structure, 
 * the List took the most time at 5.43s. The SortedSet was faster at 0.02s. The 
 * HashSet was by far the fastest at 0.0002s.
 */

/* 3 How many 3 letter words are there?
 * Answer: 972
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace cs {
    public class IO {
        public static void IOMain(string[] args) {
            using (StreamWriter output = new StreamWriter("sorted.txt"))
            using (StreamReader input = new StreamReader("items.csv")) {
                while (!input.EndOfStream) {
                    string line = input.ReadLine();
                    string[] toks = line.Split(',');
                    int[] values = new int[toks.Length];
                    for (int i = 0; i < toks.Length; i++)
                        values[i] = Int32.Parse(toks[i]);
                    Array.Sort(values);
                    foreach (int value in values) {
                        output.Write(value + " ");
                    }
                    output.WriteLine();
                }
            }
            /*
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            List<string> testList;
            testList = ReadWordsList("words.txt");
            testList = ReadWordsList("words.txt");
            testList = ReadWordsList("words.txt");
            testList = ReadWordsList("words.txt");
            testList = ReadWordsList("words.txt");
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);

            stopWatch.Restart();
            stopWatch.Start();
            SortedSet<string> testSortedSet;
            testSortedSet = ReadWordsSortedSet("words.txt");
            testSortedSet = ReadWordsSortedSet("words.txt");
            testSortedSet = ReadWordsSortedSet("words.txt");
            testSortedSet = ReadWordsSortedSet("words.txt");
            testSortedSet = ReadWordsSortedSet("words.txt");
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);

            stopWatch.Restart();
            stopWatch.Start();
            HashSet<string> testHashSet;
            testHashSet = ReadWordsHashSet("words.txt");
            testHashSet = ReadWordsHashSet("words.txt");
            testHashSet = ReadWordsHashSet("words.txt");
            testHashSet = ReadWordsHashSet("words.txt");
            testHashSet = ReadWordsHashSet("words.txt");
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);

            string[] words = { "COMPUTERS", "ZYMOTIC", "AARDVARK", "WORD", "DATABASIC" };

            stopWatch.Restart();
            stopWatch.Start();
            for (int i = 0; i < 1000; i++) {
                for (int j = 0; j < words.Length; j++)
                {
                    testList.Contains(words[j]);
                }
            }
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);

            stopWatch.Restart();
            stopWatch.Start();
            for (int i = 0; i < 1000; i++) {
                for (int j = 0; j < words.Length; j++) {
                    testSortedSet.Contains(words[j]);
                }
            }
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);

            stopWatch.Restart();
            stopWatch.Start();
            for (int i = 0; i < 1000; i++) {
                for (int j = 0; j < words.Length; j++) {
                    testHashSet.Contains(words[j]);
                }
            }
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);

            List<string> L = ReadWordsList("words.txt");
            int result = 0;
            foreach (string word in L) {
                if (word.Length == 3) {
                    result++;
                }
            }
            Console.WriteLine(result);
            */
        }
        // This method is complete and correct.
        public static List<string> ReadWordsList(string filename) {
            List <string> result = new List<string>();
            using (StreamReader input = new StreamReader(filename)) {
                while (!input.EndOfStream)
                {
                    string line = input.ReadLine();
                    result.Add(line);
                }
            }
            return result;
        }
        // This method is complete and correct.
        public static SortedSet<string> ReadWordsSortedSet(string filename) {
            SortedSet<string> result = new SortedSet<string>();
            using (StreamReader input = new StreamReader(filename))
            {
                while (!input.EndOfStream)
                {
                    string line = input.ReadLine();
                    result.Add(line);
                }
            }
            return result;
        }
        // This method is complete and correct.
        public static HashSet<string> ReadWordsHashSet(string filename) {
            HashSet<string> result = new HashSet<string>();
            using (StreamReader input = new StreamReader(filename))
            {
                while (!input.EndOfStream)
                {
                    string line = input.ReadLine();
                    result.Add(line);
                }
            }
            return result;
        }
    }
}
