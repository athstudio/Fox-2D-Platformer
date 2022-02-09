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
    public int nextNum // Свойство только для чтения, так как не имеет метода set{}
    {
        get {_num++;  return (_num);} // Увеличивает значение _num на 1
                                      // Вернуть новое значение _num
    }

    public int currentNum // Свойство и для чтения и для записи так как имеет методы get{} set{}
        // Например get = int x = currentNum set = currentNum = 5; 
    {
        get { return (_num); } set{ _num = value; }
    }
}
