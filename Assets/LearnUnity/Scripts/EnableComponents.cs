using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableComponents : MonoBehaviour
{
    private Light lightEnable;
    

    // Start is called before the first frame update
    void Start()
    {
        lightEnable = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            
            lightEnable.enabled = !lightEnable.enabled;
        }
    }
}
