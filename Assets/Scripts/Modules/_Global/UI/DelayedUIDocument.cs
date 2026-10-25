using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class DelayedUIDocument : MonoBehaviour
{
    [Header("Timing Settings")]
    [Tooltip("Delay before fade-in starts (seconds)")]
    public float delayBeforeFade = 2.5f;
    
    [Tooltip("Duration of fade-in effect (seconds)")]
    public float fadeDuration = 1f;

    [Header("References")]
    [Tooltip("Target UIDocument component")]
    public UIDocument uiDocument;

    private VisualElement rootElement;

    private void Start()
    {
        // Get references
        if (uiDocument == null)
            uiDocument = GetComponent<UIDocument>();

        if (uiDocument != null)
        {
            rootElement = uiDocument.rootVisualElement;
            
            // Set initial transparent state
            rootElement.style.opacity = 0f;
            rootElement.style.visibility = Visibility.Visible;
            rootElement.style.display = DisplayStyle.Flex;
        }
        
        StartCoroutine(FadeInAfterDelay());
    }

    private IEnumerator FadeInAfterDelay()
    {
        // Initial delay
        yield return new WaitForSeconds(delayBeforeFade);

        if (uiDocument == null || rootElement == null)
        {
            Debug.LogWarning("UIDocument or root element missing!", this);
            yield break;
        }

        // Fade in animation
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsed / fadeDuration);
            rootElement.style.opacity = alpha;
            yield return null;
        }

        // Ensure fully visible at end
        rootElement.style.opacity = 1f;
    }

    [ContextMenu("Test Fade Effect")]
    public void TestFadeEffect()
    {
        if (uiDocument != null)
        {
            rootElement = uiDocument.rootVisualElement;
            rootElement.style.opacity = 0f;
            StartCoroutine(FadeInAfterDelay());
        }
    }
}