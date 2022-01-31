using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -10f;
    public float basketSpasingY = 2f;
    public float speedBasketX = 10.0f;

    public List<GameObject> basketList;


    void Start()
    {
        BasketSpasingY();
    }

    // Этот Метод создает три экземпляра шаблона Basket, располагая их на экране вертикально, друг над другом.
    void BasketSpasingY()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketSpasingY + (basketSpasingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleDestroed()
    {
        // Удалить все упавшие яблоки
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple"); // Создадим массив, который будет возвращать
                                                                              //все объекты с тэгом Апл.
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        // Удалить одну корзину 
        // Получить индекс последней корзины в баскетЛисте
        int basketIndex = basketList.Count - 1;
        // Получить ссылку на этот игровой объект Basket 
        GameObject tBasketGO = basketList[basketIndex];
        // Исключить корзину из списка и удалить сам игровой объект
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);


        // Если корзин не осталось, перезапустить игру.
        if(basketList.Count == 0)
        {
            SceneManager.LoadScene("Apple Picker");
        }
    }

}
