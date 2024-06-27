using UnityEngine;
using System.IO;

public class FolderManager : MonoBehaviour
{
    public string folderPath = "Screenshots"; // ������ ���ϵ��� �ִ� ���� ���

    void Start()
    {
        // Application.dataPath�� ����Ƽ ������Ʈ�� Assets ���� ��θ� ��ȯ�մϴ�.
        string fullPath = Path.Combine(Application.dataPath, folderPath);

        // ������ �����ϴ��� Ȯ���մϴ�.
        if (Directory.Exists(fullPath))
        {
            // ���� �� ��� ������ �����ɴϴ�.
            string[] files = Directory.GetFiles(fullPath);

            // �� ������ �����մϴ�.
            foreach (string file in files)
            {
                File.Delete(file);
                Debug.Log($"Deleted file: {file}");
            }
        }
        else
        {
            Debug.LogWarning($"Folder not found: {fullPath}");
        }
    }
}
