using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    [Header("Set Dinamically")]
    public Rigidbody rb;

    private Neighborhood neighborhood;

    //Используйте этот метод для иницилизации
    void Awake()
    {
        neighborhood = GetComponent<Neighborhood>();
        rb = GetComponent<Rigidbody>();

        // Выбрать случайную начальную позицию
        pos = Random.onUnitSphere * Spawner.S.spawnRadius;

        // Выбрать случайную начальную скорость
        Vector3 vel = Random.onUnitSphere * Spawner.S.velocity;
        rb.velocity = vel;

        LookAhead();

        // Окрасить птицу в случайный цвет, но не сильно темный
        Color randColor = Color.black;
        while (randColor.r + randColor.g + randColor.b < 1.0f)
        {
            randColor = new Color(Random.value, Random.value, Random.value);
        }

        Renderer[] rends = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rends)
        {
            r.material.color = randColor;
        }
    }
        void LookAhead()
        {
            //Оринтировать птицу клювом в сторону полета 
            transform.LookAt(pos + rb.velocity);
        }

        public Vector3 pos
        {
        get { return transform.position; }
        set { transform.position = value; }
        }

    private void FixedUpdate()
    {
        Vector3 vel = rb.velocity;
        Spawner spn = Spawner.S;

        // ПРЕДОТВРАЩЕНИЕ СТОЛКНОВЕНИЙ - избегать близких соседей
        Vector3 velAvoid = Vector3.zero;
        Vector3 tooClosePos = neighborhood.avgClosePos;
        // Если получен вектор Vector3.zero, ничего предпринимать не надо
        if(tooClosePos != Vector3.zero)
        {
            velAvoid = pos - tooClosePos;
            velAvoid.Normalize();
            velAvoid *= spn.velocity;
        }

        // СОГЛАСОВАНИЕ СКОРОСТИ - попробовать согласовать скорость с соседями
        Vector3 velAlign = neighborhood.avgVel;
        // Согласование требуется, только если velAlign не равно Vector3.zero
        if(velAlign != Vector3.zero)
        {
            // Нас интересует только направление, поэтому нормализуем скорость
            velAlign.Normalize();
            // и затем преобразуем в выбранную скорость
            velAlign *= spn.velocity;
        }

        // КОНЦЕНТРАЦИЯ СОСЕДЕЙ - движение в сторону центра группы соседей
        Vector3 velCenter = neighborhood.avgPos;
        if(velCenter != Vector3.zero)
        {
            velCenter -= transform.position;
            velCenter.Normalize();
            velCenter *= spn.velocity;
        }

        // ПРИТЯЖЕНИЕ - организовать движение в сторону объекта Attractor
        Vector3 delta = Attractor.POS - pos;
        // Проверить, куда двигаться, в сторону Attractor или от него
        bool attracted = (delta.magnitude > spn.attractPushDist);
        Vector3 velAttact = delta.normalized * spn.velocity;

        // Применить все скорости
        float fdt = Time.fixedDeltaTime;
        if(velAvoid != Vector3.zero)
        {
            vel = Vector3.Lerp(vel, velAvoid, spn.collAvoid * fdt);
        }
        else
        {
            if(velAlign != Vector3.zero)
            {
                vel = Vector3.Lerp(vel, velAlign, spn.velMatching * fdt);
            }
        }

        if (velCenter != Vector3.zero)
        {
            vel = Vector3.Lerp(vel, velAlign, spn.flockCentering * fdt);
        }

        if (velAttact != Vector3.zero)
        {
            if (attracted)
            {
                vel = Vector3.Lerp(vel, velAttact, spn.attractPull * fdt);
            }
            else
            {
                vel = Vector3.Lerp(vel, -velAttact, spn.attractPush * fdt);
            }
        }

        if(attracted)
        {
            vel = Vector3.Lerp(vel, velAttact, spn.attractPull * fdt);
        }
        else
        {
            vel = Vector3.Lerp(vel, -velAttact, spn.attractPush * fdt);
        }

        // Установить vel в соответствии c velocity в объекте-одиночке Spawner
        vel = vel.normalized * spn.velocity;
        // В заключение присвоить скорость компоненту Rigidbody
        rb.velocity = vel;
        //Повернуть птицу клювом в сторону нового направления движения
        LookAhead();
    }

}
