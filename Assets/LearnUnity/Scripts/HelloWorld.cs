using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    public float speedX = 3f;
    public float speedY = 3f;
    public float speedZ = 3f;

    // Start is called before the first frame update
    void Start()
    {
        print("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speedX * Time.deltaTime * 100,
                         speedY * Time.deltaTime * 100,
                         speedZ * Time.deltaTime * 100); 
    }
}
