using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RadialMenuController : MonoBehaviour
{
    public GameObject menu;

    public GameObject player;
    private Animator animator;
    
    private Actions inputs;
    private Vector2 moveInput;

    public Text[] options;
    
    public Color normalColor, highlightedColor;
    // Start is called before the first frame update
    void Start()
    {
        animator = player.GetComponent<Animator>();
    }

    void Awake() {
        inputs = new Actions();
        //! Continuar con el menú
        // inputs.RadialMenu.Enable();
        // inputs.RadialMenu.ToggleMenu.performed += ToggleMenu;
    }

    void ToggleMenu(InputAction.CallbackContext ctx) 
    { 
        menu.SetActive(!menu.activeInHierarchy); 

        if (menu.activeInHierarchy) {
            Cursor.lockState = CursorLockMode.None;
        } else Cursor.lockState = CursorLockMode.Locked;
    }


    // Update is called once per frame
    void Update()
    {
        if (menu.activeInHierarchy) 
        {
            moveInput.x = Input.mousePosition.x - (Screen.width / 2f);
            moveInput.y = Input.mousePosition.y - (Screen.height / 2f);
            moveInput.Normalize();

            if(moveInput != Vector2.zero) 
            {
                float angle = Mathf.Atan2(moveInput.y, -moveInput.x) / Mathf.PI;

                angle *= 180;
                angle += 90;
                if (angle < 0) angle += 360;

                // for (int i = 0; i < options.Length)
            }
        }
    }
}
