using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountltHigher : MonoBehaviour
{
    private int _num = 0;

    void Update()
    {
        print("NextNum" + nextNum);
        print("CurrentNum" + currentNum);
    }
    public int nextNum // �������� ������ ��� ������, ��� ��� �� ����� ������ set{}
    {
        get {_num++;  return (_num);} // ����������� �������� _num �� 1
                                      // ������� ����� �������� _num
    }

    public int currentNum // �������� � ��� ������ � ��� ������ ��� ��� ����� ������ get{} set{}
        // �������� get = int x = currentNum set = currentNum = 5; 
    {
        get { return (_num); } set{ _num = value; }
    }
}
