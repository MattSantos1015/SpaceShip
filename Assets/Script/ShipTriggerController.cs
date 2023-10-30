using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTriggerController : MonoBehaviour
{
    private int totalCubesCollected = 0;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("cube"))
        {
            //  Destroy(other.gameObject);
            other.GetComponent<CubeController>().GetCollected();
            totalCubesCollected += 1;
            Debug.Log("we have collected " +  totalCubesCollected + " cubes");
        }
    }
}
