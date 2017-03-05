using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class ShipMovement : MonoBehaviour
{

    [Header("Variables")]
    public float speed = 0.8f;
	public float turnSpeed = 0.3f;
	public float turnConstraint = 0.15f;
    public Quaternion currentRotation;

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
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.back, -turnSpeed * Time.deltaTime);
                transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.back, turnSpeed * Time.deltaTime);
                transform.Rotate(Vector3.down, -turnSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Rotate(Vector3.left, turnSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Rotate(Vector3.right, turnSpeed * Time.deltaTime);
            }
            currentRotation = transform.rotation;
        }
    }
}

