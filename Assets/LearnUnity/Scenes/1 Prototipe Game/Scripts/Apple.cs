using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;
   
    void Update()
    {
        DestroyApples();
    }

    void DestroyApples()
    {
        //”нижчтожать €блоки, если они падают ниже Y -20; 
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
        }
    }
}
