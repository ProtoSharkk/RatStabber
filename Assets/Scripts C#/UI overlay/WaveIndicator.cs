using UnityEngine;

public class WaveIndicator : MonoBehaviour
{
	GameState gameState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameState = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
		GetComponent<TMPro.TMP_Text>().text = "Wave: "+gameState.wave;
    }
}
