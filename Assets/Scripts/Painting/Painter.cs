using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Painter : MonoBehaviour
{
    [SerializeField]
    private Material lineMat;

    [SerializeField]
    private float lineWidth;

    [SerializeField]
    private float tolerance;

    private LineRenderer currentLineRender;
    private List<Vector2> line = new List<Vector2>();
    private List<int> deleteList = new List<int>();
    private bool draw;
    private Camera camera;
    public int pointsUsed;

    private void Start()
    {
        GetComponent<BoxCollider2D>().size = GetComponent<RectTransform>().rect.size;
        camera = Camera.main;
    }

    private void Update()
    {
        if (draw)
        {
            OnDraw();
        }
    }

    private void OnDraw()
    {
        AddPointToLine(GetFingerPos());
        line = SimplifyBezierCurve(line);
        DrawLine();
    }

    private void OnMouseDown()
    {
        currentLineRender = Instantiate(new GameObject("Line"), transform)
            .AddComponent<LineRenderer>();
        InitLineRenderer(currentLineRender);
        line.Add(GetFingerPos());
        draw = true;
    }

    private Vector2 GetFingerPos()
    {
        return camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        draw = false;
        pointsUsed += line.Count;
        line.Clear();
        Debug.Log("Painter up");
    }

    private void InitLineRenderer(LineRenderer lr)
    {
        lr.material = lineMat;
        lr.startWidth = lineWidth;
        lr.endWidth = lineWidth;
        lr.startColor = Color.black;
        lr.endColor = lr.startColor;
        lr.useWorldSpace = true;
    }

    private void AddPointToLine(Vector2 point)
    {
        line.Add(point);
    }

    List<Vector2> SimplifyBezierCurve(List<Vector2> points)
    {
        List<Vector2> simplifiedPoints = new List<Vector2>();
        simplifiedPoints.Add(points[0]);

        for (int i = 1; i < points.Count - 2; i += 3)
        {
            Vector2 p0 = points[i];
            Vector2 p1 = points[i + 1];
            Vector2 p2 = points[i + 2];

            float distance = Vector2.Distance(p0, p2);

            if (distance > tolerance)
            {
                simplifiedPoints.Add(p0);
                simplifiedPoints.Add(p1);
                simplifiedPoints.Add(p2);
            }
        }

        simplifiedPoints.Add(points[points.Count - 2]);
        simplifiedPoints.Add(points[points.Count - 1]);

        return simplifiedPoints;
    }

    private void DrawLine()
    {
        currentLineRender.positionCount = line.Count;
        for (int i = 0; i < line.Count; i++)
        {
            currentLineRender.SetPosition(i, line[i]);
        }
    }
}
