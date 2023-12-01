using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Cinemachine;

public class CamSpeen : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;

    private CinemachineOrbitalTransposer OrbTrans;
    void Start()
    {
        OrbTrans = VirtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            OrbTrans.m_XAxis.m_InputAxisName = "Mouse X";
        }
        else if (Input.GetKey(KeyCode.Mouse2)) { }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            OrbTrans.m_XAxis.m_InputAxisName = "";
            OrbTrans.m_XAxis.m_InputAxisValue = 0f;
        }
    }
}

