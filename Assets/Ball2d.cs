using UnityEngine;

public class Ball2d : MonoBehaviour
{
    public GameObject sourceObject; // ��ġ�� ������ ������Ʈ

    void Update()
    {
        // SourceObject�� ��ġ���� x, y, z ��ǥ�� ���� �����ɴϴ�.
        float sourceX = sourceObject.transform.position.x;
        float sourceZ = sourceObject.transform.position.z;

        // ������ ��ǥ�� ����Ͽ� TargetObject�� ��ġ�� �����մϴ�.
        transform.position = new Vector3(sourceX, 36, sourceZ);
    }
}
