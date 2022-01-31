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

    // —оздадим медот, который получает ссылку на компонент јплѕикер главное камеры  
    void FindApplePicker()
    {   
        // ѕолучить ссылку на компонент эплѕикер главной камеры ћейн  амера
        ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
        // ¬ызовем общедоступный метод из јплѕикер AppleDestroed()
        apScript.AppleDestroed();
    }

    void DestroyApples()
    {
        //”нижчтожать €блоки, если они падают ниже Y -20; 
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            FindApplePicker();
        }
    }
}
