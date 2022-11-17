using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CameraScript : MonoBehaviour
{
    [Header("Settings")]
    public float MouseSensitivity;
    public Transform Player;
    public PlayerMovement PM;

    // Keeping Track Of the X Rotation.
    float XRotation = 0f;

    void Start()
    {
        if (!PM.isOwned)
        {
            return;
        }

        

        // Locking And Hiding The Cursor.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Function For Camera
    public void CameraLook()
    {
        if (!PM.isOwned)
        {
            return;
        }

        // Getting Input From The Mouse And Assigning That To The MouseX And MouseY Variables.
        float MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.fixedDeltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.fixedDeltaTime;

        XRotation -= MouseY;
        XRotation = Mathf.Clamp(XRotation, -80f, 80f);

        // Applying The Rotation To The Camera According To The XRotation (MouseY)
        transform.localRotation = Quaternion.Euler(XRotation, 0, 0);

        // Rotating the Player On The X Axis Depending On The Value Of The MouseX Variable.
        Player.Rotate(Vector3.up * MouseX);
    }
}
