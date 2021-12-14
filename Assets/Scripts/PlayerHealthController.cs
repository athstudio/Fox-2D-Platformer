using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth, maxHealth;

    public float invincibleLength;
    public float invincibleCounter;

    private SpriteRenderer playerSR;

    public GameObject deathEffect;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;

        playerSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;
            
            if(invincibleCounter <= 0)
            {
                playerSR.color = new Color(playerSR.color.r, playerSR.color.g, playerSR.color.b, 1f);
            }
        }
    }

    public void DealDamage()
    {
        if(invincibleCounter <= 0)
        {
            //currentHealth = currentHealth - 1; or currentHealth -= 1;
            currentHealth--;

            if(currentHealth <= 0)
            {
                currentHealth = 0;

                //gameObject.SetActive(false);

                Instantiate(deathEffect, transform.position, transform.rotation);

                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                invincibleCounter = invincibleLength;
                playerSR.color = new Color(playerSR.color.r, playerSR.color.g, playerSR.color.b, .5f);

                PlayerController.instance.KnockBack();

                AudioManager.instance.PlaySFX(9);
            }

            UIController.instance.UpdateHealthDisplay();
        }
    }

    public void HealPlayer()
    {
        currentHealth++;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIController.instance.UpdateHealthDisplay();
    }

    public void HealPlayer_x2()
    {
        currentHealth = currentHealth + 4;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIController.instance.UpdateHealthDisplay();
    }
}
