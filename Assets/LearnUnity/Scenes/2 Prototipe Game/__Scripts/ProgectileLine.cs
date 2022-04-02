using System.Collections.Generic;
using UnityEngine;

public class ProgectileLine : MonoBehaviour
{
    public static ProgectileLine s;//Одиночка
    [Header("Set in Inspector")] public float minDist = 0.1f;

    private LineRenderer _line;
    private GameObject _poi;
    private List<Vector3> _points;

    private void Awake()
    {
        //Установить ссылку на объект одиночку
        s = this;
        //Получить ссылку на
        _line = GetComponent<LineRenderer>();
        //Откобчить его
        _line.enabled = false;
        //Иницилизировать список точек
        _points = new List<Vector3>();
    }

    // Это свойство (то есть метод, маскирующийся под поле)
    public GameObject Poi 
    {
        get => ( _poi );
        set 
        {
            _poi = value;
            if (_poi == null) return;
            // Если поле _poi содержит действительную ссылку,
            // сбросить все остальные параметры в исходное состояние
            _line.enabled = false;
            _points = new List<Vector3>();
            AddPoint();
        }
    }
    
    //Этот метод можно вызвать непосредственно, чтобы стереть линию
    public void Clear()
    {
        _poi = null;
        _line.enabled = false;
        _points = new List<Vector3>();
    }
    
    private void AddPoint()
    {
        //Вызывается для добавления точки в линии 
        Vector3 pt = _poi.transform.position;
        if (_points.Count > 0 && (pt - LastPoint).magnitude < minDist)
        {
            //Если точка недостаточно далека от предыдущей просто выйти
            return;
        }
        
        if (_points.Count == 0) //Если это точка запуска...
        {
            //Для опредления добавить дополнительный фрагмент линии, чтобы помочь лучше прицелится в будущем
            Vector3 launchPosDiff = pt - Slingshot.LAUNCH_POS;
            _points.Add(pt + launchPosDiff);
            _points.Add(pt);
            _line.positionCount = 2;
            //Установить первые две точки
            _line.SetPosition(0,_points[0]);
            _line.SetPosition(1,_points[1]);
            //Включить 
            _line.enabled = true;
        }
        else
        {
            //Обычная последовательность добавления точки
            _points.Add(pt);
            _line.positionCount = _points.Count;
            _line.SetPosition(_points.Count-1,LastPoint);
            _line.enabled = true;
        }
    }

    //Вовращает местоположение последней добавленной точки 
    public Vector3 LastPoint
    {
        get
        {
            if (_points == null)
            {
                //Если точек нет,вернуть 
                return (Vector3.zero);
            }
            return (_points[_points.Count - 1]);
        }
    }

    void FixedUpdate () 
    {
        if ( Poi == null ) 
        {
            // Если свойство poi содержит пустое значение, найти интересующий
            // объект
            if (FollowCam.poi != null) 
            {
                if (FollowCam.poi.CompareTag("Projectile")) 
                {
                    Poi = FollowCam.poi;
                } 
                else 
                {
                    return; // Выйти, если интересующий объект не найден
                }
            } 
            else 
            {
                return; // Выйти, если интересующий объект не найден
            }
        }
        // Если интересующий объект найден,
        // попытаться добавить точку с его координатами в каждом FixedUpdate
        AddPoint();
        if ( FollowCam.poi == null ) {
            // Если FollowCam.POI содержит null, записать nulll в poi
            Poi = null;
        }
    }
}
