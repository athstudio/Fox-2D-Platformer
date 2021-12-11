using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CametaControllers : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] Transform farBG, middleBG;

    [SerializeField] float minHeight,maxHeight;
    

    /* private float lastXPos;
    private float lastYPos; */

    private Vector2 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        /*lastXPos = transform.position.x;
        lastYPos = transform.position.y; */
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveCamera();

        moveBGandMiddleBG();
    }

    private void moveCamera()
    {
       /* transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        float clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z); */

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
