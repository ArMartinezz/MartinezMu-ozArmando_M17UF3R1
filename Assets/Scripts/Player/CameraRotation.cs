using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Camera cam;
    public GameObject crosshair;
    public GameObject player;
    private Actions inputs;

    public float HorizontalSensitivity = 30.0f;


    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Awake() {
        inputs = new Actions();
        inputs.Lazaro.Enable();
    }
    // Update is called once per frame
    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked) RotatePlayer();

    }

    private void RotatePlayer() {
        float RotationX = HorizontalSensitivity * inputs.Lazaro.RotationX.ReadValue<float>() * Time.deltaTime;
        transform.Rotate(0, RotationX, 0, Space.Self);
    }
}
