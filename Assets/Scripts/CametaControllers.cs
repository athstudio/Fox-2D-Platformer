using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CametaControllers : MonoBehaviour //Camera* :D
{
    public static CametaControllers instance;

    public Transform target;
    public Transform farBG, middleBG;

    public float minHeight,maxHeight;

    public bool stopFollow;
    
    private Vector2 lastPos;

    private void Awake() 
    {
        instance = this;
    }

    void Start()
    {
        lastPos = transform.position;
    }


    void Update()
    {
        if(!stopFollow)
        {
            moveCamera();

            moveBGandMiddleBG();
        }
    }

    private void moveCamera()
    {
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y,minHeight, maxHeight), transform.position.z);
    }

    private void moveBGandMiddleBG()
    {
        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);
        

        farBG.position = farBG.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
        middleBG.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .5f;

        lastPos = transform.position;
    }
}
