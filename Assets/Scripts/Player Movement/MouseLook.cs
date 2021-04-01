using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform cameraTransform;
    [Space]
    public float lookSensitivityX = 3f;
    public float lookSensitivityY = 2f;
    [Space]
    public float maximumUpLookAngle = 80;
    public float maximumDownLookAngle = 60;
    private const float multiplierConstant = 1000f;

    float x_rotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float x_input = Input.GetAxis("Mouse X");
        float y_input = Input.GetAxis("Mouse Y");

        x_input *= Time.deltaTime * lookSensitivityX * multiplierConstant;
        y_input *= Time.deltaTime * lookSensitivityY * multiplierConstant;

        //Looking left and right (this rotates the player body, not the camera:):
        transform.Rotate(Vector3.up * x_input);

        x_rotation -= y_input; //Turns y input into negative
        x_rotation = Mathf.Clamp(x_rotation, maximumUpLookAngle, maximumDownLookAngle);

        //Looking up and down, rotates the camera instead of the player himself:
        cameraTransform.localRotation = Quaternion.Euler(new Vector3(x_rotation, 0f, 0f));

    }
}
