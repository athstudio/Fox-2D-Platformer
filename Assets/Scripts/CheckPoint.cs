using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public SpriteRenderer cpSR;

    public Sprite cpOn, cpOff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            CheckPointController.instance.DeactivateCheckPoints();

            cpSR.sprite = cpOn;

            CheckPointController.instance.SetSpawnPoint(transform.position);
            Debug.Log("Check Point");
        }
    }

    public void ResetCheckPoint() 
    {
       cpSR.sprite = cpOff;
    }
}
