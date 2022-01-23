using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaggedArrayEx : MonoBehaviour
{
    public string[][] jArray;

    // Start is called before the first frame update
    void Start()
    {
        jArray = new string[4][];

        jArray[0] = new string[5];
        jArray[0][0] = "A";
        jArray[0][1] = "B";
        jArray[0][2] = "C";
        jArray[0][3] = "D";
        jArray[0][4] = "F";

        jArray[1] = new string[] {"E", "F", "G"}; // 0 1 2
        jArray[2] = new string[] {"H", "I"}; // 0 1

        jArray[3] = new string[4];
        jArray[3][0] = "J";
        jArray[3][3] = "K";

        print("The Legth of jArray is:" + jArray.Length);

        print("The Legth of jArray is:" + jArray[0].Length); 

        string str =  "";
        /*
        foreach (string[] sArray in jArray)
        {
            foreach (string sTemp in sArray)
            {
                if(sTemp != null)
                {
                    str += " | " + sTemp;
                }
                else
                {
                    str += "  |  "; 
                }
            }
            str += " | \n";
        }
        */
        for (int i = 0; i < jArray.Length; i++)
        {
            for (int j = 0; j < jArray[i].Length; j++)
            {
                if(jArray[i][j] != null)
                {
                    str += " | " + jArray[i][j];
                }
                else
                {
                    str += "  |  ";
                }
            }
            str += " | \n";
        }
        print(str);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
