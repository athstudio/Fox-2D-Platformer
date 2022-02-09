using System.Collections;
using System.Collections.Generic; //a
using UnityEngine;

public class DistionaryEX : MonoBehaviour
{
    public Dictionary<string,string> stateDict; // b

    public Dictionary<int,string> dIS;

    // Start is called before the first frame update
    void Start()
    {
        stateDict = new Dictionary<string, string>(); // c

        stateDict.Add("MD", "Marryland");  // d
        stateDict.Add("TX", "Texas");
        stateDict.Add("PA", "Pennsylvania");
        stateDict.Add("CA", "California");
        stateDict.Add("MI", "Michigan");

        print("There are " + stateDict.Count + " elements in statesDict."); // e

        foreach (KeyValuePair <string,string> kvp in stateDict) //f
        {
            print(kvp.Key + ": " + kvp.Value);
        }

        print("MI is " + stateDict["MI"]); //g

        stateDict["BC"] = "British Columbia"; //h

        foreach (string k in stateDict.Keys) //i
        {
            print(k + " is " + stateDict[k]);
        }

        dIS = new Dictionary<int, string>();
        dIS[0] = "Zero"; // {0, "Zero"},
        dIS[1] = "One";
        dIS[10] = "Ten";
        dIS[1234567890] = "A lot!";
        dIS.Add(12, "Dozen");
        dIS[13] = "Baker's Dozen";
        // dIS.Clear(); 
        dIS.ContainsValue("A lot!");
        dIS.Remove(10);

        print("There are " + dIS.Count + " elements in dIS.");

        foreach (KeyValuePair <int,string> kvp in dIS) //f
        {
            print(kvp.Key + ": " + kvp.Value);
        }

        print("0 = " + dIS[0]);

        dIS[15] = "Brog";

        foreach (int k in dIS.Keys) //i
        {
            print(k + " is " + dIS[k]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
