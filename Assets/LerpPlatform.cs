using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class LerpPlatform : MonoBehaviour
{
    LineRenderer lr; // reference to the line renderer
    Transform start, end, platformBase ; // a reference to start and end game objects
   
    [SerializeField] float intervalInSeconds = 2;

    [SerializeField] AnimationCurve curve;

    [SerializeField] bool looping = true;
    [SerializeField] bool updateBeam = false;
    // Start is called before the first frame update
    void Start()
    {
       
        start = this.transform.GetChild(1);// assing start
        end = this.transform.GetChild(2); // assign end
        platformBase = this.transform.GetChild(0);

        lr = this.gameObject.GetComponent<LineRenderer>(); // assign lr
        if(lr) // if lr exist, assign the positions
        {
            lr.SetPosition(0, start.position); 
            lr.SetPosition(1, end.position);
        }
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        if(updateBeam) // every frame we move we update the beam 
        {
        lr.SetPosition(1,platformBase.position);
        }
    }

    IEnumerator Move()
    {
        float counter = 0;
        while(counter < intervalInSeconds) // move from start to end
        {
            counter += Time.deltaTime / intervalInSeconds;
            platformBase.transform.position = Vector3.Lerp(start.position, end.position, curve.Evaluate(counter));
            yield return new WaitForEndOfFrame();                                                              
        }                                                                                                      
                                                                                                               
        yield return new WaitForSeconds(2); // wait to seconds                                                 
                                                                                                               
        while (counter > 0) // move from end to stat                                                           
        {                                                                                                      
            counter -= Time.deltaTime/intervalInSeconds;                                                                   
            platformBase.transform.position = Vector3.Lerp(start.position, end.position, curve.Evaluate(counter));
            yield return new WaitForEndOfFrame();
        }
        if (looping)
        {
            StartCoroutine(Move());
        }

    }
}
