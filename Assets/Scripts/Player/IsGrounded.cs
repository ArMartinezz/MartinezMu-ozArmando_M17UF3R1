using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    RaycastHit hit;
    public bool fall;

    public bool active = false;
    private void FixedUpdate()
    {
        if (active) {
            if (Physics.Raycast(transform.position, -transform.up, out hit))
            {
                Debug.DrawRay(transform.position, -transform.up * hit.distance, Color.yellow);
                fall = hit.distance < 0.2f;
            }
        }
    }
}
