namespace Rendezes
{
    public class Rendezes
    {
        public static void QuickSort(int[] array, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int pivot = SubArraySort(array, leftIndex, rightIndex);
                QuickSort(array, leftIndex, pivot - 1);
                QuickSort(array, pivot + 1, rightIndex);
            }

            // Helyi függvény
            static int SubArraySort(int[] array, int leftIndex, int rightIndex)
            {
                int i = leftIndex - 1;

                for (int j = leftIndex; j < rightIndex; j++)
                {
                    if (array[j] < array[rightIndex])
                    {
                        i++;
                        (array[i], array[j]) = (array[j], array[i]);
                    }
                }
                i++;

                (array[i], array[rightIndex]) = (array[rightIndex], array[i]);
                return i;
            }
        }
    }
}
