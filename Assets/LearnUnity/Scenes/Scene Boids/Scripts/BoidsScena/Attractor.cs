using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    static public Vector3 POS = Vector3.zero; // Любой класс сможет обратиться к переменной POS - Attractor.POS.

    [Header("Set in Inspector")]
    public float radius = 10;
    public float xPhase = .5f;
    public float yPhase = .4f;
    public float zPhase = .1f;

    void FixedUpdate()
    {
        Vector3 tPos = Vector3.zero;
        Vector3 scale = transform.localScale;
        tPos.x = Mathf.Sin(xPhase * Time.time) * radius * scale.x;
        tPos.y = Mathf.Sin(yPhase * Time.time) * radius * scale.y;
        tPos.z = Mathf.Sin(zPhase * Time.time) * radius * scale.z;
        transform.position = tPos;
        POS = tPos;
    }
}
