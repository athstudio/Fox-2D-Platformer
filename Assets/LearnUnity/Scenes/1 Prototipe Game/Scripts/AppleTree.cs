using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public static float bottomY = -20f; //-----------------------------------------------------------------

    public GameObject applePrefab;

    // �������� ������.
    public float treeSpeed = 1f; 
  
    // ����������, �� ������� ������ ���������� ����������� �������� ������.
    public float leftAndRightEdge = 15f;

    // ����������� ��������� ����������� ������ ��������.
    public float chanceToChangeDirections = 0.1f;

    // ������� �������� ����������� �����.
    public float secondsBetweenAplleDrops = 1f;

   
    void Start()
    {
        // ���������� ������ ��� � �������.
        Invoke("DropApples", 2f); // ������� �����, �������� ������� �������� ������ � ������ ������ ��� DropApples, 
              // ������ �������� �������� ������ �����,��� ��� ������ ��������� 2 �������, ����� ������� DropApples.
    }

    void Update()
    {
        // ������� �����������.
        MoveTree();
        // ��������� �����������.
        ChangeOfDirection();
    }

    void FixedUpdate()
    {
        // ��������� ����� ������� � ����������, ��� ����� ������ �������� ������� 50 ������ � �������.
        RandomChangeOfDirection();
    }

    // ������� �������, ������� ������� ���� �������, ��� ��������� ���� ������.
    void DropApples()
    {
        //������� ��������� ������� � ����������� ��� ���������� apple ���� GameObgect.
        GameObject apple = Instantiate<GameObject>(applePrefab);
        // �������������� ������ �������� �������, ������������� ������ ����� ������.
        apple.transform.position = transform.position;
        Invoke("DropApples", secondsBetweenAplleDrops);
    }

    
    // �������� ������� ����� �����������.
    void MoveTree()
    {
        Vector3 pos = transform.position;
        pos.x += treeSpeed * Time.deltaTime; // ��������� � ��������� pos ������������� �� ������������ treeSpeed.
        transform.position = pos; // ��������� �������� pos ������������� ������� �������� transform.position, ���� ��� �� �������
                                  // ������ �� ��������� � �����.
    }

    // �������� ������� ����� ��������� ����������� ������.
    void ChangeOfDirection()
    {
        Vector3 pos = transform.position;
        if(pos.x < -leftAndRightEdge) // ���� ������� ������ �� � ������ -10f ��
        {
            treeSpeed = Mathf.Abs(treeSpeed);  // ������ �������� ������.
        }
        else if(pos.x > leftAndRightEdge) // ���� ������� ������ �� � ������ 10f ��
        {
            treeSpeed = -Mathf.Abs(treeSpeed); // ������ �������� �����.
        }
    }
    // ������� ����� �� �������� ������� �����������.
    void RandomChangeOfDirection()
    {
        if (Random.value < chanceToChangeDirections) // Random.value ���������� ��������� ����� �� 0 �� 1� ���� ����� ������
                                                     //chanceToChangeDirections ��
        {
            treeSpeed *= -1; // �� ������ ���������� treeSpeed �� ���������������, ���� ������ ��� ������ �����������.
        }
    }
}
