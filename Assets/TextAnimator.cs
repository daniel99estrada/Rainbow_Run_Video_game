using UnityEngine;
using TMPro;

public class TextAnimator : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float activationDelay = 3f;
    public bool anim_enabled = false;

    private void Update()
    {
        if (anim_enabled)
        {
            Invoke("ActivateText", activationDelay);
        }
    }

    private void ActivateText()
    {   
        textMeshPro.enabled = true;
    }
}
