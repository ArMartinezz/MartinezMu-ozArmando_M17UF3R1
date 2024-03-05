using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.LowLevel;

public class LazaroMovement : MonoBehaviour
{
    public GameObject lazaro;
    private Rigidbody rigidBody;
    private Animator animator;
    private IsGrounded isGrounded;
    private Actions inputs;

    public float speed;
    public float jumpForce;
    private Vector3 moveDirection;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = lazaro.GetComponent<Animator>(); 
        isGrounded = GetComponent<IsGrounded>();
    }

    void Awake() {
        inputs = new Actions();
        inputs.Lazaro.Movement.Enable();
        inputs.Lazaro.Jump.Enable();

        inputs.Lazaro.Jump.performed += OnJump;
    }

    void FixedUpdate() {

        Move();

    }

    private void Move() {
        Vector2 inputDirection = inputs.Lazaro.Movement.ReadValue<Vector2>();
        moveDirection = transform.forward * inputDirection.y + transform.right * inputDirection.x;
        rigidBody.AddForce(moveDirection.normalized * speed, ForceMode.Force);

        // Animar movimiento
        
        animator.SetBool("Walking", moveDirection != Vector3.zero);
        // Si el modelo ha rotado o se ha movido después de una animación, resetea la rotación y posición dentro del objeto padre
        // lazaro.transform.localEulerAngles = Vector3.zero;
        // lazaro.transform.localPosition = Vector3.zero;

        // En medio de un salto

        animator.SetBool("Falling", isGrounded.falling);
        
        isGrounded.falling = rigidBody.velocity.y < -0.1f;
        if (isGrounded.falling && isGrounded.land) 
        {
            animator.SetTrigger("Land");
            isGrounded.falling = false;
        } 

    }

    private void OnJump(InputAction.CallbackContext ctx)
    {
        rigidBody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        animator.SetTrigger("Jump");
    }
}
