using UnityEngine;
using System;

public class Bounce : MonoBehaviour
{
    public Transform originalObject;
    public Rigidbody rb;
    public Vector3 initialVelocity;
    public float maxSpeed = 5f;

    void Start()
    {
        originalObject = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialVelocity;
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.down);

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Bounce")
        {
            rb.AddRelativeForce(Vector3.Reflect(originalObject.position, originalObject.position));
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}