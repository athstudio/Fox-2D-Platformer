using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public static GameObject poi; // Ссылка на интересующий объект
    [Header("Set in Inspector")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    [Header("Set Dynamically")]
    public float camZ; // Желаемая координата З камеры

    void Awake()
    {
        camZ = this.transform.position.z;
    }

    void FixedUpdate()
    {
         Vector3 destination;
        //Если нет интересующего объекта получить позицию 0 0 0
        if (poi == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            destination = poi.transform.position;
            
            if (poi.CompareTag("Projectile"))
            {
                //Если он стоит на месте 
                if (poi.GetComponent<Rigidbody>().IsSleeping())
                {   
                    //Вернуть исходные настройки для поля зрения
                    poi = null;
                    //в следующем кадре
                    return;
                }
                        
            }
        }
        //Если интересующий объект - снаряд, убедиться, что он остановился
       
       
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
        if (Camera.main != null) Camera.main.orthographicSize = destination.y + 10;
    }
}
