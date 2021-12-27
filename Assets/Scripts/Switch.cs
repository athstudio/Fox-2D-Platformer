using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject objectToSwitch;

    private SpriteRenderer switchSR;
    public Sprite downSprite;

    public bool hasSwitched;

    public bool deactivateOnSwitch;

    // Start is called before the first frame update
    void Start()
    {
        switchSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player" && !hasSwitched)
        {
            if(deactivateOnSwitch)
            {
                objectToSwitch.SetActive(false);
            }
            else
            {
                objectToSwitch.SetActive(true);
            }
            
            switchSR.sprite = downSprite;
            hasSwitched = true;
            AudioManager.instance.PlaySFX(9);
        }
    }
}
