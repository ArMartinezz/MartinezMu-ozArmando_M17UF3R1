using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    RaycastHit hit;
    public bool isGrounded = false;
    public bool active = false;
    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            Debug.DrawRay(transform.position, -transform.up * hit.distance, Color.yellow);
        }
    }
}
