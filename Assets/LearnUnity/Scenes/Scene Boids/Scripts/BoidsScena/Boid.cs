using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    [Header("Set Dinamically")]
    public Rigidbody rb;

    private Neighborhood neighborhood;

    //����������� ���� ����� ��� ������������
    void Awake()
    {
        neighborhood = GetComponent<Neighborhood>();
        rb = GetComponent<Rigidbody>();

        // ������� ��������� ��������� �������
        pos = Random.onUnitSphere * Spawner.S.spawnRadius;

        // ������� ��������� ��������� ��������
        Vector3 vel = Random.onUnitSphere * Spawner.S.velocity;
        rb.velocity = vel;

        LookAhead();

        // �������� ����� � ��������� ����, �� �� ������ ������
        Color randColor = Color.black;
        while (randColor.r + randColor.g + randColor.b < 1.0f)
        {
            randColor = new Color(Random.value, Random.value, Random.value);
        }

        Renderer[] rends = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rends)
        {
            r.material.color = randColor;
        }
    }
        void LookAhead()
        {
            //������������ ����� ������ � ������� ������ 
            transform.LookAt(pos + rb.velocity);
        }

        public Vector3 pos
        {
        get { return transform.position; }
        set { transform.position = value; }
        }

    private void FixedUpdate()
    {
        Vector3 vel = rb.velocity;
        Spawner spn = Spawner.S;

        // �������������� ������������ - �������� ������� �������
        Vector3 velAvoid = Vector3.zero;
        Vector3 tooClosePos = neighborhood.avgClosePos;
        // ���� ������� ������ Vector3.zero, ������ ������������� �� ����
        if(tooClosePos != Vector3.zero)
        {
            velAvoid = pos - tooClosePos;
            velAvoid.Normalize();
            velAvoid *= spn.velocity;
        }

        // ������������ �������� - ����������� ����������� �������� � ��������
        Vector3 velAlign = neighborhood.avgVel;
        // ������������ ���������, ������ ���� velAlign �� ����� Vector3.zero
        if(velAlign != Vector3.zero)
        {
            // ��� ���������� ������ �����������, ������� ����������� ��������
            velAlign.Normalize();
            // � ����� ����������� � ��������� ��������
            velAlign *= spn.velocity;
        }

        // ������������ ������� - �������� � ������� ������ ������ �������
        Vector3 velCenter = neighborhood.avgPos;
        if(velCenter != Vector3.zero)
        {
            velCenter -= transform.position;
            velCenter.Normalize();
            velCenter *= spn.velocity;
        }

        // ���������� - ������������ �������� � ������� ������� Attractor
        Vector3 delta = Attractor.POS - pos;
        // ���������, ���� ���������, � ������� Attractor ��� �� ����
        bool attracted = (delta.magnitude > spn.attractPushDist);
        Vector3 velAttact = delta.normalized * spn.velocity;

        // ��������� ��� ��������
        float fdt = Time.fixedDeltaTime;
        if(velAvoid != Vector3.zero)
        {
            vel = Vector3.Lerp(vel, velAvoid, spn.collAvoid * fdt);
        }
        else
        {
            if(velAlign != Vector3.zero)
            {
                vel = Vector3.Lerp(vel, velAlign, spn.velMatching * fdt);
            }
        }

        if (velCenter != Vector3.zero)
        {
            vel = Vector3.Lerp(vel, velAlign, spn.flockCentering * fdt);
        }

        if (velAttact != Vector3.zero)
        {
            if (attracted)
            {
                vel = Vector3.Lerp(vel, velAttact, spn.attractPull * fdt);
            }
            else
            {
                vel = Vector3.Lerp(vel, -velAttact, spn.attractPush * fdt);
            }
        }

        if(attracted)
        {
            vel = Vector3.Lerp(vel, velAttact, spn.attractPull * fdt);
        }
        else
        {
            vel = Vector3.Lerp(vel, -velAttact, spn.attractPush * fdt);
        }

        // ���������� vel � ������������ c velocity � �������-�������� Spawner
        vel = vel.normalized * spn.velocity;
        // � ���������� ��������� �������� ���������� Rigidbody
        rb.velocity = vel;
        //��������� ����� ������ � ������� ������ ����������� ��������
        LookAhead();
    }

}
