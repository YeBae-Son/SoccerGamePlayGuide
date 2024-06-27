using UnityEngine;
using System.Collections;
using System.IO;
using FStudio.MatchEngine;
using FStudio.MatchEngine.Balls;

public class ScreenshotTaker : MonoBehaviour
{
    public Camera captureCamera; // 스크린샷을 찍을 카메라
    public float captureInterval = 1.0f; // 캡처 간격 (초)
    public string savePath = "Screenshots"; // 저장 경로

    private MatchManager matchManager;
    private float timer = 0.0f;
    private float time = 0.0f;
    private int screenshotCount = 0;

    void Start()
    {
        // 스크린샷 저장 경로를 설정합니다.
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
            time = timer; // 2초가 지날 때마다 사진 찍기
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
        if (MatchManager.Current.screenshotEnd )//@@@@ BallPathVisualizer1.cs가 enable 될 때 true로 바뀜 
        {
            Ball.Current.
            StopCoroutine(CaptureScreenshot());
            Debug.Log("코루틴 중지");
            gameObject.GetComponent<ScreenshotTaker>().enabled = false;
        }
        
    }

    IEnumerator CaptureScreenshot()
    {
        // 현재 프레임이 끝날 때까지 기다립니다.
        yield return new WaitForEndOfFrame();//WaitForSecondsRealtime(1);

        // RenderTexture를 설정합니다.
        RenderTexture renderTexture = new RenderTexture(500, 800, 24);//(Screen.width, Screen.height, 24);
        captureCamera.targetTexture = renderTexture;
        Texture2D screenShot = new Texture2D(500, 800, TextureFormat.RGB24, false);

        // 카메라로부터 렌더링합니다.
        captureCamera.Render();
        RenderTexture.active = renderTexture;
        screenShot.ReadPixels(new Rect(0, 0, 500, 800), 0, 0);
        screenShot.Apply();
        captureCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        // 스크린샷을 PNG 파일로 저장합니다.
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = Path.Combine(savePath, $"screenshot_{screenshotCount}.png");
        File.WriteAllBytes(filename, bytes);
        screenshotCount++;

        Debug.Log($"Screenshot saved: {filename}");

        /*// 현재 프레임이 끝날 때까지 기다립니다.
        yield return new WaitForSecondsRealtime(2);//^^7 Frame에서 리얼타임으로 수정해봄

        // 기존 카메라 설정을 저장합니다.
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture cameraRT = captureCamera.targetTexture;

        // RenderTexture를 설정합니다.
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        captureCamera.targetTexture = renderTexture;
        RenderTexture.active = renderTexture;

        // 카메라로부터 렌더링합니다.
        captureCamera.Render();
        Texture2D screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenShot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenShot.Apply();

        // RenderTexture를 초기 상태로 복구합니다.
        captureCamera.targetTexture = cameraRT;
        RenderTexture.active = currentRT;
        Destroy(renderTexture);

        // 스크린샷을 PNG 파일로 저장합니다.
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = Path.Combine(savePath, $"screenshot_{screenshotCount}.png");
        File.WriteAllBytes(filename, bytes);
        screenshotCount++;

        Debug.Log($"Screenshot saved: {filename}");*/
    }
}
