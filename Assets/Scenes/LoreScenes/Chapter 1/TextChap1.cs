using System.Collections;
using UnityEngine;
using TMPro;

public class TypewriterEffectCh1 : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // Reference to the TextMeshProUGUI component
    public float typingSpeed = 0.05f;     // Speed of the typing effect

    private string fullText;             // Full text to display
    private Coroutine typingCoroutine;   // Coroutine to handle typing

    private void Start()
    {
        // Example of starting the effect
        SetText("The Rat fought hard for his kind, rallying up the support of the remaining rats. The Rat investigated some of the defeated PaulBots and managed to hack into them,  converting them into ratbots that aided him in his battles. The ratbots came out victorious, defeating the paulbot army... for now...");
    }

    public void SetText(string text)
    {
        fullText = text;
        textComponent.text = ""; // Clear current text

        // Stop any existing typing coroutine before starting a new one
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        // Start typing the new text
        typingCoroutine = StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        // Type each character one by one
        foreach (char c in fullText)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        typingCoroutine = null; // Reset coroutine reference after finishing
    }

    // Optional method to speed up typing
    public void SpeedUpTyping(float newSpeed)
    {
        typingSpeed = newSpeed;
    }
}
