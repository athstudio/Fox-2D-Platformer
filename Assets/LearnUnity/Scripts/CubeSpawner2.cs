using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner2 : MonoBehaviour
{
    public GameObject cubePrefabVar;
    


    void Start()
    {
        //Instantiate(cubePrefabVar);
    }

    void Update()
    {
        SpellItOut();
        Instantiate(cubePrefabVar);
    }

    public void SpellItOut()
    {
        string sA = "Hello World";
        string sB = "";

        for (int i = 0; i < sA.Length; i++)
        {
            sB += sA[i];
        }
        Debug.Log(sB);
    }
}
