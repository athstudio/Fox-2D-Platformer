using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public Text scoreGT;

    private void Start()
    {
        // Получить ссылку на игровой объект ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter"); // Отыскивает игровой объект в ирархии с именем - ScoreCounter.
        // Получить компонент текст этого компонента
        scoreGT = scoreGO.GetComponent<Text>();
        // Устанавливаем начальное число очков = 0.
        scoreGT.text = "0";
    }

    void Update()
    {
        MoveBasket();
    }

    void MoveBasket()
    {
        //Получить текущие координаты указателя мыши на экране из Инпут.
        Vector3 mousePos2D = Input.mousePosition;
        //Координаты з камеры определяет, как далеко находится мыш в трехмерном пространстве, но в 2д это особо не надо.
        mousePos2D.z = -Camera.main.transform.position.z;
        //
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

        /*
        float translation = Input.GetAxis("Horizontal") * speedBasketX;
        translation *= Time.deltaTime;
        transform.Translate(-translation, 0, 0);
        
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(speedBasketX * Time.deltaTime, 0, 0);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(-speedBasketX * Time.deltaTime, 0, 0);
        }
        */
    }

    void ScoreGT()
    {
        // Преобразовать текст скорГТ в целое число
        int score = int.Parse(scoreGT.text);
        //Добавим очки за пойманное яблоко
        score += 100;
        // Преобразовать число очков обратно в строку и вывести на экран
        scoreGT.text = score.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //При соприкосновением с корзиной, игровые объкты будут удаляться.
        GameObject collidedWith = collision.gameObject;
        if(collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
        }

        ScoreGT();
    }
}
