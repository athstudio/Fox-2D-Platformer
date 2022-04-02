using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject cloudSphere;
    public int numSpheresMin = 6;
    public int numSpheresMax = 10;
    public Vector3 sphereOffsetScale = new Vector3(5, 2, 1);
    public Vector3 sphereScaleRangeX = new Vector2(4, 8);
    public Vector3 sphereScaleRangeY = new Vector2(3, 4);
    public Vector3 sphereScaleRangeZ = new Vector2(2, 4);
    public float scaleYmin = 2f;

    [SerializeField] private List<GameObject> spheres;

    private void Start()
    {
        spheres = new List<GameObject>();

        var num = Random.Range(numSpheresMin, numSpheresMax);
        for (var i = 0; i < num; i++)
        {
            var sp = Instantiate(cloudSphere);
            spheres.Add(sp);
            var spTrans = sp.transform;
            spTrans.SetParent(this.transform);

            //Выбрать случайный местонахождение
            Vector3 offset = Random.insideUnitSphere;
            offset.x = sphereOffsetScale.x;
            offset.y = sphereOffsetScale.y;
            offset.z = sphereOffsetScale.z;

            //Выбрать случайный маштаб
            Vector3 scale = Vector3.one;
            scale.x = Random.Range(sphereScaleRangeX.x, sphereScaleRangeX.y);
            scale.y = Random.Range(sphereScaleRangeY.x, sphereScaleRangeY.y);
            scale.z = Random.Range(sphereScaleRangeZ.x, sphereScaleRangeZ.y);
            
            //Скорректировать маштаб у по расстоянию х от центра 
            scale.y *= 1 - (Mathf.Abs(offset.x) / sphereOffsetScale.x);
            scale.y = Mathf.Max(scale.y, scaleYmin);

            var localPosition = scale;
            spTrans.localPosition = localPosition;
        }
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Restart();
        }
    }

    private void Restart()
    {
        // Удалить старые сферы, состовляющие обрако
        foreach (GameObject sp in spheres)
        {
            Destroy(sp);
        }
        Start();
    }
}
