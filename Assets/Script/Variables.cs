using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Variables : MonoBehaviour
{
    int counter = 0;       // integers are whole number positive or negative
    
    float charge = 0;    // floating point number, decimal place can change where it is, accurate up to 7 digits

    string enemyName = "Darth Vader";

    bool doorIsOpen = false;  // Either true or false, Alway name as statement no qustion

    Vector3 spawnPoint = new Vector3 (0,2,0);

    // let's spawn a ball five times a second
    [SerializeField]
    Transform ballSpawn;
    float ballSpawnTimer = 0;
    float ballSpawnInterval = .2f;


    // publice varible can be edited in inspector
    public GameObject door;
    
    // Start is called before the first frame update
    void Start()
    {
        // makes sure the code is running
        this .gameObject.name = enemyName;
        Debug.Log("The Variables Script is Running on the " + this.gameObject.name + " gameobject.");

    // if door is not assigned this looks for it in the scene
        if(door == null) 
     {
            door = GameObject.Find("Door");
     }  
    
    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            // adds 1 to counter everytime the space bar is pressed
            counter++;
            Debug.Log("SpaceBar has been pressed " + counter + " times");
        
        }

        if (Input.GetKey(KeyCode.C)) 
        {
           charge += Time.deltaTime;
          // Debug.Log("Charge is " +  charge);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            Debug.Log("Charge is " + charge + ". ");
            charge = 0;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        if(doorIsOpen)

        {
            door.SetActive(false);
        }
        else
        {
            door.SetActive(true);
        }
       // ture = Not true; False = not False. the ! = NOT
        doorIsOpen = !doorIsOpen;
        if(Input.GetKeyDown (KeyCode.B))
        {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = spawnPoint;
            cube.AddComponent<Rigidbody>();
         
        }

        // ball spawn timer
        ballSpawnTimer += Time.deltaTime;
            if(ballSpawnTimer > ballSpawnInterval)
        {
            // calls spawn ball
            spawnBall();
            // reset timer
            ballSpawnTimer = 0;
        }
    }

    // new fuction
    //void
    //named spawnball
    void spawnBall()
    {

        // spawn ball
        GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        ball.transform.position = ballSpawn.position;
        //randomize ball position
        ball.transform.position = (Random.insideUnitSphere * .2f) + ballSpawn.position;
        // setting scale
        ball.transform.localScale = Vector3.one * .2f;
        //add rigid body
        ball.AddComponent(typeof(Rigidbody));

    }
}
