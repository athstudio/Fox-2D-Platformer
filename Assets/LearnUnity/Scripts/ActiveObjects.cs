using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObjects : MonoBehaviour
{
    [SerializeField] public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            cube.SetActive(true);
        }
        if(Input.GetKey(KeyCode.W))
        {
            cube.SetActive(true);
        }
        if(Input.GetKey(KeyCode.E))
        {
            cube.SetActive(true);
        }
    }
}
