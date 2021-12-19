using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFallDown : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _platformRigidbody;
    [SerializeField] private float _collapseTime;

    public Vector2 currentPosition;
    public bool movingBack;

    // Start is called before the first frame update
    void Start()
    {
        _platformRigidbody = GetComponent<Rigidbody2D>();

        currentPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(movingBack == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, currentPosition, 20f * Time.deltaTime);
        }

        if(transform.position.y == currentPosition.y)
        {
            movingBack = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && movingBack == false)
        {
            StartCoroutine(Collapse(other));
        }
    }
 
 
    private IEnumerator Collapse(Collision2D other)
    {
         for ( int i = 0; i < 10; i++)
           {
               transform.localPosition += new Vector3(.01f, .01f, 0);
               yield return new WaitForSeconds(0.05f);
               transform.localPosition -= new Vector3(.01f, .01f, 0);
               yield return new WaitForSeconds(0.05f);
           }
        yield return new WaitForSeconds(_collapseTime);
        FallDown();
    }
 
    private void FallDown()
    {
    _platformRigidbody.isKinematic = false;
    Invoke("BackPlatform", 2f);
    //_playerRigidbody.useGravity = true;
    }

    private void BackPlatform()
    {
        _platformRigidbody.velocity = Vector2.zero;
        _platformRigidbody.isKinematic = true;
        movingBack = true;
    }

}
