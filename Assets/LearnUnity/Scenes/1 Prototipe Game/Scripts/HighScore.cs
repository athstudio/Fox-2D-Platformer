using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int score = 1000; // ��������� ���������� ����, ���� ����������� ���������� � ��� �� ������ �������� HighScore.score

    void Awake()
    {
        // ���� �������� HighScore ��� ���������� � PlayerPrefs, ��������� ���
        if(PlayerPrefs.HasKey("HighScore"))
        {
            score = PlayerPrefs.GetInt("HighScore");
        }
        // ��������� ������ ���������� HighScore � ���������
        PlayerPrefs.SetInt("HighScore", score);
    }

    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "Higt Score: " + score;
        // �������� HighScore � PlayerPrefs, ���� ���������� 
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
