using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    public LineRenderer LR;

    private void Awake()
    {
        LR = GetComponent<LineRenderer>();
    }

    public void RenderLine(Vector3 startPoint, Vector3 endPoint)
    {
        LR.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = startPoint;
        points[1] = endPoint;

        LR.SetPositions(points);
    }

    public void EndLine()
    {
        LR.positionCount = 0;
    }
}
