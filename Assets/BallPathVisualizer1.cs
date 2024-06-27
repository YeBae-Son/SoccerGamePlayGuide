using FStudio.MatchEngine;
using System.Collections.Generic;
using UnityEngine;

public class BallPathVisualizer1 : MonoBehaviour
{
    public BallPathLoader ballPathLoader; // BallPathLoader 스크립트
    public LineRenderer lineRenderer; // LineRenderer 컴포넌트

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
