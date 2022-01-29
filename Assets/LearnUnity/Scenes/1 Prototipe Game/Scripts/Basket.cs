using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public Text scoreGT;

    private void Start()
    {
        // �������� ������ �� ������� ������ ScoreCounter
        GameObject scoreGO = GameObject.Find("ScoreCounter"); // ���������� ������� ������ � ������� � ������ - ScoreCounter.
        // �������� ��������� ����� ����� ����������
        scoreGT = scoreGO.GetComponent<Text>();
        // ������������� ��������� ����� ����� = 0.
        scoreGT.text = "0";
    }

    void Update()
    {
        MoveBasket();
    }

    void MoveBasket()
    {
        //�������� ������� ���������� ��������� ���� �� ������ �� �����.
        Vector3 mousePos2D = Input.mousePosition;
        //���������� � ������ ����������, ��� ������ ��������� ��� � ���������� ������������, �� � 2� ��� ����� �� ����.
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
        // ������������� ����� ������ � ����� �����
        int score = int.Parse(scoreGT.text);
        //������� ���� �� ��������� ������
        score += 100;
        // ������������� ����� ����� ������� � ������ � ������� �� �����
        scoreGT.text = score.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //��� ���������������� � ��������, ������� ������ ����� ���������.
        GameObject collidedWith = collision.gameObject;
        if(collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
        }

        ScoreGT();
    }
}
