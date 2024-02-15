using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class LazaroDance : MonoBehaviour
{
    public GameObject lazaro;
    private Animator animator;
    private Actions inputs;
    // Start is called before the first frame update
    void Start()
    {
        animator = lazaro.GetComponent<Animator>();
    }

    void Awake() 
    {
        inputs = new Actions();
        inputs.Lazaro.Enable();

        inputs.Lazaro.Dance1.performed += onDance;
        inputs.Lazaro.Dance2.performed += onDance;
        inputs.Lazaro.Dance3.performed += onDance;
    }

    void onDance(InputAction.CallbackContext ctx) 
    {
        switch(ctx.action.name.ToString()) {
            case "Dance 1":
                animator.SetTrigger("Dance Flair");
            break;
            case "Dance 2":
                animator.SetTrigger("Dance HipHop");
            break;
            case "Dance 3":
                animator.SetTrigger("Dance Salsa");
            break;
            default:
                Debug.Log(ctx.action.name.ToString() + " oh no");
            break;
        }
    }

}
