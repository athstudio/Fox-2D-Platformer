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

    // ���� ����� ������� ��� ���������� ������� Basket, ���������� �� �� ������ �����������, ���� ��� ������.
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
        // ������� ��� ������� ������
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple"); // �������� ������, ������� ����� ����������
                                                                              //��� ������� � ����� ���.
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }

        // ������� ���� ������� 
        // �������� ������ ��������� ������� � �����������
        int basketIndex = basketList.Count - 1;
        // �������� ������ �� ���� ������� ������ Basket 
        GameObject tBasketGO = basketList[basketIndex];
        // ��������� ������� �� ������ � ������� ��� ������� ������
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);


        // ���� ������ �� ��������, ������������� ����.
        if(basketList.Count == 0)
        {
            SceneManager.LoadScene("Apple Picker");
        }
    }

}
