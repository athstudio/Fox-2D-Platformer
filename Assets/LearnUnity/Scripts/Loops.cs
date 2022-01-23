using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{
    
   

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
