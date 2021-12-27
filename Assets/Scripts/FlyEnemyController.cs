using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyController : MonoBehaviour
{
    public Transform[] poins;
    public float moveSpeed;
    private int currentPoint;

    public SpriteRenderer enemySR;

    public float distanceToAtackPlayer, chaseSpeed;

    private Vector3 attackTarget;

    public float waitAfterAttack;
    private float attackCounter;

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
        if(attackCounter > 0)
        {
            attackCounter -= Time.deltaTime;
        }
        else
        {
            if(Vector3.Distance(transform.position, PlayerController.instance.transform.position) > distanceToAtackPlayer)
            {
                attackTarget = Vector3.zero;

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
            else
            {
                //Attack the Player
                if(attackTarget == Vector3.zero)
                {
                    attackTarget = PlayerController.instance.transform.position;
                }

                transform.position = Vector3.MoveTowards(transform.position, attackTarget, chaseSpeed * Time.deltaTime);

                if(Vector3.Distance(transform.position, attackTarget) <= .1f)
                {
                    
                    attackCounter = waitAfterAttack;
                    attackTarget = Vector3.zero;
                }
            } 
        }    
    }
}
