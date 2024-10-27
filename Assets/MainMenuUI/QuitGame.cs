using UnityEngine;

public class GameQuitter : MonoBehaviour
{
    // Method to quit the game
    public void QuitGame()
    {
        // Closes the application
        Application.Quit();

        // For the editor (testing purposes), stops play mode
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
