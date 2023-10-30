using System.Collections;                                   // use comments to ask question or explain code
using System.Collections.Generic;
using UnityEngine;

public class Methods : MonoBehaviour
{
    [SerializeField] // lets us mess with this variable in the inspector
    GameObject go; // light
    [Header("Color Change Experiment")]
    [SerializeField]
    float colorChangeInterval = 1f;
    [SerializeField]
    GameObject colorChangeObject;



    // Start is called before the first frame update
    void Start() // void start does not get called unless it exist in the scene by attaching it to some game object
    {
        sayHello(); // this line calls the function to the start 
       Debug.Log(" 7 + 8 = " + AddTwoNumbers(7, 8));
        int answer = AddTwoNumbers(400, 600);
        Debug.Log ("400 + 600 = " + answer);
       
        
        StartCoroutine(ChangeColor(colorChangeObject,colorChangeInterval));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            StartCoroutine(Wait(go));

        }
    }

    // Functions have a return type, Name, parameters, and a body of code

    // functions are about input and output

    //return type is void, this returns nothign

    void sayHello()
    {
        Debug.Log("hello");
    }

    // create a function that adds two numbers and returns the sum


    // return type is int, returns an integer
    // name AddTwoNumbers
    // two parameters (Inputs) named num1 and num2. (they are integers)
    int AddTwoNumbers(int num1, int num2)
    {
        // create a int named sum that is equal to the two numbers
     int sum = num1 + num2;
     // return the sum
    return sum;
    }

    // coroutines called after a certain amount of time. lets you set the function to only return after a certain amount of frames
    // this coroutine will turn off a given gameobject using SetActive(False
    // wait two seconds
    // then turn it back on
    
    IEnumerator Wait(GameObject go)
     {
        // stuff we do before we wait
        go.SetActive(false);
        yield return new WaitForSeconds(2f);
        // stuf we do after waiting 
        go.SetActive(true);
     }

    // this coroutine will change the color of a game object every half second
    IEnumerator ChangeColor(GameObject obj, float Interval = .5f)
    {
        //loop with a while() Loop
        while (true) // true will keep running
        {
            yield return new WaitForSeconds(Interval);
            // then change color
            obj.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }

    }
}
