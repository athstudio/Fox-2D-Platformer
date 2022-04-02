using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool isGem, isHeal, isHealx2;

    private bool isCollected;

    public GameObject pickupeffect;

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
        if(other.CompareTag("Player") && !isCollected)
        {
            if(isGem)
            {
                LevelManager.instance.gemsCollected++;

                isCollected = true;

                Destroy(gameObject);

                Instantiate(pickupeffect, transform.position, transform.rotation);

                UIController.instance.UpdateGemCount();

                AudioManager.instance.PlaySFX(6);
            }

            if(isHeal)
            {
                if(PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.HealPlayer();

                    isCollected = true;
                    Destroy(gameObject);

                    Instantiate(pickupeffect, transform.position, transform.rotation);

                    AudioManager.instance.PlaySFX(7);
                }
            }

            if(isHealx2)
            {
                if(PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.HealPlayer_x2();

                    isCollected = true;
                    Destroy(gameObject);

                    Instantiate(pickupeffect, transform.position, transform.rotation);

                    AudioManager.instance.PlaySFX(7);
                }
            }
        }
    }
}
