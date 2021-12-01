using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_List_5
{
    internal class L5_HoareSort : Program
    {
        public static int[] a;
        public static int p;

        public static int DoHoare(int[] array, int k)
        {
            a = new int[array.Length];
            array.CopyTo(a, 0);

            return Choice(1, a.Length - 1, k);
        }

        private static int SplitUp(int l, int r)
        {
            p = a[l];
            int i = l - 1;
            int j = r + 1;
            while (i < j)
            {
                do { j--; Program.t++; } while (a[j] > p);
                do { i++; Program.t++; } while (a[i] < p);

                if (i < j)
                    Program.Swap(ref a[j], ref a[i]);
            }
            return j;
        }

        private static int SplitUp_Rnd(int l, int r)
        {
            var rnd = new Random();
            int i = rnd.Next(l, r);
            Program.Swap(ref a[l], ref a[i]);
            return SplitUp(l, r);
        }

        private static int Choice(int l, int r, int k)
        {
            if (l < r)
            {
                int j = SplitUp_Rnd(l, r);
                int m = j - l + 1;
                if (k <= m)
                    return Choice(l, j, k);
                else
                    return Choice(j + 1, r, k - m);
            }
            else
                return a[l];
        } 

    }
}
