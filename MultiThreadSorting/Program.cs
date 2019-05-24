using System;
using System.Linq;
using System.Threading;

namespace MultiThreadSorting
{
    class Program
    {

        static void Main(string[] args)
        {
            Mutex m = new Mutex();
            int[] myArray, sortedArrayP1 = null, sortedArrayP2 = null, sortedArrayP3 = null;
            myArray = RandomUniqValue.GetRandomUniqueValue(90); //Unique Value

            Console.WriteLine("**********Listelerin Sıralanmamış Hali**********\n");
            for (int i = 0; i < 30; i++)
            {
                Console.Write($"İlkArray {myArray.Take(30).ToArray()[i]}");
                Console.Write($"--İkinciArray {myArray.Skip(30).Take(30).ToArray()[i]}");
                Console.WriteLine($"--ÜçüncüArray {myArray.Skip(60).Take(30).ToArray()[i]}");
            }
            try
            {
                m.WaitOne(); //İlk 3 Listenin Sıralama İşlemini Mutex İle Kilitliyoruz
                Thread thread = new Thread(o => { sortedArrayP1 = Sort.Bubble((int[])o); }); //Thread 1 Part 0-30
                thread.Start(myArray.Take(30).ToArray());
                thread.Join();

                Thread thread2 = new Thread(o => { sortedArrayP2 = Sort.Bubble((int[])o); }); //Thread 2 Part 31-60
                thread2.Start(myArray.Skip(30).Take(30).ToArray());
                thread2.Join();

                Thread thread3 = new Thread(o => { sortedArrayP3 = Sort.Bubble((int[])o); }); //Thread 3 Part 61-90
                thread3.Start(myArray.Skip(60).Take(30).ToArray());
                thread3.Join();

            }
            finally
            {
                m.ReleaseMutex();
            }
            Console.WriteLine("\n*******************Listelerin Sıralanmış Hali*******************");
            for (int i = 0; i < 30; i++)
            {
                Console.Write($"İlkArray {sortedArrayP1[i]}");
                Console.Write($"--İkinciArray {sortedArrayP2[i]}");
                Console.WriteLine($"--ÜçüncüArray {sortedArrayP3[i]}");
            }
            int[] AllValueSorted = Sort.SortThreeArray(sortedArrayP1, sortedArrayP2, sortedArrayP3);
            Console.WriteLine("*********************Sıralanmış Son Hali*********************");

            for (int i = 0; i < AllValueSorted.Length; i+=3)
            {
                Console.Write($"Sıralanmış Son Hali {AllValueSorted[i]}-->");
                Console.Write($"Sıralanmış Son Hali {AllValueSorted[i+1]}-->");
                Console.Write($"Sıralanmış Son Hali {AllValueSorted[i+2]}\n");
            }
            Console.ReadKey();

            // Thread thread3 = new Thread(
            //        o =>
            //        {
            //            sortedArrayP1 = Sort.Bubble((int[])o);
            //        });
            //Format
            //Start Code        thread.Start(myArray.Skip(60).Take(30).ToArray());

        }
    }
}
