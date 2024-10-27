using System.Collections;
using UnityEngine;
using TMPro;

public class TypewriterEffectCh7 : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // Reference to the TextMeshProUGUI component
    public float typingSpeed = 0.05f;     // Speed of the typing effect

    private string fullText;             // Full text to display
    private Coroutine typingCoroutine;   // Coroutine to handle typing

    public void Start()
    {
        // Example of starting the effect
        SetText("Teo, armed up to the teeth, readily faces Gryan Breen. This was the battle that would go down in history. Sword in hand, fully focused, He readies for the attack. It was do or die.\n\n\"Then let it be known that you are the first and last man to ever see my full strength, Teo.\"");
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
