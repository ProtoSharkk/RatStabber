using UnityEngine;
using UnityEngine.SceneManagement;

public class LoreToMainMenu : MonoBehaviour
{
    // Method to load the "mainMenu" scene
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
