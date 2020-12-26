using System;

namespace ConsoleApplication1
{
    class Program
    {
        static IEnumerable<int>
        XPTO(int from, int to) {
            for (int i = from; i<to; i+=3) {
                yield return i;
            }
            yield break;
        }

        static void Main()
        {
            foreach (int x in XPTO(-10, 10)) {
                Console.WriteLine(x);
            }
        }
    }
}