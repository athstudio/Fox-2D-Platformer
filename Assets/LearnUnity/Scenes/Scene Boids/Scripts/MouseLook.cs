using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
  public float sensitivityHor = 9f;
  public float sensitivityVert = 9f;

  public float minimumVert = -45f;
  public float maximumVert = 45f;

  private float _rotationX = 0;
  
  public enum RotationAxes // enum позволяет использовать сразу именна вместо float MouseX 
  { 
      MouseXAndY = 0,
      MouseX = 1,
      MouseY = 2
  }

 public RotationAxes axes = RotationAxes.MouseXAndY; 

 void Start() 
 {
    Rigidbody body = GetComponent<Rigidbody>();
    if (body != null)
    {
      body.freezeRotation = true;
    }
    
 }

 void Update() 
 {
    if (axes == RotationAxes.MouseX) // вращение только по горизонтали  
    {
      transform.Rotate(0,Input.GetAxis("Mouse X") * sensitivityHor,0);
    }
    else if (axes == RotationAxes.MouseY) // вращение только по вертикали
    {
      _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;

      _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

      float rotationY = transform.localEulerAngles.y;

      transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
    }
   else // вращение по горизонтали и вертикали
    {
      _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
      _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

      float delta = Input.GetAxis("Mouse X") * sensitivityHor;
      float rotationY = transform.localEulerAngles.y + delta;

      transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
    }
 }
}
