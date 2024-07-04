using UnityEngine;

public class TileMovement : MonoBehaviour
{
    public RectTransform imageRectTransform;
    public float speed = 100f; 

    void Update()
    {
        float deltaWidth = speed * Time.deltaTime;

        imageRectTransform.sizeDelta = new Vector2
            (imageRectTransform.sizeDelta.x + deltaWidth, imageRectTransform.sizeDelta.y);

        imageRectTransform.anchoredPosition = new Vector2
            (imageRectTransform.anchoredPosition.x - deltaWidth / 2, imageRectTransform.anchoredPosition.y);
    }
}