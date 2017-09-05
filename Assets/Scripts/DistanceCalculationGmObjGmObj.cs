using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCalculationGmObjGmObj : MonoBehaviour {

    public static DistanceCalculationGmObjGmObj Instance { get; private set; }
    private LineRenderer lineRenderer;
    public List<Vector3> points;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        lineRenderer = GameObject.Find("LineRenderer").GetComponent<LineRenderer>();
    }

    public void AddPoint(Vector3 point)
    {
        float distance = 0.0f;

        points.Add(point);
        
        for (int i = 0; i < points.Count - 1; i++)
        {
            distance = distance + Vector3.Distance(points[i], points[i + 1]);

            if (i == 0)
                lineRenderer.SetPosition(0, points[0]);
  
            lineRenderer.SetPosition(i + 1, points[i + 1]);
        }

        TextMessage.Instance.ChangeTextMessage(string.Format("Distance: {0}", distance >= 1.0f ? distance.ToString("####0.0") + "m" : distance.ToString("0.00") + "cm"));
    }

    public void ClearPoints()
    {
        for (int i = 0; i < points.Count; i++)
            lineRenderer.SetPosition(i, Vector3.zero);

        points.Clear();

        TextMessage.Instance.ChangeTextMessage("Distance: - ");
    }
}
