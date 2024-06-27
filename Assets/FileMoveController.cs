using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class FileMoveController : MonoBehaviour
{
    public Button moveButton; // UI ��ư
    private string sourceFolderPath; // �̵��� ���ϵ��� �ִ� ���� ���
    private string destinationFolderPath; // ������ �ű� ���� ���
    public string folderPath = "ProScreenshots"; // ������ ���ϵ��� �ִ� ���� ���

    void Start()
    {
        moveButton.onClick.AddListener(MoveFiles);
    }

    void MoveFiles()
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
        } //@@@@@@@@@���� ���� ��� �� ���� �߰�

        Debug.Log("@@@@@@@@ move files");
        sourceFolderPath = Path.Combine(Application.dataPath, "Screenshots");
        destinationFolderPath = Path.Combine(Application.dataPath, "ProScreenshots");
        try
        {
            // sourceFolderPath���� ��� ���� ��������
            string[] files = Directory.GetFiles(sourceFolderPath);

            // �� ������ destinationFolderPath�� �̵�
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(destinationFolderPath, fileName);
                File.Move(file, destFile);
            }

            Debug.Log("���� �̵� �Ϸ�!");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"���� �̵� �� ���� �߻�: {e.Message}");
        }
    }
}
