using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        DateTime start_select;
        DateTime start_insert;
        TimeSpan timeittook_select; 
        TimeSpan timeittook_insert;
        
        Console.Write("Enter the number of elements: "); //choose size of list
        int count = int.Parse(Console.ReadLine());
        
        List<int> unsorted = GenerateRandomList(count);

        start_select = DateTime.Now;
        List<int> sorted_select = SelectionSort(unsorted);  //calling select method
        timeittook_select = DateTime.Now - start_select;     //measuring how long it took

        Console.WriteLine("Time(select): " + timeittook_select);
            
        start_insert = DateTime.Now;
        List<int> sorted_insert = InsertionSort(unsorted);  //calling insert method
        timeittook_insert = DateTime.Now - start_insert;    //measuring how long it took
        
        Console.WriteLine("Time(insert): " + timeittook_insert);
        
        if(timeittook_insert < timeittook_select){
            Console.WriteLine("Insert is faster!");
        }else{
            Console.WriteLine("Select is faster!");
        }
    }

    public static List<int> GenerateRandomList(int count)   //method to generate random list
    {
        Random rand = new Random();
        List<int> list = new List<int>();
        
        for (int i = 0; i < count; i++)
        {
            list.Add(rand.Next(1, 1000));
        }
        
        return list;
    }

    //method that takes unsorted list and sorts it using select sort
    public static List<int> SelectionSort(List<int> unsortedList)
    {
        //copy the list so i can sort it with different method after
        List<int> sortedList_select = new List<int>(unsortedList);
        
        int smallest;
        
        for (int i = 0; i < sortedList_select.Count - 1; i++)
        {
            smallest = i;
            
            for (int j = i + 1; j < sortedList_select.Count; j++)
            {
                if (sortedList_select[j] < sortedList_select[smallest])
                {
                    smallest = j;
                }
            }
            
            int temp = sortedList_select[i];
            sortedList_select[i] = sortedList_select[smallest];
            sortedList_select[smallest] = temp;
        }
        return sortedList_select;
    }
    
    //method that takes unsorted list and sorts it using insert sort
    public static List<int> InsertionSort(List<int> unsortedList)
    {
        List<int> sortedList_insert = new List<int>(unsortedList);
        
        for (int i = 1; i < sortedList_insert.Count; i++)
        {
            int key = sortedList_insert[i];
            int j = i - 1;
            
            while (j >= 0 && sortedList_insert[j] > key)
            {
                sortedList_insert[j + 1] = sortedList_insert[j];
                j--;
            }
            
            sortedList_insert[j + 1] = key;
        }
        
        return sortedList_insert;
    }
}
