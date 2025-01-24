using UnityEngine;
using UnityEngine.UI;

public class FadeInImage : MonoBehaviour
{
    public Image imageToFade;  
    public float fadeDuration = 3.0f;  
    public float displayDuration = 2.0f; 

    private void Start()
    {
        if (imageToFade != null)
        {
            
            imageToFade.canvasRenderer.SetAlpha(1.0f);

         
            StartCoroutine(FadeOutImage());
        }
        else
        {
            Debug.LogError("Image object is not assigned.");
        }
    }

    private System.Collections.IEnumerator FadeOutImage()
    {
       
        yield return new WaitForSeconds(displayDuration);

        float elapsedTime = 0f;

      
        while (elapsedTime < fadeDuration)
        {
            float alpha = 1.0f - (elapsedTime / fadeDuration);
            imageToFade.canvasRenderer.SetAlpha(alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

       
        imageToFade.canvasRenderer.SetAlpha(0f);
    }
}
