using UnityEngine;
using UnityEngine.UI;

public class Colliding : MonoBehaviour {

    public Image buttonImage;
    int alphathings;

    private void Start()
    {
        buttonImage.alphaHitTestMinimumThreshold = 0.9f;
    }

    public void hitTest()
    {
        Debug.Log("yee");

        /**
         * this one below is not functional lol.......only for testing if the alpha is below 0.8f
         */

        if (buttonImage.alphaHitTestMinimumThreshold <= 0.8f)
            Debug.Log("idih");
    }
}