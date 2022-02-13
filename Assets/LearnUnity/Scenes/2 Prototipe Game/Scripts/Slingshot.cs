using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    //Поля, устанавливаемые в инспекторе Юнити
    [Header("Set in Inspector")]
    public GameObject prefabProjectile;
    public float velocityMult = 8f;

    // поля, устанавливаемые динамически 
    [Header("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;

    private Rigidbody projectileRigidbody;

    private void Awake()
    {
        //найдет дочерний объект с именем ланчпоинт вложенный в слигшоте, и вернет его компонент трансформ.
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(true);
        launchPos = launchPointTrans.position;
    }

    private void Update()
    {
        //Если рогатка не в режиме прицеливания, не выполнять этот код
        if (!aimingMode) return;

        //Получить текущие экранные координаты указателя мыши
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Найти разность координат между ланчпос и мауспос3д
        Vector3 mouseDelta = mousePos3D - launchPos;

        //Ограничить маусдельта радиусом коллайдера объекта Слингшота
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if(mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        //Передвинуть снаряд в новую пизицию 
        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;
        if(Input.GetMouseButtonUp(0))
        {
            //Кнопка мыши отпущена
            aimingMode = false;
            projectileRigidbody.isKinematic = false;
            projectileRigidbody.velocity = -mouseDelta * velocityMult;
            FollowCam.POI = projectile;
            projectile = null;
        }
    }

    void OnMouseEnter()
    {
        Debug.Log("Slingshot:OnMouseEnter()");
        launchPoint.SetActive(true);
    }

    void OnMouseExit()
    {
        Debug.Log("Slingshot:OnMouseEXit()");
        launchPoint.SetActive(false);
    }

    void OnMouseDown()
    {
        //Игрок нажал мыши, когда указатель находится над рогаткой 
        aimingMode = true;
        //Создать cнаряд
        projectile = Instantiate(prefabProjectile) as GameObject;
        //Поместить в точку ланчпоинт
        projectile.transform.position = launchPos;
        //Сделать его кинематически
        projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectileRigidbody.isKinematic = true;
    }
}
