using UnityEngine;
using System.Collections;
using System.IO;
using FStudio.MatchEngine;
using FStudio.MatchEngine.Balls;

public class ScreenshotTaker : MonoBehaviour
{
    public Camera captureCamera; // ��ũ������ ���� ī�޶�
    public float captureInterval = 1.0f; // ĸó ���� (��)
    public string savePath = "Screenshots"; // ���� ���

    private MatchManager matchManager;
    private float timer = 0.0f;
    private float time = 0.0f;
    private int screenshotCount = 0;

    void Start()
    {
        // ��ũ���� ���� ��θ� �����մϴ�.
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }
    }

    void Update()
    {
        /*timer = matchManager.minutes;
        Debug.Log("Timeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee : " + timer);
        if (timer - time > 2f)
        {
            time = timer; // 2�ʰ� ���� ������ ���� ���
            StartCoroutine(CaptureScreenshot());

        }*/
        if (MatchManager.Current.enabled)// && !MatchManager.Current.stageEnd)
        {
            timer += Time.deltaTime;
            if (timer >= captureInterval)
            {
                StartCoroutine(CaptureScreenshot());
                timer = 0.0f;
            }
        }
        if (MatchManager.Current.screenshotEnd )//@@@@ BallPathVisualizer1.cs�� enable �� �� true�� �ٲ� 
        {
            Ball.Current.
            StopCoroutine(CaptureScreenshot());
            Debug.Log("�ڷ�ƾ ����");
            gameObject.GetComponent<ScreenshotTaker>().enabled = false;
        }
        
    }

    IEnumerator CaptureScreenshot()
    {
        // ���� �������� ���� ������ ��ٸ��ϴ�.
        yield return new WaitForEndOfFrame();//WaitForSecondsRealtime(1);

        // RenderTexture�� �����մϴ�.
        RenderTexture renderTexture = new RenderTexture(500, 800, 24);//(Screen.width, Screen.height, 24);
        captureCamera.targetTexture = renderTexture;
        Texture2D screenShot = new Texture2D(500, 800, TextureFormat.RGB24, false);

        // ī�޶�κ��� �������մϴ�.
        captureCamera.Render();
        RenderTexture.active = renderTexture;
        screenShot.ReadPixels(new Rect(0, 0, 500, 800), 0, 0);
        screenShot.Apply();
        captureCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        // ��ũ������ PNG ���Ϸ� �����մϴ�.
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = Path.Combine(savePath, $"screenshot_{screenshotCount}.png");
        File.WriteAllBytes(filename, bytes);
        screenshotCount++;

        Debug.Log($"Screenshot saved: {filename}");

        /*// ���� �������� ���� ������ ��ٸ��ϴ�.
        yield return new WaitForSecondsRealtime(2);//^^7 Frame���� ����Ÿ������ �����غ�

        // ���� ī�޶� ������ �����մϴ�.
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture cameraRT = captureCamera.targetTexture;

        // RenderTexture�� �����մϴ�.
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        captureCamera.targetTexture = renderTexture;
        RenderTexture.active = renderTexture;

        // ī�޶�κ��� �������մϴ�.
        captureCamera.Render();
        Texture2D screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenShot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenShot.Apply();

        // RenderTexture�� �ʱ� ���·� �����մϴ�.
        captureCamera.targetTexture = cameraRT;
        RenderTexture.active = currentRT;
        Destroy(renderTexture);

        // ��ũ������ PNG ���Ϸ� �����մϴ�.
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = Path.Combine(savePath, $"screenshot_{screenshotCount}.png");
        File.WriteAllBytes(filename, bytes);
        screenshotCount++;

        Debug.Log($"Screenshot saved: {filename}");*/
    }
}
