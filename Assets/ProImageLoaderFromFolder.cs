using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class ProImageLoaderFromFolder : MonoBehaviour
{
    public RectTransform procontentPanel; // Content �г��� RectTransform ����
    public GameObject proimagePrefab; // �̹����� ǥ���� ������ (Image ������Ʈ�� �ִ� �� GameObject)
    private List<Sprite> proimageSprites = new List<Sprite>();

    void Start()
    {
        LoadImages();
        DisplayImages();
    }

    void LoadImages()
    {
        // �̹����� ����� ���� ���
        string folderPath = Path.Combine(Application.dataPath, "ProScreenshots");

        // ���� ���� ��� ���� ��θ� ������
        string[] filePaths = Directory.GetFiles(folderPath, "*.png");

        foreach (var filePath in filePaths)
        {
            byte[] fileData = File.ReadAllBytes(filePath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);

            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            proimageSprites.Add(sprite);

            Debug.Log("����� load images");
        }
    }

    void DisplayImages()
    {
        foreach (var sprite in proimageSprites)
        {
            GameObject newImage = Instantiate(proimagePrefab, procontentPanel);
            newImage.GetComponent<Image>().sprite = sprite;
            Debug.Log("����� disaplayimages");
        }
    }
}
