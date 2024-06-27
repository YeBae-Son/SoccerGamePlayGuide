using UnityEngine;
using System.Collections.Generic;

public class BallTracker : MonoBehaviour
{
    public Transform ball; // ���� Transform
    public float recordInterval = 0.1f; // ��ġ�� ����ϴ� ����
    private List<Vector3> ballPositions = new List<Vector3>(); // ���� ��ġ�� ������ ����Ʈ
    private float nextRecordTime;

    void Update()
    {
        if (Time.time >= nextRecordTime)
        {
            ballPositions.Add(ball.position);
            nextRecordTime = Time.time + recordInterval;
        }
    }

    public List<Vector3> GetBallPositions()
    {
        return new List<Vector3>(ballPositions); // ���� ��ġ ����Ʈ ��ȯ
    }

    public void ClearBallPositions()
    {
        ballPositions.Clear(); // ���� ��ġ ����Ʈ �ʱ�ȭ
    }
}
