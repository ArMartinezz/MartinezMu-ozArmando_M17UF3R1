using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;

public class LazaroMovement : MonoBehaviour
{
    public GameObject lazaro;
    private Rigidbody rigidBody;
    private Actions inputs;

    public float speed;
    private Vector3 moveDirection;
    private Animator animator;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = lazaro.GetComponent<Animator>();
    }

    void Awake() {
        inputs = new Actions();
        inputs.Lazaro.Movement.Enable();
    }

    void FixedUpdate() {

        Move();

    }

    private void Move() {
        Vector2 inputDirection = inputs.Lazaro.Movement.ReadValue<Vector2>();
        moveDirection = transform.forward * inputDirection.y + transform.right * inputDirection.x;
        rigidBody.AddForce(moveDirection.normalized * speed, ForceMode.Force);

        // Animar movimiento
        if (moveDirection != Vector3.zero) 
        {
            animator.SetBool("Walking", true);
            // Si el modelo ha rotado o se ha movido después de una animación, resetea la rotación y posición dentro del objeto padre
            lazaro.transform.localEulerAngles = Vector3.zero;
            lazaro.transform.localPosition = Vector3.zero;
        }
        else { animator.SetBool("Walking", false); }
    }
}
