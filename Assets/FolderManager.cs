using UnityEngine;
using System.IO;

public class FolderManager : MonoBehaviour
{
    public string folderPath = "Screenshots"; // 삭제할 파일들이 있는 폴더 경로

    void Start()
    {
        // Application.dataPath는 유니티 프로젝트의 Assets 폴더 경로를 반환합니다.
        string fullPath = Path.Combine(Application.dataPath, folderPath);

        // 폴더가 존재하는지 확인합니다.
        if (Directory.Exists(fullPath))
        {
            // 폴더 내 모든 파일을 가져옵니다.
            string[] files = Directory.GetFiles(fullPath);

            // 각 파일을 삭제합니다.
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
