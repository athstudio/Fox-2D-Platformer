using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;

    void Start()
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
    }

    void ScoreGT()
    {
        // ������������� ����� ������ � ����� �����
        int score = int.Parse(scoreGT.text);
        //������� ���� �� ��������� ������
        score += 100;
        // ������������� ����� ����� ������� � ������ � ������� �� �����
        scoreGT.text = score.ToString();

        // ��������� ������ ���������� 
        if(score < HighScore.score)
        {
            HighScore.score = score;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        //��� ���������������� � ��������, ������� ������ ����� ���������.
        GameObject collidedWith = coll.gameObject;
        if(collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
        }

        ScoreGT();
    }
}
