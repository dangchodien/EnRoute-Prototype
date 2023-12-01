using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTheCam : MonoBehaviour
{
    public float CamSpeed;
    public Camera Camera;

	private float MouseX;
	private float MouseY;

    void Update()
	{
        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");
        Vector3 CamFwrd = Camera.main.transform.forward; CamFwrd.y = 0f; CamFwrd.Normalize();
        Vector3 CamRght = Camera.main.transform.right; CamRght.y = 0f; CamRght.Normalize();
        Vector3 Movement = CamFwrd*MouseY + CamRght*MouseX;

        if (Input.GetKey(KeyCode.Mouse2))
        {
            transform.Translate(Movement * CamSpeed * Time.deltaTime, Space.World);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (Input.GetKey(KeyCode.Mouse1)) { }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
