using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLineDrawer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject startObject;
    public GameObject finishObject;

    private bool isDrawing = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isDrawing && IsMouseOverStartObject())
            {
                StartDrawing();
            }
            else if (isDrawing)
            {
                ContinueDrawing();
            }
        }
    }

    void StartDrawing()
    {
        isDrawing = true;
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, GetMousePositionOnPlane());
    }

    void ContinueDrawing()
    {
        int currentPositionCount = lineRenderer.positionCount;
        Vector3 currentMousePosition = GetMousePositionOnPlane();
        lineRenderer.positionCount = currentPositionCount + 1;
        lineRenderer.SetPosition(currentPositionCount, currentMousePosition);

        // Check if the line connects to the 'Finish' object
        if (IsMouseOverFinishObject())
        {
            FinishDrawing();
        }
    }

    void FinishDrawing()
    {
        isDrawing = false;
        Debug.Log("Line connected to Finish object!");
        // Optionally, you can perform additional actions when the line connects to the 'Finish' object
    }

    bool IsMouseOverStartObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        return Physics.Raycast(ray, out hit) && hit.collider.gameObject == startObject && hit.collider.gameObject.tag == "Start";
    }

    bool IsMouseOverFinishObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        return Physics.Raycast(ray, out hit) && hit.collider.gameObject == finishObject && hit.collider.gameObject.tag == "Finish";
    }

    Vector3 GetMousePositionOnPlane()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;

        if (plane.Raycast(ray, out distance))
        {
            return ray.GetPoint(distance);
        }

        return Vector3.zero;
    }
}


