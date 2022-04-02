using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;

    public Transform leftPoint, rightPoint;

    private bool movingRight;

    private Rigidbody2D enemyRB;
    public SpriteRenderer enemySR;
    private Animator amin;

    public float moveTime, waitTime;
    private float moveCount, waitCount;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        amin = GetComponent<Animator>();

        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true;

        moveCount = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveCount > 0)
        {
            moveCount -= Time.deltaTime;

            if(movingRight)
            {
                enemyRB.velocity = new Vector2(moveSpeed, enemyRB.velocity.y);

                enemySR.flipX = true;

                if(transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                enemyRB.velocity = new Vector2(-moveSpeed, enemyRB.velocity.y);

                enemySR.flipX = false;

                if(transform.position.x < leftPoint.position.x)
                    {
                          movingRight = true;
                    }
            }

            if(moveCount <= 0)
            {
                waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
            }
            amin.SetBool("isMoving", true);
        }
            else if(waitCount > 0)
            {
                waitCount -= Time.deltaTime;
                enemyRB.velocity = new Vector2(0f, enemyRB.velocity.y);

            if(waitCount <= 0)
            {
                moveCount = Random.Range(moveTime * .75f, moveTime * .75f);
            }
            amin.SetBool("isMoving", false);
            }
             
    }
}
