using UnityEngine;
using UnityEngine.UI;

public class onemorecolliding : MonoBehaviour
{
    public Image buttonImage;
    int alphathings;

    private void Start()
    {
        buttonImage.alphaHitTestMinimumThreshold = 0.9f;
    }

    public void hitTest()
    {
        if (buttonImage.alphaHitTestMinimumThreshold >= 0.9f)
            Debug.Log("succ");
        else Debug.Log("yee");
    }

}