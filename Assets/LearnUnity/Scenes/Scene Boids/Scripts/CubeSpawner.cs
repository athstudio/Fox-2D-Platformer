using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefabVar;
    public List<GameObject> gameObjectsList;

    public float scalingFactor = 0.95f;

    public int numCubes = 0;


    void Start()
    {
        gameObjectsList = new List<GameObject>();
    }

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
