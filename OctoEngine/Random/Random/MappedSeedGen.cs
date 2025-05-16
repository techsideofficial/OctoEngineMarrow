using System;
using System.Collections.Generic;

namespace OctoEngine.Random
{
    public class MappedSeedGen
    {
        public static int[] GenRandNum(int num)
        {
            string numToHalf = num.ToString();
            int a = Convert.ToInt32(numToHalf.Substring(0, 4));
            int b = Convert.ToInt32(numToHalf.Substring(4, 4));

            int c1 = a + b;
            int a1 = c1 + 2;

            float d1 = a1 / 3f;
            float a2 = d1 + a;

            int r1 = Convert.ToInt32(a2);

            int s1 = r1 - 17;
            int s2 = s1 - 9876;
            int a3 = s2 + 69;
            int d2 = a3 / 22;
            int m1 = d2 * 37;

            int fin = Math.Abs(m1);

            int v1 = fin - 265;
            int v2 = fin - 954;
            int v3 = fin - 644;
            int v4 = fin + 941;
            int v5 = fin + 254;
            int v6 = fin + 943;
            int v7 = fin - 304;
            int v8 = fin - 736;
            int v9 = fin + 356;
            int v10 = fin + 207;

            int[] rawValues = { v1, v2, v3, v4, v5, v6, v7, v8, v9, v10 };
            HashSet<int> uniqueValues = new HashSet<int>();

            int[] mappedValues = new int[10];
            int currentIndex = 0;

            foreach (int value in rawValues)
            {
                int mappedValue = Math.Abs(value % 10) + 1;

                // Ensure uniqueness
                while (uniqueValues.Contains(mappedValue))
                {
                    mappedValue = (mappedValue % 10) + 1;
                }

                uniqueValues.Add(mappedValue);
                mappedValues[currentIndex++] = mappedValue;
            }

            return mappedValues;
        }
    }
}