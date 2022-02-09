using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlong : MonoBehaviour
{
    private void LateUpdate()
    {
        CountltHigher cih = this.gameObject.GetComponent<CountltHigher>(); // ����� ��������� script CountItHigher
        if (cih != null) 
        {
            float tX = cih.currentNum / 10f;
            Vector3 tempLoc = pos;
            tempLoc.x = tX;
            pos = tempLoc;
        }
    }

    public Vector3 pos
    {
        get { return (this.transform.position); }
        set { this.transform.position = value; }
    }
}
