using System;

class Program{

    static void Main(){
        int[] array1 = [1, 4, 9, 2 ,12];
        int[] array2 = [7, 18, 31, 4, 7];

        int minDistance = FindMinDistance(array1, array2);

        Console.WriteLine("A distância menor entre Arrays é: " + minDistance);
    }

    static int FindMinDistance(int[] arr1, int[] arr2){
        
        int minDistance = int.MaxValue;

        Array.Sort(arr1);
        Array.Sort(arr2);

        int i = 0, j = 0;

        while(i < arr1.Length && j < arr2.Length){
            
            int distance = Math.Abs(arr1[i]-arr2[j]);

            Console.WriteLine(arr1[i] + "-" + arr2[j] + ": " + distance);

            if(distance < minDistance){
                minDistance = distance;
            }

            if(arr1[i] < arr2[j]){
                i++;
            }else{
                j++;
            }

        }

        return minDistance;
    }

}
