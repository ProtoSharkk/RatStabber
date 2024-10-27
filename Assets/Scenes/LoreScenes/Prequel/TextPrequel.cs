using System.Collections;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // Reference to the TextMeshProUGUI component
    public float typingSpeed = 0.05f;     // Speed of the typing effect

    private string fullText;             // Full text to display
    private Coroutine typingCoroutine;   // Coroutine to handle typing

    private void Start()
    {
        // Example of starting the effect
        SetText("One day, a genius boy named Paul changed the world. He used his computer science knowledge to create destructive robots known as the PaulBots. Paul set his army against the rats, who stood little to no chance... \n\nOne day, a brave and courageous rat set off to fight the PaulBot army in hopes of avenging his kind. He fought ruthlessly day and night, and would not stop until the mastermind was finished once and for all...");
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
