using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public DynamicLineDrawer lineDrawer; // Reference to the script that draws the line
    public float speed = 5f; // Speed of movement
    public float heightAbovePlane = 1f; // Adjust this value to set the height above the plane

    private float distanceAlongLine = 0f;
    private bool lineDrawn = false;

    void Update()
    {
        if (lineDrawn)
        {
            MoveObjectAlongLine();
        }
        else
        {
            CheckLineDrawn();
        }
    }

    void CheckLineDrawn()
    {
        // Check if the line has been drawn completely
        if (lineDrawer != null && lineDrawer.lineRenderer != null)
        {
            LineRenderer lineRenderer = lineDrawer.lineRenderer;
            if (distanceAlongLine >= lineRenderer.positionCount - 1)
            {
                lineDrawn = true;
            }
        }
    }

    void MoveObjectAlongLine()
    {
<<<<<<< Updated upstream
        if (lineDrawer != null && lineDrawer.LineRenderer != null)
        {
            LineRenderer lineRenderer = lineDrawer.LineRenderer;

            // Move the object along the line based on a constant speed
=======
<<<<<<< HEAD
        if (lineDrawer != null && lineDrawer.lineRenderer != null)
        {
            LineRenderer lineRenderer = lineDrawer.lineRenderer;

            // Move the object along the line based on the speed
=======
        if (lineDrawer != null && lineDrawer.LineRenderer != null)
        {
            LineRenderer lineRenderer = lineDrawer.LineRenderer;

            // Move the object along the line based on a constant speed
>>>>>>> 767c1aacae397383476bf1af9a0c24b889eab514
>>>>>>> Stashed changes
            distanceAlongLine += Time.deltaTime * speed;

            // Wrap around the line if the distance exceeds the length of the line
            if (distanceAlongLine > lineRenderer.positionCount - 1)
            {
                distanceAlongLine = 0;
            }

            // Interpolate along the line and set the object's position
            int floorIndex = Mathf.FloorToInt(distanceAlongLine);
            int ceilIndex = Mathf.CeilToInt(distanceAlongLine);

            // Ensure indices are within bounds
            floorIndex = Mathf.Clamp(floorIndex, 0, lineRenderer.positionCount - 1);
            ceilIndex = Mathf.Clamp(ceilIndex, 0, lineRenderer.positionCount - 1);

            Vector3 floorPosition = lineRenderer.GetPosition(floorIndex);
            Vector3 ceilPosition = lineRenderer.GetPosition(ceilIndex);

<<<<<<< Updated upstream
=======
<<<<<<< HEAD
            // Interpolate between the two adjacent points
            float t = distanceAlongLine - floorIndex;
            Vector3 newPosition = Vector3.Lerp(floorPosition, ceilPosition, t);

            // Adjust the y-coordinate to keep the object above the plane
            newPosition.y = heightAbovePlane;

            transform.position = newPosition;

            // Optionally, rotate the object to align with the line direction
            Vector3 direction = ceilPosition - floorPosition;
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
=======
>>>>>>> Stashed changes
            // Easing function for smoother rotation (you can experiment with different easing functions)
            float t = EaseInOutCubic(distanceAlongLine - floorIndex);

            // Interpolate for smooth position along the line
            Vector3 newPosition = Vector3.Lerp(floorPosition, ceilPosition, t);
            newPosition.y = heightAbovePlane; // Adjust the y-coordinate to keep the object above the plane
            transform.position = newPosition;

            // Rotate the object smoothly toward the target direction
            Vector3 targetDirection = ceilPosition - floorPosition;
            if (targetDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection.normalized, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f); // Adjust the speed as needed
            }
<<<<<<< Updated upstream
=======
>>>>>>> 767c1aacae397383476bf1af9a0c24b889eab514
>>>>>>> Stashed changes
        }
    }
}












