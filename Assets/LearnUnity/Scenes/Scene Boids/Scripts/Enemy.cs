using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public float fireRate = 0.3f;


    void Update()
    {
        Move();
    }

    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject gameObject = other.gameObject;
        switch(gameObject.tag)
        {
            case "Hero":
                //Повреждение герою
                break;
            case "HeroLaser":
                // Уничтожить этого врага
                Destroy(this.gameObject);
                break;
        }
    }

    // Это свойсво; Метод, действуйщий как поле 
    public Vector3 pos
    {
        get { return (this.transform.position); }
        set { this.transform.position = value; }
    }
}
