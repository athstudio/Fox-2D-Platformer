using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyInput : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool down = Input.GetKeyDown(KeyCode.Space);
        bool held = Input.GetKey(KeyCode.Space);
        bool up = Input.GetKeyUp(KeyCode.Space);

        if (down)
        {
            Debug.Log("Down");
        }
        else if (held)
        {
            Debug.Log("Held");
        }
        else if (up)
        {
            Debug.Log("Up");
        }
        else
        {
            Debug.Log("Standart");
        }
    }
}
