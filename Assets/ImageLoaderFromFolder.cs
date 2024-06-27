using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class ImageLoaderFromFolder : MonoBehaviour
{
    public RectTransform contentPanel; // Content 패널의 RectTransform 참조
    public GameObject imagePrefab; // 이미지를 표시할 프리팹 (Image 컴포넌트가 있는 빈 GameObject)
    private List<Sprite> imageSprites = new List<Sprite>();

    void Start()
    {
        LoadImages();
        DisplayImages();
    }

    void LoadImages()
    {
        // 이미지가 저장된 폴더 경로
        string folderPath = Path.Combine(Application.dataPath, "Screenshots");

        // 폴더 내의 모든 파일 경로를 가져옴
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
