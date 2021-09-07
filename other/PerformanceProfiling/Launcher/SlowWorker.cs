using System;
using System.Collections.Generic;
using System.Text;

namespace Launcher
{
    public class SlowWorker
    {
        private int[] arrayToSort;
        public void PreapreTask(int size)
        {
            arrayToSort = new int[size];
            for (int i = 0; i < size; i++)
                arrayToSort[i] = size - i;
        }

        public void PerformTask()
        {
            bool finished = false;
            int n = arrayToSort.Length;
            while(!finished)
            {
                finished = true;
                for(int i=0; i<n-1; i++)
                {
                    if (arrayToSort[i] > arrayToSort[i+1])
                    {
                        SwapAtIndex(i);
                        finished = false;
                    }
                }
            }
        }

        private void SwapAtIndex(int index)
        {
            int temp = arrayToSort[index];
            arrayToSort[index] = arrayToSort[index + 1];
            arrayToSort[index + 1] = temp;
        }
    }
}
