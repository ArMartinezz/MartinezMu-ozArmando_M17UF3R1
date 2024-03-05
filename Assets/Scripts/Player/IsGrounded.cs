using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    RaycastHit hit;
    public bool land = false;
    public bool falling = false;
    public bool grounded = false;
    private void FixedUpdate()
    {
        Physics.Raycast(transform.position, -transform.up, out hit);
        grounded = hit.distance < 0.1f;
        if (!grounded && falling)
        {
            if (!land) Debug.DrawRay(transform.position, -transform.up * hit.distance, Color.red);
            land = hit.distance < 1f;
            Debug.Log(hit.distance);
        } else { land = false; }
    }
}
