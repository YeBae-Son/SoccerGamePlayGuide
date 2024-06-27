using UnityEngine;
using System.Collections.Generic;

public class BallPathVisualizer : MonoBehaviour
{
    public BallTracker ballTracker; // 공의 이동 경로를 추적하는 스크립트
    public LineRenderer lineRenderer; // LineRenderer 컴포넌트
    public Camera mainCamera; // 메인 카메라

    void Start()
    {
        // LineRenderer 설정
        lineRenderer.positionCount = 0;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    void Update()
    {
        // 공의 이동 경로 업데이트
        UpdatePath();
    }

    void UpdatePath()
    {
        List<Vector3> positions = ballTracker.GetBallPositions();
        lineRenderer.positionCount = positions.Count;

        // 월드 좌표를 화면 좌표로 변환
        for (int i = 0; i < positions.Count; i++)
        {
            Vector3 screenPoint = mainCamera.WorldToScreenPoint(positions[i]);
            screenPoint.z = 0; // UI는 z축이 필요하지 않으므로 0으로 설정
            positions[i] = screenPoint;
        }

        lineRenderer.SetPositions(positions.ToArray());
    }

    public void ClearPath()
    {
        lineRenderer.positionCount = 0;
        ballTracker.ClearBallPositions();
    }
}
