using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    
    [SerializeField]
    private float mouseSensitivity;

    private Transform parent;

    private void Start() {
        parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        RotateCamera();
    }

    private void RotateCamera() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        parent.Rotate(Vector3.up, mouseX);        

        // float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        // transform.Rotate(Vector3.left, mouseY);
    }
}