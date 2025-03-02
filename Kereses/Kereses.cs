namespace Kereses
{
    static public class Kereses
    {
        /* IComparable működése:
         * -1 a bal oldal kisebb mint a jobb oldal
         *  0 egyenlőek
         *  1 a bal oldal nagyobb mint a jobb oldal
         */
        public static int BinarySearch<T>(List<T> items, T item) where T : IComparable<T>
        {
            if (items.Count == 0) return -1;

            int lowerLimit = 0;
            int upperLimit = items.Count - 1;

            while (lowerLimit <= upperLimit)
            {
                int middleIndex = (lowerLimit + upperLimit) / 2;
                int comparison = items[middleIndex].CompareTo(item);

                if (comparison == 0)
                    return middleIndex;
                else if (comparison < 0)
                    lowerLimit = middleIndex + 1;
                else
                    upperLimit = middleIndex - 1;
            }

            return -1;
        }








    }
}
