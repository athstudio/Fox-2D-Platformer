using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public static float bottomY = -20f; //-----------------------------------------------------------------

    public GameObject applePrefab;

    // Скорость яблони.
    public float treeSpeed = 1f; 
  
    // Расстояние, на котором должно изменяться направление движения яблони.
    public float leftAndRightEdge = 15f;

    // Вероятность изменения направления яблони движения.
    public float chanceToChangeDirections = 0.1f;

    // Частота создания экземпляров яблок.
    public float secondsBetweenAplleDrops = 1f;

   
    void Start()
    {
        // сбрасывать яблоки раз в секунду.
        Invoke("DropApples", 2f); // Функция инвок, вызывает функцию заданого именем в данном случае это DropApples, 
              // второй параметр сообщает методу инвок,что тот должен подождать 2 секунды, перед вызовом DropApples.
    }

    void Update()
    {
        // Простое перемещение.
        MoveTree();
        // Изменение направление.
        ChangeOfDirection();
    }

    void FixedUpdate()
    {
        // Добавляем метот рандома в фиксапдейт, для более точной фиксации рандома 50 кадров в секунду.
        RandomChangeOfDirection();
    }

    // Простая функцию, которая создает наши яблочки, где находится наша яблоня.
    void DropApples()
    {
        //Создает экземпляр аплПреф и присваивает его переменной apple типа GameObgect.
        GameObject apple = Instantiate<GameObject>(applePrefab);
        // Местоположение нового игрового объекта, устанавливаем РАВНЫМ нашей яблоне.
        apple.transform.position = transform.position;
        Invoke("DropApples", secondsBetweenAplleDrops);
    }

    
    // Создадим простой метод перемещения.
    void MoveTree()
    {
        Vector3 pos = transform.position;
        pos.x += treeSpeed * Time.deltaTime; // Компонент х переменно pos увеличивается на произведение treeSpeed.
        transform.position = pos; // Изменение значения pos присваивается обратно свойству transform.position, если это не сделать
                                  // яблоня не сдвинится с места.
    }

    // Создадим простой метод изменения направления яблони.
    void ChangeOfDirection()
    {
        Vector3 pos = transform.position;
        if(pos.x < -leftAndRightEdge) // Если позиция яблони по х меньше -10f то
        {
            treeSpeed = Mathf.Abs(treeSpeed);  // Начать движение вправо.
        }
        else if(pos.x > leftAndRightEdge) // Если позиция яблони по х больше 10f то
        {
            treeSpeed = -Mathf.Abs(treeSpeed); // Начать движение влево.
        }
    }
    // Простой метод по созданию рандома направления.
    void RandomChangeOfDirection()
    {
        if (Random.value < chanceToChangeDirections) // Random.value возвращает рандомное число от 0 до 1ф если число меньше
                                                     //chanceToChangeDirections то
        {
            treeSpeed *= -1; // то меняем переменную treeSpeed на противоположный, дабы задать ему другое направление.
        }
    }
}
