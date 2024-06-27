using UnityEngine;

public class Ball2d : MonoBehaviour
{
    public GameObject sourceObject; // 위치를 가져올 오브젝트

    void Update()
    {
        // SourceObject의 위치에서 x, y, z 좌표를 따로 가져옵니다.
        float sourceX = sourceObject.transform.position.x;
        float sourceZ = sourceObject.transform.position.z;

        // 가져온 좌표를 사용하여 TargetObject의 위치를 설정합니다.
        transform.position = new Vector3(sourceX, 36, sourceZ);
    }
}
