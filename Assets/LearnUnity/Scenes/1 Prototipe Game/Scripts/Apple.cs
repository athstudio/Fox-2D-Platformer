using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [Header("Set in Inspector")]
    public static float bottomY = -20f;
   
    void Update()
    {
        DestroyApples();
    }

    // �������� �����, ������� �������� ������ �� ��������� �������� ������� ������  
    void FindApplePicker()
    {   
        // �������� ������ �� ��������� �������� ������� ������ ���� ������
        ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
        // ������� ������������� ����� �� �������� AppleDestroed()
        apScript.AppleDestroed();
    }

    void DestroyApples()
    {
        //����������� ������, ���� ��� ������ ���� Y -20; 
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            FindApplePicker();
        }
    }
}
