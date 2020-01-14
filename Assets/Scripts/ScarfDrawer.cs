using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ScarfPoint
{
    public Vector2 oldPos;
    public Vector2 currentPos;

    public ScarfPoint(Vector2 pos)
    {
        this.currentPos = pos;
        this.oldPos = pos;
    }
}


public class ScarfDrawer : MonoBehaviour
{
    public Transform scarfAnchor;
    public float scarfPointInterval = 0.1f;
    public int scarfLength = 10;
    public int physicIterations = 10;

    private List<ScarfPoint> scarfPoints = new List<ScarfPoint>();

    LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        for(int i = 0; i < scarfLength; i++)
        {
            scarfPoints.Add(new ScarfPoint());
        }
    }

    private void FixedUpdate()
    {
        SimulateScarf();
    }

    private void SimulateScarf()
    {
        Vector2 normalForce = new Vector2(-1f, -5f);

        for(int i = 0; i < this.scarfLength; i++)
        {
            ScarfPoint firstPoint = this.scarfPoints[i];
            Vector2 velocity = firstPoint.currentPos - firstPoint.oldPos;
            firstPoint.oldPos = firstPoint.currentPos;
            firstPoint.currentPos += velocity;
            firstPoint.currentPos += normalForce * Time.deltaTime;
            this.scarfPoints[i] = firstPoint;
        }

        for(int i = 0; i < physicIterations; i++)
        {
            ApplyConstraint();
        }

        DrawScarf();
    }

    private void ApplyConstraint()
    {
        ScarfPoint firstPoint = this.scarfPoints[0];
        firstPoint.currentPos = scarfAnchor.position;
        this.scarfPoints[0] = firstPoint;

        for(int i = 0; i < this.scarfLength - 1; i++)
        {
            ScarfPoint first = this.scarfPoints[i];
            ScarfPoint second = this.scarfPoints[i + 1];

            float d = Vector2.Distance(first.currentPos, second.currentPos);
            float debug = Mathf.Abs(d - this.scarfPointInterval);

            Vector2 changeDir = (first.currentPos - second.currentPos).normalized;

            if (d > this.scarfPointInterval)
            {
                changeDir = (first.currentPos - second.currentPos).normalized;
            } 
            else if (d < this.scarfPointInterval)
            {
                changeDir = (second.currentPos - first.currentPos).normalized;
            }

            Vector2 changeAmount = changeDir * debug;

            if(i != 0)
            {
                first.currentPos -= changeAmount * 0.5f;
                this.scarfPoints[i] = first;
                second.currentPos += changeAmount * 0.5f;
                this.scarfPoints[i + 1] = second;
            }
            else
            {
                second.currentPos += changeAmount;
                this.scarfPoints[i + 1] = second;
            }
        }
    }

    private void DrawScarf()
    {
        Vector3[] scarfPointPostions = new Vector3[this.scarfLength];

        for(int i = 0; i < this.scarfLength; i++)
        {
            scarfPointPostions[i] = this.scarfPoints[i].currentPos;
        }

        lineRenderer.positionCount = scarfPointPostions.Length;
        lineRenderer.SetPositions(scarfPointPostions);
    }


}
