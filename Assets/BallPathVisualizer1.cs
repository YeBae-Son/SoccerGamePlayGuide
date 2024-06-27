using FStudio.MatchEngine;
using System.Collections.Generic;
using UnityEngine;

public class BallPathVisualizer1 : MonoBehaviour
{
    public BallPathLoader ballPathLoader; // BallPathLoader ��ũ��Ʈ
    public LineRenderer lineRenderer; // LineRenderer ������Ʈ

    void OnEnable()
    {
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.startWidth = 1;
        lineRenderer.endWidth = 1;

        MatchManager.Current.screenshotEnd = true;

        DrawPath();

    }

    void DrawPath()
    {
        List<Vector3> positions = ballPathLoader.GetBallPositions();
        if (positions == null || positions.Count < 2)
            return;

        lineRenderer.positionCount = positions.Count;
        lineRenderer.SetPositions(positions.ToArray());
    }
}
