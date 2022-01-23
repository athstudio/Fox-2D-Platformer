using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefabVar;
    public List<GameObject> gameObjectsList;
    public float scalingFactor = 0.95f;
    public int numCubes = 0;


   
    //GameObject gObj = new GameObject("MyGO");

    
    // Start is called before the first frame update
    void Start()
    {
        gameObjectsList = new List<GameObject>();


        //Instantiate(cubePrefabVar);
       
        //print(gObj.name);
        //Transform trans = gObj.transform; // сокращение Transform trans2 = GetComponent<Transform>(); 
        
        print(20 > 10); // оператор больше, возвращает true если значение слева БОЛЬШЕ правого.

        print(10 < 20); // оператор меньше, вовращает true если значение слева МЕНЬШЕ правого.
        
        print(10 >= 10); // true 
        print(10 <= 10); //true
    }

    // Update is called once per frame
    void Update()
    {
        numCubes++;
        GameObject gObj = Instantiate<GameObject>(cubePrefabVar);
        gObj.name = "Cube " + numCubes;
        Color c = new Color(Random.value, Random.value, Random.value);
        gObj.GetComponent<Renderer>().material.color = c;
        gObj.transform.position = Random.insideUnitSphere;

        gameObjectsList.Add(gObj);

        List<GameObject> removeList = new List<GameObject>();

        foreach(GameObject goTemp in gameObjectsList)
        {
            float scale = goTemp.transform.localScale.x;
            scale *= scalingFactor;
            goTemp.transform.localScale = Vector3.one * scale;

            if(scale <= 0.1f)
            {
                removeList.Add(goTemp);
            }
        }

        foreach(GameObject goTemp in removeList)
        {
            gameObjectsList.Remove(goTemp);
            Destroy(goTemp);
        }
        
    }
}
