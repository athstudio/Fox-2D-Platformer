using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{
    int numEnemies = 3;
    int cupsInTheSink = 4;


    // Start is called before the first frame update
    void Start()
    {
       for (int i = 0; i < 10; i++)
       {
           print(i);
           if(i == 3)
           {
               break;
           }
       }

       for (int i = 5; i > 0; i--)
       {
           print("Loop - :" + i);
       }



       string str = "Hello";
       foreach (char chr in str)
       {
         print(chr);
       }

        // Цикл for----------------------------------
        for (int i = 0; i < numEnemies; i++)
        {
            // Debug.Log("Creating enemy number: " + i);
        }
        // Цикл while---------------------------------
        while (cupsInTheSink > 0)
        {
            // Debug.Log ("I've washed a cup!");
            cupsInTheSink--;
        }
        // Цикл do while------------------------------
        bool shouldContinue = false;

        do
        {
            //print ("Hello World");

        }
        while (shouldContinue == true);

        // Цикл foreach------------------------------- + Массив
        string[] strings = new string[3];

        strings[0] = "First string";
        strings[1] = "Second string";
        strings[2] = "Third string";

        foreach (string item in strings)
        {
            // print (item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
