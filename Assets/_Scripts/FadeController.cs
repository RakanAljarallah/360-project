using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1.0f; // Duration of the fade

    // Start is called before the first frame update
    void Start()
    {
        // Optionally start with a fade in when the scene loads
        FadeIn();
    }

    public void FadeIn()
    {
        StartCoroutine(FadeScreen(1, 0)); // Fade from opaque to transparent
    }

    public void FadeOut()
    {
        StartCoroutine(FadeScreen(0, 1)); // Fade from transparent to opaque
    }

    IEnumerator FadeScreen(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0.0f;

        Color currentColor = fadeImage.color;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            fadeImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }
    }

    // Example usage for changing views
    public void ChangeViewWithFade()
    {
        StartCoroutine(ChangeViewRoutine());
    }

    IEnumerator ChangeViewRoutine()
    {
        FadeOut();
        yield return new WaitForSeconds(fadeDuration);
        // Load your environment or view here
        // Example: environmentController.EnvironmentIndex = viewIndex;
        FadeIn();
    }
}
