using System;
using System.Collections.Generic;

namespace MonotonousStack
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (int i in GetMaxRightArray(new int[] { 2, 6, 3, 8, 10, 9 }))
            {
                Console.Write(i+" ");
            }
        }

        private static IEnumerable<int> GetMaxRightArray(int[] array)
        {
            if (array == null || array.Length == 0) return array;//{ 2, 6, 3, 8, 10, 9 }
            Stack<int> stack = new Stack<int>();
            int[] res = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                while (stack.Count != 0 && array[stack.Peek()] < array[i])
                {
                    int index = stack.Pop();
                    res[index] = array[i];
                }
                stack.Push(i);
            }
            while(stack.Count != 0)
            {
                res[stack.Pop()] = -1;
            }

            return res;
        }
    }
}
