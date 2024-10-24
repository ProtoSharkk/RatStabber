using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
	Teo player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Teo>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMPro.TMP_Text>().text = "Health: "+player.health+"/"+player.maxHealth;
    }
}
