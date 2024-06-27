using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class FileMoveController : MonoBehaviour
{
    public Button moveButton; // UI 버튼
    private string sourceFolderPath; // 이동할 파일들이 있는 폴더 경로
    private string destinationFolderPath; // 파일을 옮길 폴더 경로
    public string folderPath = "ProScreenshots"; // 삭제할 파일들이 있는 폴더 경로

    void Start()
    {
        moveButton.onClick.AddListener(MoveFiles);
    }

    void MoveFiles()
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
        } //@@@@@@@@@먼저 폴더 비운 후 파일 추가

        Debug.Log("@@@@@@@@ move files");
        sourceFolderPath = Path.Combine(Application.dataPath, "Screenshots");
        destinationFolderPath = Path.Combine(Application.dataPath, "ProScreenshots");
        try
        {
            // sourceFolderPath에서 모든 파일 가져오기
            string[] files = Directory.GetFiles(sourceFolderPath);

            // 각 파일을 destinationFolderPath로 이동
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(destinationFolderPath, fileName);
                File.Move(file, destFile);
            }

            Debug.Log("파일 이동 완료!");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"파일 이동 중 오류 발생: {e.Message}");
        }
    }
}
