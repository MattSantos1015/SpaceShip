using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField]
    private Vector3 startPosition;
    [SerializeField]
    private Vector3 endPosition;
    [SerializeField]
    private float intervalInSeconds;
    [SerializeField]
    AnimationCurve curve;
    [SerializeField]
    private bool looping = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting Elevator");
       // startPosition = new Vector3 (0, 0, 0);   Since i have it as a serialize field i do not need this two lines
       // endPosition = new Vector3 (0 , 5 , 0);
        StartCoroutine(Move());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !looping)
        {
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        float counter = 0;
        ;
        while(counter < intervalInSeconds)
        {
            counter += Time.deltaTime;
            this.transform.position = Vector3.Lerp (startPosition, endPosition, curve.Evaluate (counter / intervalInSeconds)); 
            yield return new WaitForEndOfFrame();

        }
        if(looping)
        {
            StartCoroutine (Move());
        }
    }
}
