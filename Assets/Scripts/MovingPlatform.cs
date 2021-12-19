using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] poins;
    public float moveSpeed;
    public int currentPoint;

    public Transform platform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        platform.position = Vector3.MoveTowards(platform.position, poins[currentPoint].position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(platform.position, poins[currentPoint].position) < .05f)
        {
            currentPoint++;

            if(currentPoint >= poins.Length)
            {
                currentPoint = 0;
            }
        }
    }
}
