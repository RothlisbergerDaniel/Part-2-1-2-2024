using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{


    public List<Vector2> points;
    Vector3 lastPosition;
    public float pointThreshold = 0.2f;
    LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDown()
    {
        points = new List<Vector2>();
    }

    private void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //use a Vector2 to truncate the Z value
        if (Vector2.Distance(newPosition, lastPosition) > pointThreshold) {
            points.Add(newPosition);
            lastPosition = newPosition;
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
        }
        
        
    }

}
