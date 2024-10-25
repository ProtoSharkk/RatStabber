using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Method to load the "SampleScene"
    public void LoadSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
