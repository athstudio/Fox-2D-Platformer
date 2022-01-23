using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayEX : MonoBehaviour
{
    public string[] sArray;

    

    void Start()
    {
       string[] sA = new string[] {"1", "2", "3", "4"};

       List<string> sL = new List<string>(sA);
       
       System.Array.IndexOf(sA, "4");
       System.Array.Resize(ref sA, 6);

       sA[1] = "3";
       sA[5] = "6";

       print(sA[5]);
       print(sA.Length);

       string str = "";
       foreach (string sTemp in sA)
       {
           str += "|" + sTemp;
       }
       print(str);

       sArray = new string[10];

       sArray[0] = "1";
       sArray[1] = "2";
       sArray[2] = "3";
       sArray[3] = "4";
       sArray[4] = "5";
       sArray[5] = "6";
       sArray[7] = "8";
       sArray[8] = "9";
       sArray[9] = "10";
       
       print("The legth of sArray is: " + sArray.Length);

       string str1 = "";
       foreach (string sTemp in sArray)
       {
           str += "|" + sTemp;
           if(sTemp == null) break;
       }
       print(str1);
    }

    
    void Update()
    {
        
    }
}
