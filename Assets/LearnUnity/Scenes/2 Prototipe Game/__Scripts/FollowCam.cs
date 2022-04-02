using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public static GameObject poi; // ������ �� ������������ ������
    [Header("Set in Inspector")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    [Header("Set Dynamically")]
    public float camZ; // �������� ���������� � ������

    void Awake()
    {
        camZ = this.transform.position.z;
    }

    void FixedUpdate()
    {
         Vector3 destination;
        //���� ��� ������������� ������� �������� ������� 0 0 0
        if (poi == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            destination = poi.transform.position;
            
            if (poi.CompareTag("Projectile"))
            {
                //���� �� ����� �� ����� 
                if (poi.GetComponent<Rigidbody>().IsSleeping())
                {   
                    //������� �������� ��������� ��� ���� ������
                    poi = null;
                    //� ��������� �����
                    return;
                }
                        
            }
        }
        //���� ������������ ������ - ������, ���������, ��� �� �����������
       
       
        //����������  ��� � ����� ������������ ���������� 
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        //���������� ����� ����� ������� �������������� ������ � ����������
        destination = Vector3.Lerp(transform.position, destination, easing);
        //������������� ���������� �������� ����������.� ������ ����, ����� ���������� ������ ��������
        destination.z = camZ;
        //��������� ������ � ������� ����������
        transform.position = destination;
        //�������� ������ ������ ,����� ����� ���������� � ���� ������
        if (Camera.main != null) Camera.main.orthographicSize = destination.y + 10;
    }
}
