using UnityEngine;
using UnityEngine.UI;

public class RawImageToImage : MonoBehaviour
{
    public RawImage rawImage; // Kéo thả RawImage vào đây từ Inspector

    void Start()
    {
        // Tạo GameObject mới chứa Image
        GameObject newImageObject = new GameObject("ConvertedImage");
        newImageObject.transform.SetParent(rawImage.transform.parent);

        // Sao chép vị trí và kích thước
        RectTransform newRectTransform = newImageObject.AddComponent<RectTransform>();
        RectTransform rawRectTransform = rawImage.GetComponent<RectTransform>();
        newRectTransform.sizeDelta = rawRectTransform.sizeDelta;
        newRectTransform.anchoredPosition = rawRectTransform.anchoredPosition;
        newRectTransform.anchorMin = rawRectTransform.anchorMin;
        newRectTransform.anchorMax = rawRectTransform.anchorMax;
        newRectTransform.pivot = rawRectTransform.pivot;

        // Thêm thành phần Image
        Image imageComponent = newImageObject.AddComponent<Image>();

        // Sao chép texture từ RawImage sang Image
        if (rawImage.texture != null)
        {
            Texture2D texture = rawImage.texture as Texture2D;
            imageComponent.sprite = Sprite.Create(texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f));
        }

        // Xóa RawImage cũ
        Destroy(rawImage.gameObject);
    }
}
