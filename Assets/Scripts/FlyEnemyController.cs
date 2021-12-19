using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyController : MonoBehaviour
{
    public Transform[] poins;
    public float moveSpeed;
    private int currentPoint;

    public SpriteRenderer enemySR;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < poins.Length; i++)
        {
            poins[i].parent = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, poins[currentPoint].position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, poins[currentPoint].position) < .05f)
        {
            currentPoint++;

            if(currentPoint >= poins.Length)
            {
                currentPoint = 0;
            }
        }

        if(transform.position.x < poins[currentPoint].position.x)
        {
            enemySR.flipX = true;
        }
        else if(transform.position.x > poins[currentPoint].position.x)
        {
            enemySR.flipX = false;
        }
    }
}
