using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    //public static int number;

    [SerializeField] int currentHealth, maxHealth;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage()
    {
        currentHealth--;

        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
