using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCamera : MonoBehaviour
{
    private float startingFOV = 60;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        // child 0 is the first child of the game object the script is attached to. 
        cam = this.gameObject.transform.GetChild(0).GetComponent<Camera>();
        startingFOV = cam.fieldOfView;
    }
    public void ZoomOut()
    {
        cam.fieldOfView = startingFOV + 15;
        
    }

    public void DefaultZoom() 
    {
        cam.fieldOfView = startingFOV;
    }
}
    
