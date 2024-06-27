using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class ImageLoaderFromFolder : MonoBehaviour
{
    public RectTransform contentPanel; // Content �г��� RectTransform ����
    public GameObject imagePrefab; // �̹����� ǥ���� ������ (Image ������Ʈ�� �ִ� �� GameObject)
    private List<Sprite> imageSprites = new List<Sprite>();

    void Start()
    {
        LoadImages();
        DisplayImages();
    }

    void LoadImages()
    {
        // �̹����� ����� ���� ���
        string folderPath = Path.Combine(Application.dataPath, "Screenshots");

        // ���� ���� ��� ���� ��θ� ������
        string[] filePaths = Directory.GetFiles(folderPath, "*.png");

        foreach (var filePath in filePaths)
        {
            byte[] fileData = File.ReadAllBytes(filePath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(fileData);

            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            imageSprites.Add(sprite);
        }
    }

    void DisplayImages()
    {
        foreach (var sprite in imageSprites)
        {
            GameObject newImage = Instantiate(imagePrefab, contentPanel);
            newImage.GetComponent<Image>().sprite = sprite;
        }
    }
}
