using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefabVar;

    bool bravo;
    GameObject gObj = new GameObject("MyGO");

    
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(cubePrefabVar);
        bravo = true;
        print(gObj.name);
        Transform trans = gObj.transform; // сокращение Transform trans2 = GetComponent<Transform>(); 
        
        print(20 > 10); // оператор больше, возвращает true если значение слева БОЛЬШЕ правого.

        print(10 < 20); // оператор меньше, вовращает true если значение слева МЕНЬШЕ правого.
        
        print(10 >= 10); // true 
        print(10 <= 10); //true
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(cubePrefabVar);
        
    }
}
