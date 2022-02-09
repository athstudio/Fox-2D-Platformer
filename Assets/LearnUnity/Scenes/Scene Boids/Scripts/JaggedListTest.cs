using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaggedListTest : MonoBehaviour
{
    public List<List<string>> jaggedList;

    // Start is called before the first frame update
    void Start()
    {
        jaggedList = new List<List<string>>();

        jaggedList.Add(new List<string>());
        jaggedList.Add(new List<string>());

        jaggedList[0].Add("Hello");
        jaggedList[0].Add("World");

        jaggedList.Add(new List<string>(new string[] {"complex", "initialization"}));

        string str = "";
        foreach(List<string> sL in jaggedList)
        {
            foreach(string sTemp in sL)
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
        print(str);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
