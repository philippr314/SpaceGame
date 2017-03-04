using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class ShipMovement : MonoBehaviour
{

    [Header("Variables")]
    public float speed = 0.8f;
    public float turnSpeed = 0.15f;

    [HideInInspector]
    public bool allowInput = false;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        if (allowInput)
        {
            if (Input.GetButton("Jump"))
            {
                rb.AddRelativeForce(Vector3.forward * speed);
            }
            rb.AddRelativeTorque((Input.GetAxis("Vertical")) * turnSpeed, 0, 0); // W key or the up arrow to turn upwards, S or the down arrow to turn downwards.
            rb.AddRelativeTorque(0, (Input.GetAxis("Horizontal")) * turnSpeed, 0); // A or left arrow to turn left, D or right arrow to turn right. } 
        }
    }
}
