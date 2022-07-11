namespace TwoSum
{
    internal class Program
    {
        /*
        **slower than second solution, but uses a little less RAM
        */
        public static int[] FirstSolution(int[] nums, int target)
        {
            int[] result = new int[2];
            int tempSum = 0;
            int Length = nums.Length;
            for (int i = 0; i < Length; i++)
            {
                tempSum = nums[i];
                result[0] = i;
                for (int j = i + 1; j < Length; j++)
                {
                    tempSum += nums[j];
                    if (tempSum == target)
                    {
                        result[1] = j;
                        return result;
                    }
                    else { tempSum -= nums[j]; }
                }
            }
            return result;
        }

        /*
        **faster than first Solution, but uses a litle more RAM
        */
        public static int[] SecondSolution(int[] nums, int target)
        {
            int[] result = new int[2];
            int tempSum1 = 0;
            int tempSum2 = 0;
            bool flag = false;
            int Length = nums.Length;
            int i = 0, j = Length - 1;
            int temp1 = 0, temp2 = Length - 1;
            while (true)
            {
                tempSum1 = nums[i];
                tempSum2 = nums[j];
                result[0] = i;
                result[1] = j;

                if (tempSum1 + tempSum2 == target)
                {
                    break;
                }

                i++;
                j--;

                if (i >= j)
                {
                    if (flag == false)
                    {
                        i = ++temp1;
                        j = Length - 1;
                        flag = true;
                    }
                    else
                    {
                        i = 0;
                        j = --temp2;
                        flag = false;
                    }
                }
            }
            return result;
        }
        public static void PrintResult(int [] result) {
            Console.WriteLine($"first index: {result[0]}, second index: {result[1]}");
        }

        static void Main(int[] nums, int target)
        {
            int[][] result = new int[2][];
            result[0] = FirstSolution(nums, target);
            result[1] =  SecondSolution(nums, target);

            foreach (var item in result)
            {
                PrintResult(item);
            }
            Console.ReadKey();
        }
    }
}
