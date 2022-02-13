using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI; // Ссылка на интересующий объект
    [Header("Set in Inspector")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    [Header("Set Dynamically")]
    public float camZ; // Желаемая координата З камеры

    private void Awake()
    {
        camZ = this.transform.position.z;
    }

    private void FixedUpdate()
    {
        //Однострочная версия иф не требует фигурных скобок 
        if (POI == null) return; //выйти если нет интересующего объекта 

        //Получить позицию интерисующего объекта
        Vector3 destination = POI.transform.position;
        //Ограничить  Икс и Игрик минимальными значениями 
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        //Определить точку между текущем местополжением камеры и дистинейшн
        destination = Vector3.Lerp(transform.position, destination, easing);
        //Принудительно установить значение дистинейшн.з равным камЗ, чтобы отодвинуть камеру подальше
        destination.z = camZ;
        //Поместить камеру в позицию дистинейшн
        transform.position = destination;
        //Изменить размер камеры ,чтобы земля оставалась в поле зрения
        Camera.main.orthographicSize = destination.y + 10;
    }
}
