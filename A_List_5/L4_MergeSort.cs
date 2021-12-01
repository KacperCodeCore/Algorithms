    internal class L4_MergeSort
    {
        public static int[] DoMergeSort(int[] array)
        {
            return MergeSort1(array);
        }
        private static int[] MergeSort1(int[] tab)
        {
            if (tab.Length <= 1) return tab;
            Program.t++;

            var left = new List<int>();
            var right = new List<int>();

            for (int i = 0; i < tab.Length; i++)
            {
                Program.t++;
                if (i % 2 > 0)
                    left.Add(tab[i]);
                else
                    right.Add(tab[i]);
            }

            left = MergeSort1(left.ToArray()).ToList();
            right = MergeSort1(right.ToArray()).ToList();

            return Merge(left, right);
        }
        private static int[] Merge(List<int> left, List<int> right)
        {
            var result = new List<int>();

            while (NotEmpty(left) && NotEmpty(right))
            {

                if (left.First() <= right.First())
                    MoveValueFromSorceToResult(left, result);
                else
                    MoveValueFromSorceToResult(right, result);
                Program.t++;
            }

            while (NotEmpty(left))//???
            {
                MoveValueFromSorceToResult(left, result);
                Program.t++;
        }

            while (NotEmpty(right))//???
            {
                MoveValueFromSorceToResult(right, result);
                Program.t++;
        }

            return result.ToArray();
        }


        private static bool NotEmpty(List<int> list)
        {
            return list.Count > 0;
        }
        private static void MoveValueFromSorceToResult(List<int> list, List<int> result)
        {
            result.Add(list.First());
            list.Remove(list.First());
        }
    }

