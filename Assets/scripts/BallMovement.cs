using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    float speed = 400f;
    public Rigidbody rb;
    
    void FixedUpdate(){
        Vector3 movement = Vector3.zero;
        movement.x = Input.acceleration.x;
        movement.z = Input.acceleration.y;
        if (movement.sqrMagnitude > 1)
            movement.Normalize();
        movement *= speed* Time.deltaTime;
        rb.velocity = movement;
     }
}
