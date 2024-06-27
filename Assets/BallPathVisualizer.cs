using UnityEngine;
using System.Collections.Generic;

public class BallPathVisualizer : MonoBehaviour
{
    public BallTracker ballTracker; // ���� �̵� ��θ� �����ϴ� ��ũ��Ʈ
    public LineRenderer lineRenderer; // LineRenderer ������Ʈ
    public Camera mainCamera; // ���� ī�޶�

    void Start()
    {
        // LineRenderer ����
        lineRenderer.positionCount = 0;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    void Update()
    {
        // ���� �̵� ��� ������Ʈ
        UpdatePath();
    }

    void UpdatePath()
    {
        List<Vector3> positions = ballTracker.GetBallPositions();
        lineRenderer.positionCount = positions.Count;

        // ���� ��ǥ�� ȭ�� ��ǥ�� ��ȯ
        for (int i = 0; i < positions.Count; i++)
        {
            Vector3 screenPoint = mainCamera.WorldToScreenPoint(positions[i]);
            screenPoint.z = 0; // UI�� z���� �ʿ����� �����Ƿ� 0���� ����
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
