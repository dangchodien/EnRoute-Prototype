using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousLineDrawer : MonoBehaviour
{
    public Color lineColor = Color.white;
    public float lineWidth = 0.1f;

    private LineRenderer lineRenderer;
    private bool drawing = false;

    // Expose the LineRenderer as a property
    public LineRenderer LineRenderer
    {
        get { return lineRenderer; }
    }

    void Start()
    {
        // Create LineRenderer component
        CreateLineRenderer();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDrawing();
        }
        else if (Input.GetMouseButton(0))
        {
            ContinueDrawing();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopDrawing();
        }
    }

    void CreateLineRenderer()
    {
        // Create a new GameObject and add LineRenderer component
        GameObject lineObject = new GameObject("Line");
        lineRenderer = lineObject.AddComponent<LineRenderer>();

        // Set LineRenderer properties
        lineRenderer.positionCount = 0; // Initially, there are no points
        lineRenderer.material = new Material(Shader.Find("Standard"));
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
    }

    void StartDrawing()
    {
        drawing = true;
        lineRenderer.positionCount = 1; // Start with one point
        lineRenderer.SetPosition(0, GetMousePositionOnPlane());
    }

    void ContinueDrawing()
    {
        if (drawing)
        {
            int currentPositionCount = lineRenderer.positionCount;
            lineRenderer.positionCount = currentPositionCount + 1;
            lineRenderer.SetPosition(currentPositionCount, GetMousePositionOnPlane());
        }
    }

    void StopDrawing()
    {
        drawing = false;
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

        // If the ray doesn't hit the plane, return a default position.
        return Vector3.zero;
    }
}
