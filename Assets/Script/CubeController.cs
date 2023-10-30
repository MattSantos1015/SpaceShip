using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CubeController : MonoBehaviour
{
   public int riseSpeed = 0;
    public int cubeSpeed = 0;
    // Start is called before the first frame update
    // create an integer named cube Speed with a random range between 1 and 10
    void Start()
    {
        cubeSpeed = Random.Range(1, 10);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, riseSpeed * Time.deltaTime, 0, Space.World);
    }

    public void GetCollected ()
    {
        // if pseed is greater thahn 6
        if (cubeSpeed > 6)
        {
            // turn grreen
            this.GetComponent<Renderer>().material.color = Color.green;
            // move up 
            riseSpeed = 5;
            this.GetComponent<Rigidbody>().isKinematic = true;
            //remove collider
           Destroy(this.GetComponent<Collider>());
            // destroy after 5 seconds
            Destroy(this.gameObject,5f);
        }
    // else
    else
        {
     // turn red
     this.GetComponent<Renderer>().material.color = Color.red;
            // destory self after 1 second
            Destroy(this.gameObject, 1f);

        }
    
    }
}
