using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    float mouseSensitivity = 500f;
    float lookUpDown = 0f;
    public Transform player;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//Locks the mouse pointer to the screen
        
    }
    // Update is called once per frame
    void Update()
    {
        //axis of where the mouse is
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //LookupDown - means up down + means down up
        //Clamp to 90 degrees up or down
        lookUpDown -= mouseY;
        lookUpDown = Mathf.Clamp(lookUpDown, -90f, 90f);

        //Transofrming head up and down and body left and right
        transform.localRotation = Quaternion.Euler(lookUpDown, 0f, 0f);
        player.Rotate(0, mouseX, 0);
    }
}
