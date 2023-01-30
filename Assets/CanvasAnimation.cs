using UnityEngine;

public class CanvasAnimation : MonoBehaviour
{
    public float initialLeftPosition;
    public float finalLeftPosition;
    public float yPosition;
    public float animationDuration;

    private float startTime;
    private RectTransform rectTransform;

    public bool anim_enabled;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(initialLeftPosition, yPosition);

        anim_enabled = false;   
    }

    void Update()
    {   
        if (!anim_enabled) return;

        if (startTime == 0)
        {
            startTime = Time.time;
        }

        float elapsedTime = Time.time - startTime;
        float progress = elapsedTime / animationDuration;

        float leftPosition = Mathf.Lerp(initialLeftPosition, finalLeftPosition, progress);
        float zPosition = Mathf.Lerp(0, finalLeftPosition - initialLeftPosition, Mathf.Pow(progress, 0.01f));

        rectTransform.anchoredPosition = new Vector3(leftPosition, yPosition, zPosition);
    }
}
