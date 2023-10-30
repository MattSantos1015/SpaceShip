using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Wreckingball : MonoBehaviour
{
    [SerializeField]
    private float returnDelay = 1;
    [SerializeField]
    private float launcForce = 10;
    [SerializeField]
    AnimationCurve curve;
    [SerializeField]
    private float returnIntervalInSeconds = 2;
   
   
    private Transform ballStart;
    private Rigidbody rb;
    private bool readyToLaunch = true;

   

    private void Start()
    {
       rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        ballStart = GameObject.Find("BallStart").transform; // the parent we are the child of
    }
    // remove when attaching to ship
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && readyToLaunch) 
        {
            Launch();
        }

        if(readyToLaunch)
        {
            this.transform.position = ballStart.position;
            this.transform.rotation = ballStart.rotation;
        }
    }
    public void Launch()
    {
        StartCoroutine(Return());
        readyToLaunch = false;
        rb.isKinematic = false;
        rb.AddForce(ballStart.forward * launcForce, ForceMode.Impulse);
    }

    private IEnumerator Return()
    {
        Debug.Log("Ball is Returning");
        yield return new WaitForSeconds(returnDelay);
        rb.isKinematic = true;
        //lerp back to start 
       // this.transform.localPosition = new Vector3 (0, 0, 0);
       // this.transform.localRotation = Quaternion.identity;
        

        float counter = 0;
       
        Vector3 startPos = this.transform.position;
        //Vector3 endPos = ballStart.position;

        Quaternion startRotation = this.transform.rotation; 
        while (counter < 1)
        {
            Debug.Log("Return has started");
            counter += Time.deltaTime / returnIntervalInSeconds;
          // lerping position
            this.transform.position = Vector3.Lerp(startPos, ballStart.position, curve.Evaluate(counter));
           // lerping rotation
           this.transform.rotation = Quaternion.Lerp(startRotation, ballStart.rotation, curve.Evaluate(counter));
            yield return new WaitForEndOfFrame();
        }
        readyToLaunch =true;
        
    }
}
