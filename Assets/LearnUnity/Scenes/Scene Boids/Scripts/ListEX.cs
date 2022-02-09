using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListEX : MonoBehaviour
{
    public List<string> sList; 

    void Start()
    {
        sList = new List<string>(); 
        sList.Add("Exsp");
        sList.Add("is");
        sList.Add("what");
        sList.Add("you");
        sList.Add("get");
        sList.Add("when");
        sList.Add("you");
        sList.Add("don't");
        sList.Add("get");
        sList.Add("what");
        sList.Add("you");
        sList.Add("wanted.");    

        print("sCount =" + sList.Count);
        print("The 0th " + sList[0]);
        print("The 1th " + sList[1]);
        print("The 3th " + sList[3]);
        print("The 8th " + sList[8]);   

        string str = "";
        foreach (string sTemp in sList)
        {
            print(str);
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
