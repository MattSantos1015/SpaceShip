using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    // Fixed update is ran 50 times a second
   
    public void Move(float zAxis, float yAxis)
    {
        rb.AddRelativeForce(0, 0, zAxis * speed);
        rb.AddTorque(0, yAxis * rotSpeed, 0);
    }

}
