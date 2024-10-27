using UnityEngine;
using UnityEngine.SceneManagement;

public class ToPrequel : MonoBehaviour
{
    // Method to load the "Lore" scene
    public void LoadPrequelScene()
    {
        SceneManager.LoadScene("Prequel");
    }
}
