using UnityEngine;

public class healthIndicator : MonoBehaviour
{
	GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
		GetComponent<TMPro.TMP_Text>().text = "Health: "+player.GetComponent<Teo>().health.ToString()+"/100";
    }
}
