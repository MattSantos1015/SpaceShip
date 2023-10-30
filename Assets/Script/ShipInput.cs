using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInput : MonoBehaviour
{
    [SerializeField] private ShipCamera shipCam;
    private ShipMovement shipMove;
    [SerializeField] private Wreckingball wreckingball;
    // Start is called before the first frame update
    void Start()
    {
        if ( shipCam == null ) shipCam = this.gameObject.GetComponent<ShipCamera>();
        shipMove = this.GetComponent<ShipMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)) shipCam.ZoomOut();
        if (Input.GetKeyUp(KeyCode.Mouse1)) shipCam.DefaultZoom();
        if (Input.GetKeyDown(KeyCode.Mouse0) && wreckingball.readyToLaunch)
        {
            wreckingball.Launch();
        }
    }
    private void FixedUpdate()
    {
        shipMove.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
    }
}
