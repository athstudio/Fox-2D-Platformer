using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInputColors : MonoBehaviour
{
    public int alpha = 5;
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;

    //private int beta = 0;
    //private int gamma = 5;

    private AnotherClass myOtherClass;
    public GameObject gameObj;
    

    int numEnemies = 3;
    int cupsInTheSink = 4;

    float coffeeTemperature = 85.0f;
    float hotLimitTemperature = 70.0f;
    float coldLimitTemperature = 40.0f;

    void Awake ()
    {
       // Debug.Log("Awake called.");
    }

    // Start is called before the first frame update
    void Start()
    {
        
        
        // Цикл for----------------------------------
         for(int i = 0; i < numEnemies; i++)
        {
           // Debug.Log("Creating enemy number: " + i);
        }
        // Цикл while---------------------------------
         while(cupsInTheSink > 0)
        {
           // Debug.Log ("I've washed a cup!");
            cupsInTheSink--;
        }
        // Цикл do while------------------------------
         bool shouldContinue = false;
        
        do
        {
            //print ("Hello World");
            
        }
        while(shouldContinue == true);

        // Цикл foreach------------------------------- + Массив
        string[] strings = new string[3];
        
        strings[0] = "First string";
        strings[1] = "Second string";
        strings[2] = "Third string";
        
        foreach(string item in strings)
        {
           // print (item);
        }

         alpha = 29;
        
        //Берем другой скрипт C# с именем AnotherClass, чтобы взять Метод FruitMachine
        myOtherClass = new AnotherClass();
        myOtherClass.FruitMachine(alpha, myOtherClass.apples);
        //----------------------------------------------------------------------------

       // Debug.Log("Start called.");
    }

    void Example (int pens, int crayons)
    {
        int answer;
        answer = pens * crayons * alpha;
        Debug.Log(answer);
    }

    void FixedUpdate ()
    {
        //Debug.Log("FixedUpdate time :" + Time.deltaTime);
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            Destroy(gameObj);
        }


        // Debug.Log("Update time :" + Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
            TemperatureTest();
        
        coffeeTemperature -= Time.deltaTime * 5f;


        if(Input.GetKey(KeyCode.Q))
        {
            GetComponent<Renderer>().material.color = Color.red; 
            GetComponent<Transform>().transform.localScale = new Vector3(2,2,2);
            GetComponent<BoxCollider>().isTrigger = true;

            float speedY = 100f;
            
            transform.Rotate(0,speedY * Time.deltaTime,0);
            
            
            
            
        }
        if(Input.GetKey(KeyCode.W))
        {
            GetComponent<Renderer>().material.color = Color.green;
            GetComponent<Transform>().transform.localScale = new Vector3(1,1,1); 
            GetComponent<BoxCollider>().isTrigger = false;

            float speedX = 100f;
            
            transform.Rotate(speedX * Time.deltaTime,0,0);
            gameObject.SetActive(true);
            
        }
        if(Input.GetKey(KeyCode.E))
        {
            Color c = new Color(Random.value, Random.value, Random.value);
            GetComponent<Renderer>().material.color = c;
            GetComponent<Transform>().transform.localScale = new Vector3(0.5f,0.5f,0.5f);  
            GetComponent<BoxCollider>().isTrigger = true;

            float speedZ = 100f;

            transform.Rotate(0,0,speedZ * Time.deltaTime);
            gameObject.SetActive(true);
            
        }
        if(Input.GetKey(KeyCode.R))
        {
            gameObject.SetActive(false);
        }

       // Debug.Log("Alpha is set to: " + alpha);
    }

    
    void TemperatureTest ()
    {
       
        if(coffeeTemperature > hotLimitTemperature)
        { 
            print("Coffee is too hot.");
        }
        else if(coffeeTemperature < coldLimitTemperature)
        {
            print("Coffee is too cold.");
        }
        else
        {
            print("Coffee is just right.");
        }
    }
}
