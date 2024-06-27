using UnityEngine;
using UnityEngine.UI;
using System.IO;
using FStudio.MatchEngine;

public class CaptureCameraView : MonoBehaviour
{
    public Camera cameraToCapture;
    public RawImage displayImage;
    private Texture2D capturedImage;

    //public MatchManager matchManager;

    void OnEnable()
    {
        LoadImage();

        CaptureView();
    }

    void CaptureView()
    {
        
        // ī�޶��� ���� �ؽ�ó ����
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraToCapture.targetTexture = renderTexture;
        cameraToCapture.Render();

        // �ؽ�ó2D�� ���� �ؽ�ó ����
        RenderTexture.active = renderTexture;
        capturedImage = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        capturedImage.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        capturedImage.Apply();

        // ���� �ؽ�ó�� ī�޶� ���� ������� ����
        cameraToCapture.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);
        

        // �̹��� ����
        SaveImage();


        Debug.Log("CaptureView----------------------------------------------------");
        // UI�� �̹��� ǥ��
        //DisplayCapturedImage();
    }

    void SaveImage()
    {
        byte[] bytes = capturedImage.EncodeToPNG();
        string path;
        if (MatchManager.Current.stage_1 == true)
        {
            path = Path.Combine(Application.persistentDataPath, "capturedImage1.png");
            File.WriteAllBytes(path, bytes);
            Debug.Log($"Image1 saved to {path}");
        }
        else if (MatchManager.Current.stage_2 == true)
        {
            path = Path.Combine(Application.persistentDataPath, "capturedImage2.png");
            File.WriteAllBytes(path, bytes);
            Debug.Log($"Image2 saved to {path}");
        }
        else
            Debug.Log("Fail to save image");
        
    }

    void LoadImage()
    {
        string path;
        if (MatchManager.Current.stage_1 == true)
        {
            path = Path.Combine(Application.persistentDataPath, "capturedImage1.png");
            if (File.Exists(path))
            {
                byte[] bytes = File.ReadAllBytes(path);
                capturedImage = new Texture2D(Screen.width, Screen.height);
                capturedImage.LoadImage(bytes);
                DisplayCapturedImage();
            }
            else
            {
                Debug.Log("No saved image found.");
            }
        }
        else if (MatchManager.Current.stage_2 == true)
        {
            path = Path.Combine(Application.persistentDataPath, "capturedImage2.png");
            if (File.Exists(path))
            {
                byte[] bytes = File.ReadAllBytes(path);
                capturedImage = new Texture2D(Screen.width, Screen.height);
                capturedImage.LoadImage(bytes);
                DisplayCapturedImage();
            }
            else
            {
                Debug.Log("No saved image found.");
            }
        }
        else
            Debug.Log("fail to load image");
            
            
        
    }

    void DisplayCapturedImage() //Ŭ������ ����������(��� ����������) ��� ��������..? 
    {
        if (capturedImage != null)
        {
            displayImage.texture = capturedImage;
        }
    }
}
