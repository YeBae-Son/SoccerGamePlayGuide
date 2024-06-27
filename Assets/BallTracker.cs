using UnityEngine;
using System.Collections.Generic;

public class BallTracker : MonoBehaviour
{
    public Transform ball; // 공의 Transform
    public float recordInterval = 0.1f; // 위치를 기록하는 간격
    private List<Vector3> ballPositions = new List<Vector3>(); // 공의 위치를 저장할 리스트
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
        return new List<Vector3>(ballPositions); // 공의 위치 리스트 반환
    }

    public void ClearBallPositions()
    {
        ballPositions.Clear(); // 공의 위치 리스트 초기화
    }
}
